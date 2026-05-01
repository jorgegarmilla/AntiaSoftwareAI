using System.ComponentModel.DataAnnotations;

namespace WebApp.Client.ModelView
{
    public class ContratoView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Comisisón del empleado no puede estar vacío (data annotation)")]
        [Range(0.1, double.MaxValue, ErrorMessage = "La comisión debe ser mayor que 0")]
        public double Comision { get; set; }

    }
}
