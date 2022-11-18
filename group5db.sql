-- CSCE 361
-- Group 5
-- Shopping Cart Database

drop table if exists CartProduct;
drop table if exists Product;
drop table if exists Cart;
drop table if exists Email;
drop table if exists PaymentMethod;
drop table if exists Customer;
drop table if exists Email;
drop table if exists CreditCard;
drop table if exists Address;
drop table if exists Country;
drop table if exists State;


-- This table models a state/province
create table State (
    stateId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    state varchar(255) NOT NULL,
);

-- This table models a country
create table Country (
    countryId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    country varchar(255) NOT NULL,
);

-- This table models an address
create table Address (
    addressId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    street varchar(255) NOT NULL UNIQUE,
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
);

alter table Customer
    add addressId int REFERENCES Address(addressId);

-- This table models a customer's shopping cart
create table Cart(
    cartId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    -- TODO: fill out cart table
);

-- Add in foreign key reference
alter table Cart 
    add customerId int REFERENCES Customer(customerId);

-- This table models an email a customer would have
create table Email (
    emailId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    email varchar(255),
);

-- Add in foreign key reference
alter table Email
    add customerId int REFERENCES Customer(customerId);

-- This table models a credit card a customer would use
create table CreditCard (
    creditId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    creditName varchar(255) NOT NULL,
    creditType varchar(255) NOT NULL,
    creditNumber float NOT NULL UNIQUE,
    cvc int NOT NULL UNIQUE,
    expDate date NOT NULL,
);

-- Add in foreign key reference
alter table CreditCard 
    add customerId int REFERENCES Customer(customerId);


GO