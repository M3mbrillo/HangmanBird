using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HangmanBird.birdcore;

namespace HangmanBird
{
    class Program
    {
        static void Main(string[] args)
        {
            //birdcore.Pensador pen = new birdcore.Pensador();
            //List<char> l = new List<char> { 'F', 'A', 'N' };
            //pen.ObtenerLetrasPosibles("F_AN__", '_', 0, l);
                                         
            string actualWord = "";

            Console.Write("Palabra: ");
            actualWord = Console.ReadLine();

            Adivinador adivinador = new Adivinador();
            adivinador.InitPalabra(actualWord);

            string input;
            while (adivinador.errores <= 5)
            {
                Console.WriteLine("Pienso en: " + adivinador.SugerirLetra());
                input = Console.ReadLine();
                if (input.Length != adivinador.palabraActual.Length)
                {
                    //es diferente, lo tomo como un NO....
                    adivinador.errores++;
                }
                else
                {
                    //confio en el usuario me marco donde esta la letras.
                    adivinador.palabraActual = input;
                }
                Console.WriteLine("Palabra que adivino... " + adivinador.palabraActual);
            }

        }
    }
}
