using System.ComponentModel.DataAnnotations;

namespace GridironInsuranceAPI.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string? Street { get; set; } 
        [Required]
        [StringLength(20)]
        public string? City { get; set; }
        [Required]
        [StringLength(5)]
        public string? ZipCode { get; set; } 
        [Required]
        [StringLength(2)]
        public string? State { get; set; } 
    }
}
