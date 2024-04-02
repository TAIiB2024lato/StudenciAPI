using Microsoft.AspNetCore.Mvc;
using Studenci.BBL;
using Studenci.DTOs;

namespace Studenci.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        readonly IService _service;
        public GroupsController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<GroupResponseDTO> Get([FromQuery] PaginationDTO pagination)
        {
            return this._service.GetGroups(pagination);
        }
    }
}
