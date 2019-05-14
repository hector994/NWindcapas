using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository:IDisposable
    {
        //Se ha hecho generico para poderlo usarlo en general, aqui solo hemos hecho el contrato y falta implementarla


        //Para agregar una nueva entidad a la BD
        TEntity Create<TEntity>(TEntity toCreate) where TEntity : class;//Esto se llama Generic

        // Para eliminar una entidad
        bool Delete<TEntity>(TEntity toDelete) where TEntity : class;

        // Para actualizar
        bool Update<TEntity>(TEntity toUpdate) where TEntity : class;

        //Para recuperar una entidad en base a un criterio
        TEntity Retrieve<TEntity>(Expression<Func<TEntity, bool>> criteria)
            where TEntity : class;

        //Para recuperar un conjunto de entidades 
        //que cumplan con un criterio de busquedad
        List<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> criteria)
            where TEntity : class;
    }
}
