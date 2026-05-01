namespace WebApp.Client.ModelView
{
    public class ComunidadAutonoma
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

        public int ComunidadAutonomaId_INT { get; set; }

    }

}
