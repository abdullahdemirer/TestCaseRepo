using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDepartmentDal
    {
        List<Department> GetAll(int? departmentId);

        void Add(Department department);

        void Update(Department department);

        void Delete(int departmentId);

    }
}
