using Microsoft.AspNetCore.Identity;

namespace DataContainers
{

    public class Address
    {
        public int Number {get; set; }

        public string Street {get; set; }

        public string City {get; set; }

        public string State {get; set; }

        public string ZipCode {get; set; }

        public string? Country {get; set; }
    }

    public class Order
    {
        public int OrderId {get; set; }

        public List<Product>? Products {get; set; }

        public DateOnly Date {get; set;}
    }

    public class Product
    {
        public int ProductId {get; set; }

        public string Name {get; set; }

        public string? Description {get; set; }

        public string? ManufacturerInfo {get; set; }

        public double? Weight {get; set; }

        public double? Rating {get; set; }

        public Dimensions? Dimentions {get; set; }

        public string? SKU {get; set; }

        public string? Category {get; set; }

        public List<string>? Images {get; set; }

        public Sale? Sale {get; set; }

    }

    public class Dimensions
    {
        public double Length {get; set; }

        public double Height {get; set; }

        public double Width {get; set; }
    }

    public class Sale
    {
        public int SaleId {get; set; }

        public double? DiscountAmount {get; set; }

        public double? DiscountPercent {get; set; }

        public string? Category {get; set; }

        public DateOnly StartDate {get; set; }

        public DateOnly EndDate {get; set; }

        public List<Product>? Products {get; set; }
    }
    
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public long CustomerId {get; set; }

        [PersonalData]
        public string Name {get; set; }

        [PersonalData]
        public string Email {get; set; }
        
        [PersonalData]
        public string? Phone {get; set; }
        
        [PersonalData]
        public Address? Address {get; set; }
        
        [PersonalData]
        public int? CreditCard {get; set; }
        
        [PersonalData]
        public List<Order>? OrderHistory {get; set; }
        
        [PersonalData]
        public List<Product>? Cart {get; set; }
    }
}