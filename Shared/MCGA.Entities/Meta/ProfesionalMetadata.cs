
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MCGA.Entities
{
    [MetadataType(typeof(ProfesionalMetadata))]
    public partial class Profesional
    {
        public class ProfesionalMetadata
        {
           [Required(ErrorMessage ="Requerido")]
            public string Nombre { get; set; }
            [Required(ErrorMessage = "Requerido")]
            public string Apellido { get; set; }
            [Phone]
            public string Telefono { get; set; }
            [EmailAddress]
            [DisplayName("Correo")]
            public string Email { get; set; }
           
        }
    }
}
