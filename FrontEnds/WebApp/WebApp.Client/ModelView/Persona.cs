using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp.Client.ModelView
{
    public class Persona
    {
        [Required(ErrorMessage = "Nombre es obligatorio")]
        public string Nombre { get; set; }

        public List<Pais> PaisesList { get; set; }

        [Required(ErrorMessage = "País es obligatorio")]
        public Pais? PaisSelected { get; set; }


        [EnumDataType(typeof(EnumGenero), ErrorMessage = "Debe seleccionar una opción válida de la lista de Géneros (data annotation)")]
        [Required(ErrorMessage = "País es obligatorio")]
        public EnumGenero Genero { get; set; }

    }
}
