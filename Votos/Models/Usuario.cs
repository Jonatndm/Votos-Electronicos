//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Votos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }
        public Nullable<bool> ya_voto { get; set; }
    }
}
