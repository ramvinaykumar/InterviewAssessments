using BlackBoard.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackBoard.WebApi.Intrerface
{
    /// <summary>
    /// Member service interface
    /// </summary>
    public interface IMemberService
    {
        /// <summary>
        /// Get member data as list
        /// </summary>
        /// <returns>Return member data as list</returns>
        Task<List<Member>> Listing();

        /// <summary>
        /// Create new member
        /// </summary>
        /// <param name="member">Member member</param>
        /// <returns>Returns the response message</returns>
        Task<string> Create(Member member);

        /// <summary>
        /// Update the existing member data
        /// </summary>
        ///  <param name="id">Int16 id</param>
        /// <param name="member">Member member</param>
        /// <returns>Returns the response message</returns>
        Task<string> Update(int id, Member member);

        /// <summary>
        /// Delete member by ID
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>Returns the response message</returns>
        Task<string> Delete(int id);
    }
}
