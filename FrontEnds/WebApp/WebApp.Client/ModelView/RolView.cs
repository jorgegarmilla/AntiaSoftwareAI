//using FluentValidation;
//using FluentValidation.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApp.Client.ModelView
{

    public class RolView
    {
        [Display(Name = "Nombre empleado")]
        public string Nombre { get; set; }

        [Display(Name = "Salario empleado")]
        public double? Salario { get; set; }


        [Display(Name = "Fecha de Alta")]
        public DateTime? FechaDeAlta { get; set; }



        //public class RolViewValidator : AbstractValidator<RolView>
        //{
        //    public RolViewValidator()
        //    {
        //        RuleFor(p => p.Nombre)
        //            .NotEmpty().WithMessage("Debe ingresar el Nombre")
        //            .MaximumLength(50).WithMessage("Nombre no puede ser más largo que 50 caracteres");

        //        RuleFor(p => p.Salario)
        //             .NotEmpty().WithMessage("Debe ingresar el Salario")
        //             .GreaterThan(0).WithMessage("El Salario debe ser mayor de 0")
        //             .LessThan(5000).WithMessage("El Salario debe ser menor que 5.000");
        //    }

        //}

    }
}
