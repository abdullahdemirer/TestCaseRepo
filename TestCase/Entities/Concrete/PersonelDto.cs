using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PersonelDto
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string PersonelName { get; set; }
        public string PersonelSurname { get; set; }
        public int Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Mail { get; set; }
        public string Gender { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string? HomePhoneNumber { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

    }
}
