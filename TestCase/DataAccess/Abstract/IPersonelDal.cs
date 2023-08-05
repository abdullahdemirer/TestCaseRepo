using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPersonelDal
    {
        List<PersonelDto> GetAll(int? departmentId, DateTime? startDate, int? personelId);

        void Add(Personel personel);

        void Update(Personel personel);

        void Delete(int personelId);

    }
}
