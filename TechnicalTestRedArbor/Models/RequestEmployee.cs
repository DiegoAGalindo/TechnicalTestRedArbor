using System;
using System.ComponentModel.DataAnnotations;

namespace TechnicalTestRedArbor.Models
{
    [Serializable]
    public class RequestEmployee
    {
        [Required(ErrorMessage = "CompanyId required")]
        [Range(1, int.MaxValue)]
        public int CompanyId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime DeletedOn { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Fax { get; set; }

        [Required]
        public DateTime LastLogin { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int PortalId { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public DateTime UpdatedOn { get; set; }

        [Required]
        public string Username { get; set; }
    }
}