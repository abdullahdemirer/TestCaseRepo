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
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;

        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }
        public IResult AddPersonel(Personel personel)
        {
            try
            {
                _personelDal.Add(personel);

                return new OperationResult(true, "Personel Eklendi");

            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }
        }

        public IResult DeletePersonel(int personelId)
        {
            try
            {
                _personelDal.Delete(personelId);

                return new OperationResult(true, "Personel Silindi");

            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }
        }

        public List<PersonelDto> GetAll(int? departmentId, DateTime? startDate, int? personelId)
        {
            return _personelDal.GetAll(departmentId, startDate, personelId);
        }

        public IResult UpdatePersonel(Personel personel)
        {
            try
            {
                _personelDal.Update(personel);

                return new OperationResult(true, "Personel Güncellendi.");

            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }
        }
    }
}
