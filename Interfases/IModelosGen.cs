
using System.Collections.Generic;

namespace FoodTruckPOS.WebAPI.Interfases

{
    public interface IModelosGen <T,ID>
    {

        public T BuscarPorId(ID id);
        public List<T> BuscarTodos();
        public T Guardar(T id);

        public T Actualizar(T id);

        public void Borrar(ID id);  
    }
}
