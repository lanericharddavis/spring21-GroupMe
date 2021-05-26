using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using GroupMe.Models;
using GroupMe.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroupMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupMembersController : ControllerBase
    {
        private readonly GroupMembersService _gms;

        public GroupMembersController(GroupMembersService gms)
        {
            _gms = gms;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GroupMember>> CreateAsync([FromBody] GroupMember gm)
        {
            try
            {
                // REVIEW enforce the current user context
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                gm.AccountId = userInfo.Id;
                var newGm = _gms.CreateGroupMember(gm);
                return Ok(newGm);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}