using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BLL.Repositories
{
    interface IBaseMongoRepository<T, IDT>
    {
        T Create(T entity);
        List<T> All();

        T FindById(IDT id);

        void Remove(IDT id);

        void Update(T entity);
    }
}
