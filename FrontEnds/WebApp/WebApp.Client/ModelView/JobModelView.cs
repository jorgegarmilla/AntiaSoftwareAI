//using FluentValidation;

namespace WebApp.Client.ModelView
{
    public class JobModelView
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public EJobStatus Status { get; set; }  
    }


    public enum EJobStatus
    {
        Pending,
        InProgress,
        Completed,
        Failed
    }

    //public class JobModelViewValidator : AbstractValidator<JobModelView>
    //{
    //    public JobModelViewValidator()
    //    {
    //        RuleFor(p => p.Description).NotEmpty().WithMessage("Debe ingresar la Description");

    //    }
    //}
}
