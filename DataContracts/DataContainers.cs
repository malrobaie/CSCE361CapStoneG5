using System.ComponentModel.DataAnnotations;

namespace DataContainers
{
    public class Customer
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Password {get; set; }

        public string Email {get; set; }
        
        public Address Address {get; set; }
        
        public List<CreditCard>? PaymentMethods {get; set; }
        
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

        public double Price {get; set; }

        public string? Description {get; set; }

        public string? ManufacturerInfo {get; set; }

        //public double? Weight {get; set; }

        //public double? Rating {get; set; }

        public Dimensions? Dimensions {get; set; }

        public string? SKU {get; set; }

        public string? Category {get; set; }

        //public List<string>? Images {get; set; }

        public Sale? Sale {get; set; }

    }

    public class Dimensions
    {
        public double Depth {get; set; }

        public double Height {get; set; }

        public double Width {get; set; }
    }

    public class Sale
    {
        //public double? DiscountAmount {get; set; }

        public double? DiscountPercent {get; set; }

        public string? Category {get; set; }

        public DateOnly StartDate {get; set; }

        public DateOnly EndDate {get; set; }

        //public List<Product>? Products {get; set; }
    }

    public class CreditCard
    {
        public string CreditName {get;}
        
        public string CreditType {get;}
        
        public DateOnly ExperationDate {get; set; }

        public CreditCardAttribute CreditNumber {get;}

        public int? CVV {get; set;}

    }
}