using Business.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        List<Department> GetAll(int? departmentId);
        IResult AddDepartment(Department department);
        IResult UpdateDepartment(Department department);
        IResult DeleteDepartment(int departmentId);
    }
}
