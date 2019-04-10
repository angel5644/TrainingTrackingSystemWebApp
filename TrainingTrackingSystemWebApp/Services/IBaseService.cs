using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackingSystemWebApp.Utils;

namespace TrainingTrackingSystemWebApp.Services
{
    public interface IBaseService<T> where T:class
    {
        
        Task<T> Get(string endPoint, int Id);
        Task<T> Put(string endPoint, T dtoObject);
        Task<List<T>> GetMany(string endPoint);
        Task<T> Post(string endPoint, T dtoObject);
        Task<bool> Delete(string endPoint, int id);
    }
}
