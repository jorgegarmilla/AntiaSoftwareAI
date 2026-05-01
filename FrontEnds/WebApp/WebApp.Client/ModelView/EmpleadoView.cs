using FluentValidation;
//using FluentValidation.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using WebApp.Client.Components;
using WebApp.Client.Infraestructure;

namespace WebApp.Client.ModelView
{
    [ValidatableType]
    public class EmpleadoView : IValidatableObject
    {
        public EmpleadoView()
        {
            EmpresasList = new List<Empresa>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre del empleado no puede estar vacío (data annotation)")]
        [MaxLength(50, ErrorMessage = "Nombre del empleado no puede tener más de 50 caracteres (data annotation)")]
        [Display(Name = "Nombre empleado")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellidos del empleado no puede estar vacío (data annotation)")]
        [MaxLength(50, ErrorMessage = "Apellidos del empleado no puede tener más de 50 caracteres (data annotation)")]
        [MinLength(3, ErrorMessage = "Apellidos del empleado debe tener al menos 3 caracteres (data annotation)")]
        [Display(Name = "Apellidos empleado")]
        public string Apellidos { get; set; }

        public string Cargo { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Email (data annotation)")]
        [EmailAddress(ErrorMessage = "Debe ingresar un Email válido (data annotation)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Password (data annotation)")]
        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Debe ingresar la Fecha de Alta (data annotation)")]
        [FutureDate(ErrorMessage = "La fecha de alta no puede ser menor que hoy (data annotation).")]
        public DateTime FechaAlta { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Debe ingresar la Fecha de Baja (data annotation)")]
        [FutureDate(ErrorMessage = "La fecha de baja no puede ser menor que hoy (data annotation).")]
        public DateTime? FechaBaja { get; set; }
        
        public double? Salario { get; set; }

        public string SalarioTexto { get; set; }

        public ContratoView Contrato { get; set; }

        public int Categoria { get; set; }

        [EnumDataType(typeof(EnumGenero), ErrorMessage = "Debe seleccionar una opción válida de la lista de Géneros (data annotation)")]
        public EnumGenero Genero { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una Empresa (data annotation)")]
        public Empresa EmpresaSelected { get; set; }

        public List<Empresa> EmpresasList { get; set; }

        [Required(ErrorMessage = "Debe seleccionar la Comunidad Autonoma (data annotation)")]
        public ComunidadAutonoma ComunidadAutonomaSelected { get; set; }

        public List<ComunidadAutonoma> ComunidadesAutonomasList { get; set; } = new();
        
        public Provincia? ProvinciaSelected { get; set; }

        public List<Provincia> ProvinciasList { get; set; } = new();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // no incluir operaciones ascincronas (no llamadas a API)

            if (Salario.HasValue && (Salario < 0 || Salario > 5000))
                yield return new ValidationResult("El Salario debe ser mayor que 0 y menor que 5.000 (IValidatableObject.Validate())", new[] { nameof(Salario) });

            if (Email?.Contains("@opentext.com")== false)
                yield return new ValidationResult("El Email debe ser corporativo (IValidatableObject.Validate())", new[] { nameof(Email) });

            if (Nombre == "Antia" && Apellidos == "Garmilla")
                yield return new ValidationResult("No puede ser Antía (IValidatableObject.Validate())", new[] { string.Empty });

        }

    }

    public class EmpleadoViewValidator : AbstractValidator<EmpleadoView>
    {
        public EmpleadoViewValidator()
        {


            RuleFor(p => p.FechaAlta)
                .NotEmpty().WithMessage("Debe ingresar la Fecha de Alta")
                .LessThan(p => p.FechaBaja)
                .When(x => x.FechaBaja != null)
                .WithMessage("La Fecha de Alta debe ser anterior a la Fecha de Baja");

            RuleFor(p => p.FechaBaja)
                 .NotEmpty().WithMessage("Debe ingresar la Fecha de Baja")
                 .GreaterThan(p => p.FechaAlta).WithMessage("La Fecha de Baja debe ser posterior a la Fecha de Alta");

            //RuleFor(p => p.ProvinciaSelected)
            //    .NotNull()
            //    .When(x => x.ComunidadAutonomaSelected != null)
            //    .WithMessage("Debe seleccionar la Provincia");

            //RuleFor(p => p.Email)
            // .NotEmpty().WithMessage("Debe ingresar el Emailx")
            // .EmailAddress().WithMessage("Debe ingresar un Email valido")
            // .DependentRules(() =>
            // {
            //     RuleFor(p => p.Email)
            //         .MustAsync(async (email, _) => await IsCorporativoAsync(email))
            //         .WithMessage("El Email debe ser corporativo");
            // });

            //RuleFor(p => p.Salario)
            //    .NotEmpty().WithMessage("Debe ingresar el Salario")
            //    .GreaterThan(0).WithMessage("El Salario debe ser mayor de 0")
            //    .LessThan(5000).WithMessage("El Salario debe ser menor que 5.000");

            //RuleFor(p => p.Nombre)
            //    .NotEmpty().WithMessage("Debe ingresar el Nombre")
            //    .MaximumLength(50).WithMessage("Nombre no puede ser más largo que 50 caracteres");

            //RuleFor(p => p.Apellidos)
            //    .NotEmpty().WithMessage("Debe ingresar los Apellidos")
            //    .MaximumLength(50).WithMessage("El campo Apellidos no puede ser más largo que 50 caracteres")
            //    .MinimumLength(3).WithMessage("El campo Apellidos debe tener al menos tres letras");

            //RuleFor(p => p.ComunidadAutonomaSelected)
            //   .NotNull().WithMessage("Debe seleccionar la Comunidad Autonoma");


            //RuleFor(p => p.EmpresaSelected)
            //   .NotNull().WithMessage("Debe seleccionar una Empresa");

            //RuleFor(p => p.Genero)
            //    .IsInEnum().WithMessage("Debe seleccionar una opción de la lista de Géneros");



            ////RuleFor(p => p.Categoria)
            ////     .NotEmpty().WithMessage("Debe ingresar la Categoría")
            ////     .LessThan(10).WithMessage("La Categoría debe ser menor de 10")
            ////     .GreaterThan(0).WithMessage("La Categoría debe ser mayor de 0")
            ////     .Must(valor => int.TryParse(valor.ToString(), out _)).WithMessage("La Categoría debe ser un número entero");

        }

    }

}
