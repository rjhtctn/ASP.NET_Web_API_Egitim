using System.Dynamic;

namespace Services.Contracts
{
    public interface IDataShaper<T>
    {
        IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, String fieldsString);
        ExpandoObject ShapeData(T entity, String fieldsString);
    }
}