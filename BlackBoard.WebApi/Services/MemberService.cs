using BlackBoard.WebApi.Context;
using BlackBoard.WebApi.Intrerface;
using BlackBoard.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBoard.WebApi.Services
{
    /// <summary>
    /// Member Service
    /// </summary>
    public class MemberService : IMemberService
    {
        /// <summary>
        /// MemberDbContext object
        /// </summary>
        private readonly MemberDbContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">MemberDbContext dbContext</param>
        public MemberService(MemberDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Create member
        /// </summary>
        /// <param name="member">Member member</param>
        /// <returns>Returns the response message</returns>
        public async Task<string> Create(Member member)
        {
            string strMessage = string.Empty;
            try
            {
                var dataExists = await _dbContext.Member.FirstOrDefaultAsync(x => x.FirstName.ToLower() == member.FirstName.ToLower()
                                                && x.LastName.ToLower() == member.LastName.ToLower() && x.IsDeleted == false);
                if (dataExists == null)
                {
                    await _dbContext.Member.AddAsync(new Member
                    {
                        FirstName = member.FirstName,
                        MiddleName = member.MiddleName,
                        LastName = member.LastName,
                        Age = member.Age,
                        Gender = member.Gender,
                        IsDeleted = false,
                        CreatedDate = DateTime.UtcNow
                    });
                    var status = await _dbContext.SaveChangesAsync();
                    if (status == 1)
                    {
                        return strMessage = "Member Created Successfully.";
                    }
                    else
                    {
                        return strMessage = "Something Went Wrong!";
                    }
                }
                else
                {
                    return strMessage = "Member:- " + dataExists.FirstName + " already exist.";
                }
            }
            catch (Exception ex)
            {
                return strMessage = "Something Went Wrong!" + ex.Message;
            }
        }

        /// <summary>
        /// Delete Member by ID
        /// </summary>
        /// <param name="id">Int16 id</param>
        /// <returns>Returns the response message</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<string> Delete(int id)
        {
            string strMessage = string.Empty;
            try
            {
                if (await _dbContext.Member.AnyAsync(x => x.ID == id && x.IsDeleted == false))
                {
                    var member = await _dbContext.Member.Where(x => x.ID == id && x.IsDeleted == false).FirstOrDefaultAsync();
                    if (member != null)
                    {
                        _dbContext.Member.Remove(member);
                        var status = await _dbContext.SaveChangesAsync();
                        if (status == 1)
                        {
                            return strMessage = "Member Deleted Successfully.";
                        }
                        else
                        {
                            return strMessage = "Something Went Wrong!";
                        }
                    }
                    else
                    {
                        return strMessage = "Member Doesn't exist";
                    }
                }
                else
                {
                    return strMessage = "Member Doesn't exist";
                }
            }
            catch (Exception ex)
            {
                return strMessage = "Something went wrong" + ex.Message;
            }
        }

        /// <summary>
        /// Get Member data as list
        /// </summary>
        /// <returns>Return Member data as list</returns>
        public async Task<List<Member>> Listing()
        {
            List<Member> listing = new List<Member>();
            try
            {
                listing = await _dbContext.Member.Where(x => x.IsDeleted == false).ToListAsync();
            }
            catch (Exception)
            {
                listing = new List<Member>();
            }
            return listing;
        }

        /// <summary>
        /// Update member
        /// </summary>
        /// <param name="id">Int16 id</param>
        /// <param name="member">Member member</param>
        /// <returns>Returns the response message</returns>
        public async Task<string> Update(int id, Member member)
        {
            string strMessage = string.Empty;
            try
            {
                if (await _dbContext.Member.AnyAsync(x => x.ID == id && x.IsDeleted == false))
                {
                    var updateData = await _dbContext.Member.Where(x => x.ID == id && x.IsDeleted == false).FirstOrDefaultAsync();
                    if (updateData != null)
                    {
                        updateData.FirstName = member.FirstName;
                        updateData.MiddleName = member.MiddleName;
                        updateData.LastName = member.LastName;
                        updateData.Age = member.Age;
                        updateData.Gender = member.Gender;
                        updateData.UpdatedDate = DateTime.UtcNow;
                        updateData.IsDeleted = false;
                    }

                    var status = await _dbContext.SaveChangesAsync();
                    if (status == 1)
                    {
                        return strMessage = "Member Updated Successfully.";
                    }
                    else
                    {
                        return strMessage = "Something went wrong.";
                    }
                }
                else
                {
                    return strMessage = "Member Doesn't exist.";
                }
            }
            catch (Exception ex)
            {
                return strMessage = "Something Went Wrong!" + ex.Message;
            }
        }
    }
}
