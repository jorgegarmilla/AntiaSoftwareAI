namespace WebApp.Client.ModelView
{

    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public DatosFiscalesEmpresa DatosFiscales { get; set; }
        public DatosContactoEmpresa DatosContacto { get; set; }
    }


    public class DatosFiscalesEmpresa
    {
        public string CIF { get; set; }
        public string NombreFiscal { get; set; }
    }

    public class DatosContactoEmpresa
    {
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
