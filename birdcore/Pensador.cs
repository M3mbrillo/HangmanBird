using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace HangmanBird.birdcore
{
    /*
        Aqui aplico toda logica posible contra la base de datos y recolecto los datos
    */
    class Pensador
    {
        private char _charComodinSql;

        public char charComodinSql
        {
            get { return _charComodinSql; }
            set { _charComodinSql = value; }
        }

        public Pensador()
        {
            this.charComodinSql = '_'; //simboliza cualquier caracter en sql
        }

        public List<char> ObtenerLetrasPosibles(string palabraIncompleta, char caracterComodin, float tolerancia, List<char> letrasDichas)
        {            
            int cantidadCaracteres = palabraIncompleta.Length;
            palabraIncompleta = palabraIncompleta.Replace(caracterComodin, charComodinSql);
            string letras = string.Join(",", letrasDichas);

            
            List<char> nRta = new List<char>();
            using (model.HangmanBirdEntities context = new model.HangmanBirdEntities())
            {
                ObjectResult<model.sp_ObtenerLetrasPredilectas_result> result = null;
                result = context.sp_ObtenerLetrasPredilectas(palabraIncompleta, letras, cantidadCaracteres, tolerancia);                            
                if (result != null)
                {                
                    foreach (var item in result)
                    {
                        nRta.Add(item.Letra.ToCharArray()[0]);
                    }
                }
            }

            return nRta;
        }       
    }
}
