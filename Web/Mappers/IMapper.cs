using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Mappers
{
    public interface IMapper<T, U, V>
                     where T : BaseEntity
                     where U : IViewModel // Basic ViewModel (Edit/Create)
                     where V : IViewModel // ListViewModel
    {
        public T ToModel(V ViewModel);
        public T ToModel(U ViewModel);
        public List<T> ToModel(List<V> ViewModel);
        public U ToViewModel(T Model);
        public List<U> ToViewModel(List<T> Model);
        public V ToListViewModel(T Model);
        public List<V> ToListViewModel(List<T> Model);
    }

 
}
