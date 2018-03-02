using System.Collections.Generic;

namespace Core.Infra
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetData();
        void SaveChanges(IEnumerable<T> dataToSave);
    }
}
