//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HangmanBird.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Repeticion_Letras
    {
        public int Codigo_Palabra { get; set; }
        public string Letra { get; set; }
        public int Repeticiones { get; set; }
    
        public virtual Palabras Palabras { get; set; }
    }
}
