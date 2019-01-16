namespace TaxiFair.Domain
{
    public class TaxiFairDto
    {
        public TaxiFairDto(double rate, double companyFee, double distance)
        {
            Rate = rate;
            CompanyFee = companyFee;
            Distance = distance;
        }

        public double Rate { get; }
        public double CompanyFee { get; }
        public double Distance { get; }
    }
}