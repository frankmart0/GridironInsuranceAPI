namespace GridironInsuranceAPI.Dtos
{
    public class InsuredReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime EffectiveDate { get; set; } = new DateTime();
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int InsuredValueAmount { get; set; }

    }
}
