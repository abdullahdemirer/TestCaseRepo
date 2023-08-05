using Business.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        List<PersonelDto> GetAll(int? departmentId, DateTime? startDate, int? personelId);
        IResult AddPersonel(Personel personel);
        IResult UpdatePersonel(Personel personel);
        IResult DeletePersonel(int personelId);

    }
}
