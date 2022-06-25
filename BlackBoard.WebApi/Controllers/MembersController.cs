using BlackBoard.WebApi.Extensions;
using BlackBoard.WebApi.Intrerface;
using BlackBoard.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BlackBoard.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : BaseController
    {
        private readonly IMemberService _memberService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="memberService"></param>
        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        /// <summary>
        /// Get Member data as list
        /// </summary>
        /// <returns>Return Venue data as list</returns>
        [HttpGet]
        public async Task<IActionResult> Listing()
        {
            var res = await _memberService.Listing();
            return Ok(res);
            //return CreateResponse("Success", HttpStatusCode.OK, res);
        }

        /// <summary>
        /// Create Member
        /// </summary>
        /// <param name="member">Member member</param>
        /// <returns>Returns the response message</returns>
        [HttpPost]
        public async Task<IActionResult> Post(Member member)
        {
            var res = await _memberService.Create(member);
            return Ok(res);
        }

        /// <summary>
        /// Update Member
        /// </summary>
        /// <param name="id">Int16 id</param>
        /// <param name="member">Member member</param>
        /// <returns>Returns the response message</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Member member)
        {
            var res = await _memberService.Update(id, member);
            return Ok(res);
        }

        /// <summary>
        /// Delete Member by id
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>Returns the response message</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _memberService.Delete(id);
            return Ok(res);
        }
    }
}
