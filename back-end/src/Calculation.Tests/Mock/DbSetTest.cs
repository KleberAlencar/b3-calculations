using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Calculation.Tests.Mock
{
    public class DbSetTest<T> : DbSet<T>, IQueryable, IEnumerable<T>
        where T : class
    {
        ObservableCollection<T> _data;
        IQueryable _query;

        public override IEntityType EntityType { get; }

        public DbSetTest()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }

        public override EntityEntry<T> Add(T item)
        {
            _data.Add(item);
            var entity = base.Attach(item);
            return entity;
        }
    }
}