//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCGA.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profesional
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Numero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Matricula { get; set; }
        public string Foto { get; set; }
        public System.DateTime createdon { get; set; }
        public string createdby { get; set; }
        public System.DateTime changedon { get; set; }
        public string changedby { get; set; }
        public Nullable<System.DateTime> deletedon { get; set; }
        public string deletedby { get; set; }
        public bool isdeleted { get; set; }
    }
}
