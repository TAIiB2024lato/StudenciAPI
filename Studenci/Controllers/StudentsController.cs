using Microsoft.AspNetCore.Mvc;
using Studenci.BBL;
using Studenci.DTOs;

namespace Studenci.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        readonly IService _service;
        public StudentsController(IService service) 
        {
            _service = service; 
        }

        [HttpGet]
        public IEnumerable<StudentResponseDTo> Get([FromQuery] PaginationDTO pagination)
        {
            return this._service.GetStudents(pagination);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._service.DeleteStudent(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentRequestDTO studentRequestDTO)
        {
            this._service.PutStudent(id, studentRequestDTO);
        }

        [HttpPost]
        public void Post([FromBody] StudentRequestDTO studentRequestDTO)
        {
            this._service.PostStudent(studentRequestDTO);
        }
    }
}
