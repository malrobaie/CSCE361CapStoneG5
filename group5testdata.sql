-- CSCE 361
-- Group 5
-- Insertion of test data

-- Insert test states
insert into State (state) values ("Illinois");
insert into State (state) values ("Nebraska");
insert into State (state) values ("Wisconsin");
insert into State (state) values ("Missouri");
insert into State (state) values ("Kansas");

-- Insert test countries
insert into Country (country) values ("US");

-- Insert test addresses
insert into Address(street,city,zipCode,stateId,countryId) values ("23 Lotheville Road","Lincoln","68524",1,1);
insert into Address(street,city,zipCode,stateId,countryId) values ("56 Oxford Avenue","Ogden","84403",2,1);
insert into Address(street,city,zipCode,stateId,countryId) values ("94 Pleasure Street","New Castle","16107",3,1);
insert into Address(street,city,zipCode,stateId,countryId) values ("660 Rowland Lane","Spokane","99260",4,1);
insert into Address(street,city,zipCode,stateId,countryId) values ("1099 Barnett Avenue","Columbus", "43204", 5, 1);

-- Insert test customer
insert into Customer(lastName, firstName, addressId) values ("Shrubsall", "Trudey", 1);
insert into Customer(lastName, firstName, addressId) values ("Blakeston", "Millard", 2);
insert into Customer(lastName, firstName, addressId) values ("Dellenbrook", "Bobine", 3);
insert into Customer(lastName, firstName, addressId) values ("Arondel", "Nick", 4);
insert into Customer(lastName, firstName, addressId) values ("Abbey", "Jennilee", 5);

-- Insert test cart
insert into Cart(customerId) values (1);
insert into Cart(customerId) values (2);
insert into Cart(customerId) values (3);
insert into Cart(customerId) values (4);
insert into Cart(customerId) values (5);

-- Insert test email
insert into Email(email, customerId) values ("tshrubsall2@sitemeter.com", 1)
insert into Email(email, customerId) values ("mblakeston@businessinsider.com", 2);
insert into Email(email, customerId) values ("dellenbrook3@yahoo.com", 3);
insert into Email(email, customerId) values ("bm@ibm.com", 4);
insert into Email(email, customerId) values ("jennileea@cse.unl.edu", 5);
insert into Email(email, customerId) values ("jenileea@unl.edu", 5);

-- Insert test credit card
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ("Trudey's American Express Card", "amex", "372301652498256", "342", "2025-12-09", 1);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ("Millard's Master Card", "mastercard", "5417395333782837", "933", "2023-08-11", 2);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ("Bobine's Visa", "visa", "4041597035849", "823", "2029-02-14", 3);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ("Bobine's American Express", "amex", "347816873257886", "909", "2023-03-11", 3);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ("Bobine's Maestro", "maestro", "6763244358821807125", "421", "2024-01-07", 3);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ("Nick's Visa", "visa", "4041372752741", "421", "2025-07-01", 4);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ("Nick's Master Card", "mastercard", "5421386902517997", "324", "2026-09-22", 4);
insert into CreditCard(creditName, creditType, creditNumber, cvc, expDate, customerId) values ("Jennilee's Master Card", "mastercard", "5007667711850105", "780", "2025-11-09", 5);

-- Insert test Product
insert into Product(productName, productCategory, productPrice, manufacturerName, productDescription, productHeight, productWidth, productDepth, productSKU) values ("Adidas Superstar Shoes", "Fashion", 74.99, "Adidas", "Originally made for basketball courts in the '70s. Celebrated by hip hop royalty in the '80s. The adidas Superstar shoe is now a lifestyle staple for streetwear enthusiasts. 
The world-famous shell toe feature remains, providing style and protection. Just like it did on the B-ball courts back in the day. 
Now, whether at a festival or walking in the street you can enjoy yourself without the fear of being stepped on. 
The serrated 3-Stripes detail and adidas Superstar box logo adds OG authenticity to your look.", 12, 3, 2, "tqoj1z");

insert into Product(productName, productCategory, productPrice, manufacturerName, productDescription, productHeight, productWidth, productDepth, productSKU) values ("Nintendo Switch", "Tech", 299.99, "Nintendo", "Nintendo Switch is designed to fit your life, transforming from home console to portable system in a snap.", 
4.01, 9.4, 0.55, "p3llq6");
insert into Product(productName, productCategory, productPrice, manufacturerName, productDescription, productHeight, productWidth, productDepth, productSKU) values ("Prada 55WS", "Fashion", 369.99, "EssilorLuxottica", "Polarized universal fit sunglasses", 2, 7, 0.1, "ngadg8");
insert into Product(productName, productCategory, productPrice, manufacturerName, productDescription, productHeight, productWidth, productDepth, productSKU) values ("Razer Blade 14", "Trending", 1999.99, "Razer", "
Our most powerful 14-inch gaming laptop is back and more powerful than ever before. The new Razer Blade 14 combines the latest AMD️ Ryzen™ 9 6900HX processor, 
available NVIDIA® GeForce RTX™ Ti graphics, and DDR5 4800MHz memory to bring you the ultimate 14” gaming laptop for uncompromising performance and portability.",
12.59, 8.66, 0.66, "8tcnnw");