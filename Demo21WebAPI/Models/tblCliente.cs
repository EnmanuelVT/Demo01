//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo21WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCliente
    {
        public int Id { get; set; }
        public int TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public int Sexo { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public int Estado { get; set; }
        public string Nota { get; set; }
        public int CantidadVisitas { get; set; }
    }
}
