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
            string nombre1 = "";
            string nombre2 = "Robotina";

            Console.WriteLine("                     TRES EN RAYA");
            Console.WriteLine("***************************************************\n\n\n");

            //Pedimos nombre al jugador 1
            Console.WriteLine("Jugador1. Jugarás con la X.\nCual es tu nombre?");
            nombre1 = Console.ReadLine();

            while (nombre1.Equals("") || nombre1.Equals(" ") || (nombre1.Length < 2))
            {
                if (nombre1.Length < 2)
                {
                    Console.WriteLine("Introduce un nombre más largo");
                }
                Console.WriteLine("Cual es tu nombre?");
                nombre1 = Console.ReadLine();
            }

            //Pedimos nombre al jugador 2
            Console.WriteLine("Jugador2. Jugarás con la O.\n Cual es tu nombre?");
            nombre2 = Console.ReadLine();

            while (nombre2.Equals("") || nombre2.Equals(" ") || (nombre2.Length < 2))
            {
                if (nombre2.Length < 2)
                {
                    Console.WriteLine("Introduce un nombre más largo");
                }
                Console.WriteLine("Cual es tu nombre?");
                nombre2 = Console.ReadLine();
            }
           

            bool esTurnoJugadorUno = true;

            while (!HayGanador(tablero))
            {
                if (esTurnoJugadorUno)
                {
                    Console.Clear();
                    Console.WriteLine("                     TRES EN RAYA");
                    Console.WriteLine("***************************************************\n\n\n");
                    Console.WriteLine(TableroVisual(tablero));
                    Console.WriteLine();
                    string nombrejugador = "";
                    if (esTurnoJugadorUno)
                    {
                        nombrejugador = nombre1;
                    }
                    else
                        nombrejugador = nombre2;

                    string coordenada = "";
                    while (!EsCoordenadaValida(coordenada)|| EstaYaOcupada2(tablero, coordenada))
                    {
                        Console.WriteLine(nombrejugador + " Introduce la Coordenada donde quieres jugar.");
                        Console.WriteLine("Por ejemplo, A1");
                        coordenada = Console.ReadLine().ToUpper();

                        if (!EsCoordenadaValida(coordenada))
                        {
                            Console.WriteLine("La coordenada no es válida\n");
                        }

                        if (EstaYaOcupada2(tablero, coordenada))
                        {
                            Console.WriteLine("La coordenada Ya ha sido usada en esta partida.\nIntroduzca una nueva\n");
                        }
                    }
                    char caracterUsado = ' ';
                    if (esTurnoJugadorUno)
                    {
                        caracterUsado = 'X';
                    }else
                        caracterUsado = 'O';
                    //TODO REVISAR FALLO EN PONER COORDENADAS
                    //https://www.youtube.com/watch?v=2k8KZG5UldY&t=434s
                    //56:16
                    PonerCoordenadas(ref tablero, coordenada, caracterUsado);
                    if (HayGanador(tablero))
                    {
                        break;
                    }
                    esTurnoJugadorUno = !esTurnoJugadorUno;

                }

            }

            if (HayGanador(tablero))
            {
                Console.WriteLine("¡Fin del Juego!");
                if (Ganador(tablero) == 'X')
                {
                    Console.WriteLine(nombre1+" ha ganado esta vez");
                }else
                    Console.WriteLine(nombre2+ " ha ganado esta vez");
            }
            Console.ReadKey();

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
                if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2] && (tablero[0, 0] != ' '))
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
            
            static bool EstaYaOcupada2(char[,] tablero, string coordenada)
            {
                coordenada = coordenada.ToUpper();
                switch (coordenada)
                {
                    case "A1":
                        return EstaYaOcupada(tablero, 0, 0);
                    case "A2":
                        return EstaYaOcupada(tablero, 0, 1);
                    case "A3":
                        return EstaYaOcupada(tablero, 0, 2);
                    case "B1":
                        return EstaYaOcupada(tablero, 1, 0);
                    case "B2":
                        return EstaYaOcupada(tablero, 1, 1);
                    case "B3":
                        return EstaYaOcupada(tablero, 1, 2);
                    case "C1":
                        return EstaYaOcupada(tablero, 2, 0);
                    case "C2":
                        return EstaYaOcupada(tablero, 2, 1);
                    case "C3":
                        return EstaYaOcupada(tablero, 2, 2);
                }
                return false;
            }
            
            static void PonerCoordenadas(ref char[,] tablero, string coordenada, char letra)
            {
                coordenada = coordenada.ToUpper();
                switch (coordenada)
                {
                    case "A1":
                        tablero[0, 0] = letra;
                        return;

                    case "A2":
                        tablero[0, 1] = letra;
                        return;

                    case "A3":
                        tablero[0, 2] = letra;
                        return;

                    case "B1":
                        tablero[1, 0] = letra;
                        return;

                    case "B2":
                        tablero[1, 1] = letra;
                        return;

                    case "B3":
                        tablero[1, 2] = letra;
                        return;

                    case "C1":
                        tablero[2, 0] = letra;
                        return;

                    case "C2":
                        tablero[2, 1] = letra;
                        return;

                    case "C3":
                        tablero[2, 2] = letra;
                        return;

                }
            }
                   
            static bool EsCoordenadaValida(string coordenada)
            {
                coordenada = coordenada.ToUpper();
                if (coordenada == "A1" || coordenada == "A2" || coordenada == "A3" ||
                    coordenada == "B1" || coordenada == "B2" || coordenada == "B3" ||
                    coordenada == "C1" || coordenada == "C2" || coordenada == "C3"
                    ){
                    return true;
                }
                else
                    return false;
            }

        }
    }
}