using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using WebApp.Client.ModelView;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.Client.Services
{
    public class DataService: IDataService
    {
        public  List<ComunidadAutonoma> ReturnComunidadAutonomas()
        {
            List <ComunidadAutonoma> data =  new List<ComunidadAutonoma> {
                new ComunidadAutonoma { Id = 1.ToString(), Nombre = "Andalucía" },
                new ComunidadAutonoma { Id = 2.ToString(), Nombre = "Aragón" },
                new ComunidadAutonoma { Id = 3.ToString(), Nombre = "Asturias" },
                new ComunidadAutonoma { Id = 4.ToString(), Nombre = "Islas Baleares" },
                new ComunidadAutonoma { Id = 5.ToString(), Nombre = "Canarias" },
                new ComunidadAutonoma { Id = 6.ToString(), Nombre = "Cantabria" },
                new ComunidadAutonoma { Id = 7.ToString(), Nombre = "Castilla y León" },
                new ComunidadAutonoma { Id = 8.ToString(), Nombre = "Castilla-La Mancha" },
                new ComunidadAutonoma { Id = 9.ToString(), Nombre = "Cataluña" },
                new ComunidadAutonoma { Id = 10.ToString(), Nombre = "Extremadura" },
                new ComunidadAutonoma { Id = 11.ToString(), Nombre = "Galicia" },
                new ComunidadAutonoma { Id = 12.ToString(), Nombre = "Madrid" },
                new ComunidadAutonoma { Id = 13.ToString(), Nombre = "Murcia" },
                new ComunidadAutonoma { Id = 14.ToString(), Nombre = "Navarra" },
                new ComunidadAutonoma { Id = 15.ToString(), Nombre = "País Vasco" },
                new ComunidadAutonoma { Id = 16.ToString(), Nombre = "La Rioja" },
                new ComunidadAutonoma { Id = 17.ToString(), Nombre = "Ceuta" },
                new ComunidadAutonoma { Id = 18.ToString(), Nombre = "Melilla" },
                new ComunidadAutonoma { Id = 19.ToString(), Nombre = "Valencia" }
            };

            //if (includeSeleccione)
            //    data.Insert(0, new ComunidadAutonoma() { Id = "",  ComunidadAutonomaId_INT = 0, Nombre = "Seleccione ..." });

            foreach (var pr in data)
            {
                if  (pr.Id != "")
                    pr.ComunidadAutonomaId_INT = int.Parse(pr.Id);
            }

            return data;
        }

        public  List<Provincia> ReturnProvincias()
        {
            List<Provincia> provincias = new List<Provincia> {

            new Provincia { Id = 1.ToString(), Nombre = "Álava", ComunidadAutonomaId = 15.ToString() },
            new Provincia { Id = 49.ToString(), Nombre = "Asturias", ComunidadAutonomaId = 3.ToString() },
            new Provincia { Id = 50.ToString(), Nombre = "La Rioja", ComunidadAutonomaId = 16.ToString() },
            new Provincia { Id = 51.ToString(), Nombre = "Ceuta", ComunidadAutonomaId = 17.ToString() },
            new Provincia { Id = 52.ToString(), Nombre = "Melilla", ComunidadAutonomaId = 18.ToString() },
            new Provincia { Id = 2.ToString(), Nombre = "Albacete", ComunidadAutonomaId = 8.ToString() },
            new Provincia { Id = 3.ToString(), Nombre = "Alicante", ComunidadAutonomaId = 19.ToString() },
            new Provincia { Id = 4.ToString(), Nombre = "Almería", ComunidadAutonomaId = 1.ToString() },
            new Provincia { Id = 5.ToString(), Nombre = "Ávila", ComunidadAutonomaId = 7.ToString() },
            new Provincia { Id = 6.ToString(), Nombre = "Badajoz", ComunidadAutonomaId = 10.ToString() },
            new Provincia { Id = 7.ToString(), Nombre = "Baleares", ComunidadAutonomaId = 4.ToString() },
            new Provincia { Id = 8.ToString(), Nombre = "Barcelona", ComunidadAutonomaId = 9.ToString() },
            new Provincia { Id = 9.ToString(), Nombre = "Burgos", ComunidadAutonomaId = 7.ToString() },
            new Provincia { Id = 10.ToString(), Nombre = "Cáceres", ComunidadAutonomaId = 10.ToString() },
            new Provincia { Id = 11.ToString(), Nombre = "Cádiz", ComunidadAutonomaId = 1.ToString() },
            new Provincia { Id = 12.ToString(), Nombre = "Cantabria", ComunidadAutonomaId = 6.ToString() },
            new Provincia { Id = 13.ToString(), Nombre = "Castellón", ComunidadAutonomaId = 19.ToString() },
            new Provincia { Id = 14.ToString(), Nombre = "Ciudad Real", ComunidadAutonomaId = 8.ToString() },
            new Provincia { Id = 15.ToString(), Nombre = "Córdoba", ComunidadAutonomaId = 1.ToString() },
            new Provincia { Id = 16.ToString(), Nombre = "A Coruña", ComunidadAutonomaId = 11.ToString() },
            new Provincia { Id = 17.ToString(), Nombre = "Cuenca", ComunidadAutonomaId = 8.ToString() },
            new Provincia { Id = 18.ToString(), Nombre = "Girona", ComunidadAutonomaId = 9.ToString() },
            new Provincia { Id = 19.ToString(), Nombre = "Granada", ComunidadAutonomaId = 1.ToString() },
            new Provincia { Id = 20.ToString(), Nombre = "Guadalajara", ComunidadAutonomaId = 8.ToString() },
            new Provincia { Id = 21.ToString(), Nombre = "Guipúzcoa", ComunidadAutonomaId = 15.ToString() },
            new Provincia { Id = 22.ToString(), Nombre = "Huelva", ComunidadAutonomaId = 1.ToString() },
            new Provincia { Id = 23.ToString(), Nombre = "Huesca", ComunidadAutonomaId = 2.ToString() },
            new Provincia { Id = 24.ToString(), Nombre = "Jaén", ComunidadAutonomaId = 1.ToString() },
            new Provincia { Id = 25.ToString(), Nombre = "León", ComunidadAutonomaId = 7.ToString() },
            new Provincia { Id = 26.ToString(), Nombre = "Lérida", ComunidadAutonomaId = 9.ToString() },
            new Provincia { Id = 27.ToString(), Nombre = "Lugo", ComunidadAutonomaId = 11.ToString() },
            new Provincia { Id = 28.ToString(), Nombre = "Madrid", ComunidadAutonomaId = 12.ToString() },
            new Provincia { Id = 29.ToString(), Nombre = "Málaga", ComunidadAutonomaId = 1.ToString() },
            new Provincia { Id = 30.ToString(), Nombre = "Murcia", ComunidadAutonomaId = 13.ToString() },
            new Provincia { Id = 31.ToString(), Nombre = "Navarra", ComunidadAutonomaId = 14.ToString() },
            new Provincia { Id = 32.ToString(), Nombre = "Ourense", ComunidadAutonomaId = 11.ToString() },
            new Provincia { Id = 33.ToString(), Nombre = "Palencia", ComunidadAutonomaId = 7.ToString() },
            new Provincia { Id = 34.ToString(), Nombre = "Las Palmas", ComunidadAutonomaId = 5.ToString() },
            new Provincia { Id = 35.ToString(), Nombre = "Pontevedra", ComunidadAutonomaId = 11.ToString() },
            new Provincia { Id = 36.ToString(), Nombre = "Salamanca", ComunidadAutonomaId = 7.ToString() },
            new Provincia { Id = 37.ToString(), Nombre = "Segovia", ComunidadAutonomaId = 7.ToString() },
            new Provincia { Id = 38.ToString(), Nombre = "Sevilla", ComunidadAutonomaId = 1.ToString() },
            new Provincia { Id = 39.ToString(), Nombre = "Soria", ComunidadAutonomaId = 7.ToString() },
            new Provincia { Id = 40.ToString(), Nombre = "Tarragona", ComunidadAutonomaId = 9.ToString() },
            new Provincia { Id = 41.ToString(), Nombre = "Santa Cruz de Tenerife", ComunidadAutonomaId = 5.ToString() },
            new Provincia { Id = 42.ToString(), Nombre = "Teruel", ComunidadAutonomaId = 2.ToString() },
            new Provincia { Id = 43.ToString(), Nombre = "Toledo", ComunidadAutonomaId = 8.ToString() },
            new Provincia { Id = 44.ToString(), Nombre = "Valencia", ComunidadAutonomaId = 19.ToString() },
            new Provincia { Id = 45.ToString(), Nombre = "Valladolid", ComunidadAutonomaId = 7.ToString() },
            new Provincia { Id = 46.ToString(), Nombre = "Vizcaya", ComunidadAutonomaId = 15.ToString() },
            new Provincia { Id = 47.ToString(), Nombre = "Zamora", ComunidadAutonomaId = 7.ToString() },
            new Provincia { Id = 48.ToString(), Nombre = "Zaragoza", ComunidadAutonomaId = 2.ToString() }

            };

            foreach (var pr in provincias)
            {
                pr.ComunidadAutonomaId_INT = int.Parse(pr.ComunidadAutonomaId);
                pr.ProvinciaId_INT = int.Parse(pr.Id);
            }

            return provincias;
        }

        public async Task<List<RolView>> ReturnRolesAsync()
        {
            await Task.Delay(1000);

            return
            [
                new RolView { Nombre = "Director", Salario = 50000 },
                new RolView { Nombre = "Manager", Salario = 40000 },
                new RolView { Nombre = "Administrativo", Salario = 30000 },
            ];

        }

        public static List<Pais> ReturnPaises()
        {
            return new List<Pais> {
                new Pais { Id = 1, Nombre = "España" },
                new Pais { Id = 2, Nombre = "Francia" },
                new Pais { Id = 3, Nombre = "Italia" },
                new Pais { Id = 4, Nombre = "Alemania" },
                new Pais { Id = 5, Nombre = "Portugal" }
            };
        }

        public List<Empresa> ReturnEmpresas()
        {
            List<Empresa> empresas = new List<Empresa>();

            empresas.Add(new Empresa() { Id = 1, Nombre = "empresa 1" });
            empresas.Add(new Empresa() { Id = 2, Nombre = "empresa 2" });
            empresas.Add(new Empresa() { Id = 3, Nombre = "empresa 3" });
            empresas.Add(new Empresa() { Id = 4, Nombre = "empresa 4" });
            empresas.Add(new Empresa() { Id = 5, Nombre = "empresa 5" });

            return empresas;
        }
    }

    public interface IDataService
    {
        List<ComunidadAutonoma> ReturnComunidadAutonomas();

        List<Provincia> ReturnProvincias();

        Task<List<RolView>> ReturnRolesAsync();

        List<Empresa> ReturnEmpresas();

    }
}
