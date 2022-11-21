-- CSCE 361
-- Group 5
-- Insertion of test data

-- Insert test states
insert into State (state) values ('Illinois');
insert into State (state) values ('Nebraska');
insert into State (state) values ('Wisconsin');
insert into State (state) values ('Missouri');
insert into State (state) values ('Kansas');

-- Insert test countries
insert into Country (country) values ('US');

-- Insert test addresses
insert into Address(street,city,zipCode,stateId,countryId) values ('23 Lotheville Road','Lincoln','68524',1,1);
insert into Address(street,city,zipCode,stateId,countryId) values ('56 Oxford Avenue','Ogden','84403',2,1);
insert into Address(street,city,zipCode,stateId,countryId) values ('94 Pleasure Street','New Castle','16107',3,1);
insert into Address(street,city,zipCode,stateId,countryId) values ('660 Rowland Lane','Spokane','99260',4,1);
insert into Address(street,city,zipCode,stateId,countryId) values ('1099 Barnett Avenue','Columbus', '43204', 5, 1);

-- Insert test customer
insert into Customer(lastName, firstName, addressId) values ('Shrubsall', 'Trudey', 1);
insert into Customer(lastName, firstName, addressId) values ('Blakeston', 'Millard', 2);
insert into Customer(lastName, firstName, addressId) values ('Dellenbrook', 'Bobine', 3);
insert into Customer(lastName, firstName, addressId) values ('Arondel', 'Nick', 4);
insert into Customer(lastName, firstName, addressId) values ('Abbey', 'Jennilee', 5);

-- Insert test cart
insert into Cart(customerId) values (1);
insert into Cart(customerId) values (2);
insert into Cart(customerId) values (3);
insert into Cart(customerId) values (4);
insert into Cart(customerId) values (5);

-- Insert test email
insert into Email(email, customerId) values ('tshrubsall2@sitemeter.com', 1)
insert into Email(email, customerId) values ('mblakeston@businessinsider.com', 2);
insert into Email(email, customerId) values ('dellenbrook3@yahoo.com', 3);
insert into Email(email, customerId) values ('bm@ibm.com', 4);
insert into Email(email, customerId) values ('jennileea@cse.unl.edu', 5);
insert into Email(email, customerId) values ('jenileea@unl.edu', 5);

-- Insert test credit card
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ('Trudey''s American Express Card', 'amex', '372301652498256', '342', '2025-12-09', 1);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ('Millard''s Master Card', 'mastercard', '5417395333782837', '933', '2023-08-11', 2);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ('Bobine''s Visa', 'visa', '4041597035849', '823', '2029-02-14', 3);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ('Bobine''s American Express', 'amex', '347816873257886', '909', '2023-03-11', 3);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ('Bobine''s Maestro', 'maestro', '6763244358821807125', '421', '2024-01-07', 3);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ('Nick''s Visa', 'visa', '4041372752741', '543', '2025-07-01', 4);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ('Nick''s Master Card', 'mastercard', '5421386902517997', '324', '2026-09-22', 4);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ('Jennilee''s Master Card', 'mastercard', '5007667711850105', '780', '2025-11-09', 5);

-- Insert test product
insert into Product(productName, productCategory, productPrice, manufacturerName, productDescription, productHeight, productWidth, productDepth, productSKU) values ('Adidas Superstar Shoes', 'Fashion', 74.99, 'Adidas', 'Originally made for basketball courts in the ''70s. Celebrated by hip hop royalty in the ''80s.', 12, 3, 2, 'tqoj1z');
insert into Product(productName, productCategory, productPrice, manufacturerName, productDescription, productHeight, productWidth, productDepth, productSKU) values ('Nintendo Switch', 'Tech', 299.99, 'Nintendo', 'Nintendo Switch is designed to fit your life, transforming from home console to portable system in a snap.', 
4.01, 9.4, 0.55, 'p3llq6');
insert into Product(productName, productCategory, productPrice, manufacturerName, productDescription, productHeight, productWidth, productDepth, productSKU) values ('Prada 55WS', 'Fashion', 369.99, 'EssilorLuxottica', 'Polarized universal fit sunglasses', 2, 7, 0.1, 'ngadg8');
insert into Product(productName, productCategory, productPrice, manufacturerName, productDescription, productHeight, productWidth, productDepth, productSKU) values ('Razer Blade 14', 'Trending', 1999.99, 'Razer', 'Our most powerful 14-inch gaming laptop is back and more powerful than ever before.',
12.59, 8.66, 0.66, '8tcnnw');

-- Insert test products in a cart
insert into CartProduct(quantity, cartId, productId) values (3, 1, 1);
insert into CartProduct(quantity, cartId, productId) values (1, 1, 2);
insert into CartProduct(quantity, cartId, productId) values (1, 1, 4);
insert into CartProduct(quantity, cartId, productId) values (1, 2, 2);
insert into CartProduct(quantity, cartId, productId) values (1, 2, 1);
insert into CartProduct(quantity, cartId, productId) values (1, 3, 3);
insert into CartProduct(quantity, cartId, productId) values (5, 4, 2);
insert into CartProduct(quantity, cartId, productId) values (2, 4, 4);
insert into CartProduct(quantity, cartId, productId) values (1, 5, 1);

-- Insert test sales
insert into Sale(startDate, endDate, discount, productCategory) values ('2022-11-22', '2022-11-29', 0.4, 'Tech');