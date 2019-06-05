using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplicationFirst.DAO.Interfaces
{
    interface IDataAccessObject<T> where T: class
    {

            IEnumerable<T> GetAll();

            T GetById(int id);

            //void Insert(T entity);

            //void Update(T entity);

            //void DeleteById(int id);
    }
}
