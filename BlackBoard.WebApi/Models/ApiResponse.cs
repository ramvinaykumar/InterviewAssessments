using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlackBoard.WebApi.Models
{
    /// <summary>
    /// ApiResponse Model
    /// </summary>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// HttpStatus
        /// </summary>
        public HttpStatusCode HttpStatus { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }
    }
}
