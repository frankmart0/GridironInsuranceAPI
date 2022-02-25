using System.ComponentModel.DataAnnotations;

namespace GridironInsuranceAPI.Dtos
{
    public class InsuredCreateDto
    {
        [Required]
        [StringLength(20)]
        public string? FirstName { get; set; } 
        [Required]
        [StringLength(20)]
        public string? LastName { get; set; } 
        [Required]
        public DateTime? EffectiveDate { get; set; } 
        [Required]
        public string? Street { get; set; } 
        [Required]
        public string? City { get; set; } 
        [Required]
        public string? ZipCode { get; set; } 
        [Required]
        public string? State { get; set; } 
        [Required]
        public int InsuredValueAmount { get; set; }
    }
}

