namespace WebApp.Client.ModelView
{

    public class Provincia
    {
        public string Id { get; set; }
        public int Id_INT
        {
            get
            {
                if (String.IsNullOrEmpty(Id))
                    return 0;

                return int.Parse(Id);
            }
        }

        public string Nombre { get; set; }
        public string ComunidadAutonomaId { get; set; }
        public int ProvinciaId_INT { get; set; }
        public int ComunidadAutonomaId_INT { get; set; }
    }

}
