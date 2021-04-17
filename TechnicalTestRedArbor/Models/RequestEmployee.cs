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
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 20)]
        public string Fax { get; set; }

        [Required]
        public DateTime LastLogin { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string Password { get; set; }

        [Required]
        [Range(int.MinValue, int.MaxValue)]
        public int PortalId { get; set; }

        [Required]
        [Range(int.MinValue, int.MaxValue)]
        public int RoleId { get; set; }

        [Required]
        [Range(int.MinValue, int.MaxValue)]
        public int StatusId { get; set; }

        [Required]
        [StringLength(maximumLength: 20)]
        public string Telephone { get; set; }

        [Required]
        public DateTime UpdatedOn { get; set; }

        [Required]
        [StringLength(maximumLength: 20)]
        public string Username { get; set; }
    }
}