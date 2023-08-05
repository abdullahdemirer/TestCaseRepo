using Business.Abstract;
using Business.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentlDal;

        public DepartmentManager(IDepartmentDal departmentlDal)
        {
            _departmentlDal = departmentlDal;
        }

        public IResult AddDepartment(Department department)
        {
            try
            {
                _departmentlDal.Add(department);

                return new OperationResult(true, "Departman Eklendi");

            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }
        }

        public IResult DeleteDepartment(int departmentId)
        {
            try
            {
                _departmentlDal.Delete(departmentId);

                return new OperationResult(true, "Departman Silindi");

            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }
        }

        public List<Department> GetAll(int? departmentId)
        {
            return _departmentlDal.GetAll(departmentId);
        }

        public IResult UpdateDepartment(Department department)
        {
            try
            {
                _departmentlDal.Update(department);

                return new OperationResult(true, "Departman Güncellendi");

            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }
        }
    }
}
