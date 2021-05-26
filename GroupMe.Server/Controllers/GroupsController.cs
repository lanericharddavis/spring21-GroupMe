using System.Collections.Generic;
using GroupMe.Models;
using GroupMe.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroupMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly GroupsService _gs;

        public GroupsController(GroupsService gs)
        {
            _gs = gs;
        }

        [HttpGet]
        public ActionResult<List<Group>> Get()
        {
            try
            {
                List<Group> groups = _gs.GetGroups();
                return Ok(groups);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}