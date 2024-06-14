using FoodTruckPOS.WebAPI.Interfases;
using TestEnergyProject.data;

namespace TestEnergyProject.Models
{
    public class Mod_power_readings : IModelosGen<PowerReading, decimal>
    {
        public PowerReading Actualizar(PowerReading id)
        {
            throw new NotImplementedException();
        }

        public void Borrar(decimal id)
        {
            throw new NotImplementedException();
        }

        public PowerReading BuscarPorId(decimal id)
        {
            throw new NotImplementedException();
        }

        public List<PowerReading> BuscarTodos()
        {
            using (var db = new TsdbContext())
            {

                var entidad = db.PowerReadings.ToList();

                return entidad;

            }
        }

        public PowerReading Guardar(PowerReading pwd)
        {
            using (var db = new TsdbContext())
            {
                db.PowerReadings.Add(pwd);
                db.SaveChanges();
                return pwd;

            }
        }
    }
}
