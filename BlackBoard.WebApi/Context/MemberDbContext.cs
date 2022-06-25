using BlackBoard.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackBoard.WebApi.Context
{
    /// <summary>
    /// Member Db Context
    /// </summary>
    public class MemberDbContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public MemberDbContext(DbContextOptions<MemberDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Member DB Set
        /// </summary>
        public DbSet<Member> Member { get; set; }
    }
}
