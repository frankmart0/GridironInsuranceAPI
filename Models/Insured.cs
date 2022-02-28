using System.ComponentModel.DataAnnotations;
using System.Globalization;

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
        public DateTime EffectiveDate { get; set; } = new DateTime(); 
        public int AddressId { get; set; }
        [Required]
        public Address? Address { get; set; }
        public int Rateid { get; set; }
        [Required]
        public Rate? Rate { get; set; }

        public int RateValue
        {
            get
            {
                return RateValue;
            }

            set

            {
                if (Address?.State == "FL")
                {
                    RateValue = Convert.ToInt32(250000 * 0.15 / 100);
                }
                else
                {
                    RateValue = Convert.ToInt32(250000 * 0.17 / 100);
                }
            }

        }

    }
}

