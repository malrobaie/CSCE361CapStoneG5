-- CSCE 361
-- Group 5
-- Shopping Cart Database

drop table if exists CartProduct;
drop table if exists Product;
drop table if exists CreditCard;
drop table if exists Cart;
drop table if exists Customer;
drop table if exists Address;
drop table if exists Country;
drop table if exists State;
drop table if exists Sale;


-- This table models a state/province
create table State (
    stateId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    state varchar(255) NOT NULL UNIQUE
);

-- This table models a country
create table Country (
    countryId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    country varchar(255) NOT NULL UNIQUE
);

-- This table models an address
create table Address (
    addressId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    street varchar(255) NOT NULL,
    city varchar(255) NOT NULL,
    zipCode varchar(255) NOT NULL
);

-- Add in foreign key references
alter table Address
    add stateId int REFERENCES State(stateId);

alter table Address
    add countryId int REFERENCES Country(countryId);

-- This table models a customer
create table Customer (
    customerId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    lastName varchar(255) NOT NULL,
    firstName varchar(255) NOT NULL,
    email varchar(255) NOT NULL UNIQUE
);

alter table Customer
    add addressId int REFERENCES Address(addressId);

-- This table models a credit card a customer would use
create table CreditCard (
    creditId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    creditName varchar(255) NOT NULL,
    creditType varchar(255) NOT NULL,
    creditNumber float NOT NULL UNIQUE,
    cvc int NOT NULL,
    expDate date NOT NULL
);

-- Add in foreign key reference
alter table CreditCard 
    add customerId int REFERENCES Customer(customerId);


-- This table models a product 
create table Product (
    productId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    productName varchar(255) NOT NULL,
    productCategory varchar(255) NOT NULL,
    productPrice float NOT NULL,
    manufacturerName varchar(255) NOT NULL,
    productDescription nvarchar(1000) NOT NULL,
    productHeight float NOT NULL,
    productWidth float NOT NULL,
    productDepth float NOT NULL,
    productSKU varchar(255) NOT NULL UNIQUE
    -- TODO: add images
);

-- This table is a join table between products and a user's shopping cart
create table CartProduct (
    cartProductId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    quantity int NOT NULL
);

-- Add in foreign key references
alter table CartProduct
    add customerId int REFERENCES Customer(customerId);

alter table CartProduct
    add productId int REFERENCES Product(productId);

-- This table models a sale on different products
create table Sale(
    saleId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    startDate date NOT NULL,
    endDate date NOT NULL,
    discount float NOT NULL,
    productCategory varchar(255) NOT NULL
);

GO
