using Entities.Models;
using System.Dynamic;

namespace Services.Contracts
{
    public interface IDataShaper<T>
    {
        IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, String fieldsString);
        ShapedEntity ShapeData(T entity, String fieldsString);
    }
}