using System.ComponentModel.DataAnnotations;

namespace GridironInsuranceAPI.Dtos
{
    public class InsuredUpdateDto
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime EffectiveDate { get; set; } = new DateTime();
        [Required]
        public string Street { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string ZipCode { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = string.Empty;
        [Required]
        public int InsuredValueAmount { get; set; }
    }
}
