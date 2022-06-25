using BlackBoard.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlackBoard.WebApi.Extensions
{
    /// <summary>
    /// Base Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseController()
        {

        }

        /// <summary>
        /// Create Response
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="msg">string msg</param>
        /// <param name="statusCode">HttpStatusCode statusCode</param>
        /// <param name="data">T data</param>
        /// <returns></returns>
        public IActionResult CreateResponse<T>(string msg, HttpStatusCode statusCode, T data)
        {
            return Ok(new ApiResponse<T>()
            {
                Message = msg,
                HttpStatus = statusCode,
                Data = data
            });
        }
    }
}
