using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Mappers
{
    public interface IMapper<T, U>
                     where T : BaseEntity
                     where U : IViewModel
    {
        public T ToModel(U ViewModel);
        public List<T> ToModel(List<U> ViewModel);
        public U ToViewModel(T Model);
        public List<U> ToViewModel(List<T> Model);
    }

 
}
