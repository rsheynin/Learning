namespace TaxiFair.Domain
{
    public class CompanyFee
    {
        public CompanyFee(string companyName,double fee)
        {
            CompanyName = companyName;
            Fee = fee;
        }

        public string CompanyName { get; }

        public double Fee { get; }
    }
}