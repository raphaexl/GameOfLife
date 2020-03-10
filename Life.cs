using System;
using System.Threading;

namespace GameOfLife{
   
    class Life{
        const int WIDTH = 40;
        const int HEIGHT = 30;
        char [] buffer = new char[(WIDTH + 2) * (HEIGHT + 2)];
        char [] buffer2 = new char[(WIDTH  + 2) * (HEIGHT + 2)];

        private void CopyBuffer1To2(char []buffer, char[]buffer2){
               for (var i = 0; i < (WIDTH + 2) * (HEIGHT + 2); i++){
                   buffer2[i] = buffer[i];
            }
        }
        public Life(){
            
            for (var i = 0; i < HEIGHT + 2; i++){
                buffer[i] = ' ';
            }
            for (var i = 0; i < WIDTH + 2; i++){
                buffer[i] = '-';
                buffer[(HEIGHT + 1) * (WIDTH + 2) + i] = '-';
            }
            for (var i = 0; i < HEIGHT + 2; i++){
                buffer[i * (WIDTH + 2)] = '-';
                buffer[(WIDTH + 2) * i + (WIDTH + 1)] = '-';
            }
            int x = 10, y = 10;
            buffer[y * (WIDTH + 2) + x] = '#';
            x = 11; y = 10;
            buffer[y * (WIDTH + 2) + x] = '#';
            x = 10; y = 9;
            buffer[y * (WIDTH + 2) + x] = '#';
            x = 11; y = 9;
            buffer[y * (WIDTH + 2) + x] = '#';
            x = 20; y = 15;
            buffer[y * (WIDTH + 2) + x] = '#';
            x = 21; y = 15;
            buffer[y * (WIDTH + 2) + x] = '#';
            x = 22; y = 15;
            buffer[y * (WIDTH + 2) + x] = '#';

            x = 25; y = 14;
            buffer[y * (WIDTH + 2) + x] = '#';
            x = 26; y = 15;
            buffer[y * (WIDTH + 2) + x] = '#';
            x = 24; y = 16;
            buffer[y * (WIDTH + 2) + x] = '#';
            x = 25; y = 16;
            buffer[y * (WIDTH + 2) + x] = '#';
            x = 26; y = 16;
            buffer[y * (WIDTH + 2) + x] = '#';
            CopyBuffer1To2(buffer, buffer2);
        }

        private int Neighbours(int x, int y){
            int neighbours = 0;
            Func <int , int, int> indexElement = (x, y) => {
                         x = (x + WIDTH + 2) % (WIDTH + 2);
                         y = (y + HEIGHT + 2) % (HEIGHT + 2);
                         return (buffer2[y * (WIDTH + 2) + x] == '#') ? 1 : 0;
            };

            neighbours += indexElement(x - 1, y - 1);
            neighbours += indexElement(x, y - 1);
            neighbours += indexElement(x + 1, y - 1);
            neighbours += indexElement(x - 1, y);
            neighbours += indexElement(x + 1, y);
            neighbours += indexElement(x - 1, y + 1);
            neighbours += indexElement(x, y + 1);
            neighbours += indexElement(x + 1, y + 1);
            return (neighbours);
        }
        public void Update(){
            for (var i = 1; i < HEIGHT + 1; i++){
                for (var j = 1; j < WIDTH + 1; j++){
                    int neighbours = Neighbours(j, i);
                    //match for learn I be !
                    if (neighbours == 3){
                        buffer[j + i * (WIDTH + 2)] = '#';
                    }
                    else if (neighbours == 2){
                        buffer[j + i * (WIDTH + 2)] = buffer[j + i * (WIDTH + 2)];//I know i'm not serious
                    }else if (neighbours < 2 || neighbours > 3){
                        buffer[j + i * (WIDTH + 2)] = ' ';
                    }
                }
            }
            CopyBuffer1To2(buffer, buffer2);
        }

        public void Draw(){
            for (var i = 0; i < HEIGHT + 2; i++){
                for (var j = 0; j < WIDTH + 2; j++){
                    Console.Write(buffer2[i * (WIDTH + 2) + j]);
                }
                Console.WriteLine();
            }
        }

        public void Run(){
            while (true){
                Draw();
                Update();
                Thread.Sleep(50);
                Console.Clear();
           }
        }
    }
}