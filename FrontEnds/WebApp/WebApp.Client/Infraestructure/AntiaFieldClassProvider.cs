using Microsoft.AspNetCore.Components.Forms;

namespace WebApp.Client.Infraestructure
{
    public class AntiaFieldClassProvider : FieldCssClassProvider
    {
        public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
        {
            var isValid = editContext.IsValid(fieldIdentifier);

            if (fieldIdentifier.FieldName == "Nombre" )
            {
                if (editContext.IsModified(fieldIdentifier))
                    return isValid ? "modified NombreValidField" : "modified NombreInvalidField";
                else
                    return isValid ? "NombreValidField" : "NombreInvalidField";
            }
            else
            {
                if (editContext.IsModified(fieldIdentifier))
                    return isValid ? "modified valid" : "modified invalid";
                else
                    return isValid ? "valid" : "invalid";
            }

        }
    }
}
