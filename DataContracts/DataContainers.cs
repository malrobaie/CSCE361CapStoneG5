namespace DataContainers
{
    public class Customer
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Password {get; set; }

        public string Email {get; set; }
        
        public Address Address {get; set; }
        
        public List<CreditCard>? paymentMethods {get; set; }
        
        public Dictionary<Product, int>? Cart {get; set; }
    }

    public class Address
    { 
        public string Street {get; set; }

        public string City {get; set; }

        public string State {get; set; }

        public string ZipCode {get; set; }

        public string Country {get; set; }
    }

    public class Product
    {
        public string Name {get; set; }

        public String Image {get; set; }

        public double Price {get; set; }

        public string? Description {get; set; }

        public string? ManufacturerInfo {get; set; }

        public double Depth {get; set; }

        public double Height {get; set; }

        public double Width {get; set; }

        public string? SKU {get; set; }

        public string? Category {get; set; }

    }

    public class Sale
    {
        
        public int? SaleId {get; set; }

        public double Discount {get; set; }

        public string? Category {get; set; }
       
        public DateTime StartDate {get; set; }

        public DateTime EndDate {get; set; }
    }

    public class CreditCard
    {
        public string CreditName {get; set; }
        
        public string CreditType {get; set;}
        
        public string ExperationDate {get; set; }

        public double CreditNumber {get; set; }

        public int? CVV {get; set;}

    }
}