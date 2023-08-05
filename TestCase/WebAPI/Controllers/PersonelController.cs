using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        IPersonelService _personelService;

        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        [HttpGet("GetAllPersonel")]
        public List<PersonelDto> GetAllPersonel(int? departmentId, DateTime? startDate, int? personelId)
        {
            return _personelService.GetAll(departmentId, startDate, personelId);
        }


        [HttpPost("AddPersonel")]
        public IActionResult AddPersonel(Personel personel)
        {
            var result = _personelService.AddPersonel(personel);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("UpdatePersonel")]
        public IActionResult UpdatePersonel(Personel personel)
        {
            var result = _personelService.UpdatePersonel(personel);
            
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("DeletePersonel")]
        public IActionResult DeletePersonel(int personelId)
        {
            var result = _personelService.DeletePersonel(personelId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
