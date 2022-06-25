using System;
using System.ComponentModel.DataAnnotations;

namespace BlackBoard.WebApi.Models
{
    /// <summary>
    /// Member Model Class
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Member Id
        /// </summary>
        [Required(ErrorMessage = "Id is required!")]
        public int ID { get; set; }

        /// <summary>
        /// Member First Name
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "First name should not be more than 50 character!")]
        public string FirstName { get; set; }

        /// <summary>
        /// Member Middle Name
        /// </summary>
        [Required]
        [StringLength(30, ErrorMessage = "Middle name should not be more than 30 character!")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Member Last Name
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "Last name should not be more than 50 character!")]
        public string LastName { get; set; }

        /// <summary>
        /// Member gender
        /// </summary>
        [Required(ErrorMessage = "Gender is required, could be Male or Female!")]
        public string Gender { get; set; }

        /// <summary>
        /// Member Age
        /// </summary>
        [Required(ErrorMessage = "Age is required, could be between 1 to 70!")]
        [Range(0, 70)]
        public int Age { get; set; }

        /// <summary>
        /// To check whether member is deleted or not
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Member creation date
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Member updation date
        /// </summary>
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
