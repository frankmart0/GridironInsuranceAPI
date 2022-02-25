using System.ComponentModel.DataAnnotations;

namespace GridironInsuranceAPI.Models
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int InsuredValueAmount { get; set; }

        public int CalcRate(Address address)
        {
            if (address.State == "FL")
            {
                return InsuredValueAmount = Convert.ToInt32(250000 * 0.15 / 100);
            }
            return InsuredValueAmount = Convert.ToInt32(250000 * 0.17 / 100);
        }
    }
}
