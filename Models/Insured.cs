using System.ComponentModel.DataAnnotations;

namespace GridironInsuranceAPI.Models
{
    public class Insured
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string? FirstName { get; set; } 
        [Required]
        [StringLength(20)]
        public string? LastName { get; set; } 
        [Required]
        public DateTime? EffectiveDate { get; set; }
        public int AddressId { get; set; }
        [Required]
        public Address? Address { get; set; }
        public int RateId { get; set; }
        [Required]
        public Rate? Rate { get; set; }
    }
}

