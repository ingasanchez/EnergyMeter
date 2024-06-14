
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestEnergyProject.data;

//using System.Linq;

namespace FoodTruckPOS.WebAPI.Interfases
{
    public class ModelosGen<T, ID> : IModelosGen<T, ID> where T : class
    {
        private readonly AppDBContext _dbContext;
        private readonly DbSet<T> _eList;
        public ModelosGen(AppDBContext context)
        {
            _dbContext = context;
            _eList = _dbContext.Set<T>();
    }

        public T BuscarPorId(ID id)
        {

                var entidad = (T)_eList.Find(id);

                return entidad;
        }

        public List<T> BuscarTodos()
        {

                var entidad = _eList.ToList();

                return entidad;
        }


        public T Guardar(T ent)
        {

                _eList.Add(ent);
                _dbContext.SaveChanges();
                return ent;

        }

        public T Actualizar(T ent)
        {
            
            _dbContext.Update(ent);
            _dbContext.SaveChanges();
            return ent;

        }

        public void Borrar(ID id)
        {
            var ent = _eList.Find(id);

            _dbContext.Remove(ent);
            _dbContext.SaveChanges();

          
        }

    }
}
