using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TresEnRaya
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] tablero = new char[3, 3];
            InicializarTablero(ref tablero);//Antes de imprimir el tablero lo tengo que inicializar

            /*
            tablero[1, 1] = 'O';
            tablero[0, 1] = 'X';
            tablero[2, 0] = 'O';
            tablero[1, 2] = 'X';
            */

            Console.WriteLine(TableroVisual(tablero));
            Console.ReadLine();

        }

        static void InicializarTablero(ref char[,] tablero)
        {
            for (int contador1 = 0; contador1 < 3; contador1++)
            {
                for (int contador2 = 0; contador2 < 3; contador2++)
                {
                    tablero[contador1, contador2] = ' ';
                }
            }
        }
        static string TableroVisual(char[,] tablero)
        {
            Console.WriteLine();

            string tv = "";
            tv += "   A   B   C  " + Environment.NewLine;
            tv += " ┌───┬───┬───┐" + Environment.NewLine;
            tv += $"1│ {tablero[0, 0]} │ {tablero[0, 1]} │ {tablero[0, 2]} │" + Environment.NewLine;
            tv += " ├───┼───┼───┤" + Environment.NewLine;
            tv += $"2│ {tablero[1, 0]} │ {tablero[1, 1]} │ {tablero[1, 2]} │" + Environment.NewLine;
            tv += " ├───┼───┼───┤" + Environment.NewLine;
            tv += $"3│ {tablero[2, 0]} │ {tablero[2, 1]} │ {tablero[2, 2]} │" + Environment.NewLine;
            tv += " └───┴───┴───┘" + Environment.NewLine;

            return tv;
        }

        static char Ganador(char[,] tablero)
        {//Horizontales
            if (tablero[0, 0] == tablero[0, 1] && tablero[0, 1] == tablero[0, 2] && (tablero[0, 0] != ' '))
            {
                return tablero[0, 0];
            }
            if (tablero[1, 0] == tablero[1, 1] && tablero[1, 1] == tablero[1, 2] && (tablero[1, 0] != ' '))
            {
                return tablero[1, 0];
            }
            if (tablero[2, 0] == tablero[2, 1] && tablero[2, 1] == tablero[2, 2] && (tablero[2, 0] != ' '))
            {
                return tablero[2, 0];
            }
            //verticales
            if (tablero[0, 0] == tablero[1, 0] && tablero[1, 0] == tablero[2, 0] && (tablero[0, 0] != ' '))
            {
                return tablero[0, 0];
            }
            if (tablero[0, 1] == tablero[1, 1] && tablero[1, 1] == tablero[2, 1] && (tablero[0, 1] != ' '))
            {
                return tablero[0, 1];
            }
            if (tablero[0, 2] == tablero[1, 2] && tablero[1, 2] == tablero[2, 2] && (tablero[0, 2] != ' '))
            {
                return tablero[0, 2];
            }
            //Diagonal Izquierda
            if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2,2] && (tablero[0, 0] != ' '))
            {
                return tablero[2, 2];
            }
            //Diagonal Derecha
            if (tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0] && (tablero[0, 2] != ' '))
            {
                return tablero[0, 2];
            }

            return ' ';
        }

        static bool HayGanador(char[,] tablero)
        {
            return Ganador(tablero) != ' ';
        }

        static bool EstaYaOcupada(char[,] tablero, int x, int y)
        {
            if (x < 0 || x > 2)
            {
                throw new ArgumentException("El valor de X debe ser 0,1 o 2", "x");
            }

            if (y < 0 || y > 2)
            {
                throw new ArgumentException("El valor de X debe ser 0,1 o 2", "y");
            }

            return tablero[x, y] != ' ';
        }

        static void PonerCoordenadas(char[,] tablero, string coordenada, char letra)
        {
            coordenada = coordenada.ToUpper();
            if (coordenada=="A1")
            {
                tablero[0, 0] = letra;
            }
            if (coordenada == "A2")
            {
                tablero[0, 1] = letra;
            }
            if (coordenada == "A3")
            {
                tablero[0, 2] = letra;
            }
            if (coordenada == "B1")
            {
                tablero[1, 0] = letra;
            }
            if (coordenada == "B2")
            {
                tablero[1, 1] = letra;
            }
            if (coordenada == "B3")
            {
                tablero[1, 2] = letra;
            }
            if (coordenada == "C1")
            {
                tablero[2, 0] = letra;
            }
            if (coordenada == "C2")
            {
                tablero[2, 1] = letra;
            }
            if (coordenada == "C3")
            {
                tablero[2, 2] = letra;
            }
            
        }

        //https://www.youtube.com/watch?v=2k8KZG5UldY&t=434s
    }
}
