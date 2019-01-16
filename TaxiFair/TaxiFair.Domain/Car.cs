namespace TaxiFair.Domain
{
    public class Car
    {
        public Car(string license,string driverName,
                   string ownerName,string companyName)
        {
            License = license;
            DriverName = driverName;
            OwnerName = ownerName;
            CompanyName = companyName;
        }

        public string License { get; }
        public string DriverName { get; }
        public string OwnerName { get; }
        public string CompanyName { get; }
    }
}
