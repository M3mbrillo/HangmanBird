using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanBird.birdcore
{    
    class Adivinador
    {
        private string _palabraActual;    
        public string palabraActual
        {
            get { return _palabraActual; }
            set
            {
                if (value.Length == this.cantidadLetras || _palabraActual == null || _palabraActual == "")
                _palabraActual = value;
            }
        }

        private List<char> _letrasDichas;
        public List<char> letrasDichas
        {
            get { return _letrasDichas; }
            set { _letrasDichas = value; }
        }

        private int _cantidadLetras;
        public int cantidadLetras
        {
            get { return _cantidadLetras; }
            set { _cantidadLetras = value; }
        }

        private char _caracterComodin;
        public char caracterComodin
        {
            get { return _caracterComodin; }
            set { _caracterComodin = value; }
        }

        private Pensador _pensador;
        public Pensador pensador
        {
            get { return _pensador; }
            set { _pensador = value; }
        }

        private float _margenAceptableDePreferencia;
        public float margenAceptableDePreferencia
        {
            get { return _margenAceptableDePreferencia; }
            set { _margenAceptableDePreferencia = value; }
        }


        private int _errores;  
        public int errores
        {
            get { return _errores; }
            set { _errores = value; }
        }


        public Adivinador()
        {
            this.letrasDichas = new List<char>();
            this.palabraActual = "";
            this.caracterComodin = '_';
            this.pensador = new Pensador();
            this.margenAceptableDePreferencia = 0.7f;
            this.errores = 0;
        }

        public bool InitPalabra(string palabra)
        {
            bool nRta = true;
            foreach (char letra in palabra)
            {
                if (letra != this.caracterComodin)
                {
                    nRta = false;
                }
            }
            this.cantidadLetras = palabra.Length;
            this.palabraActual = palabra;

            return nRta;
        }

        public char SugerirLetra()
        {         
            List<char> letrasCandidatas = this.pensador.ObtenerLetrasPosibles(this.palabraActual, this.caracterComodin, this.margenAceptableDePreferencia, this.letrasDichas);

            //selecciono una random
            
            Random random = new Random();
            int i = random.Next(letrasCandidatas.Count);
            
            this.letrasDichas.Add(letrasCandidatas[i]);

            return letrasCandidatas[i];
        }
    }
}
