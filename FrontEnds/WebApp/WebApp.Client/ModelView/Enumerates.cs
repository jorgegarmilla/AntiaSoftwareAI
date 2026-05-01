using System.ComponentModel.DataAnnotations;

namespace WebApp.Client.ModelView
{
    public enum EnumEstadoCivil
    {
        [Display(Name = "Estado Soltero")]
        Soltero,
        [Display(Name = "Estado Casado")]
        Casado,
        [Display(Name = "Estado Viudo")]
        Viudo
    }

    public enum EnumGenero
    {
        [Display(Name = "Género Masculino")]
        Masculino = 1,
        [Display(Name = "Género Femenino")]
        Femenino = 2,
        [Display(Name = "Género no definido")]
        Secreto = 3
    }

}
