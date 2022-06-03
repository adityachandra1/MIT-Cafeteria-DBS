CREATE TABLE customers(
    cname VARCHAR(20),
    ph_no VARCHAR(10) PRIMARY KEY,
    city VARCHAR(10),
    street VARCHAR(20)
);
CREATE TABLE branch (
    branchID VARCHAR(20) PRIMARY KEY,
    bname VARCHAR(20),
    block VARCHAR(20)
);
CREATE TABLE menu_items (
    item_no INTEGER PRIMARY KEY,
    price INTEGER,
    stock INTEGER,
    item_name VARCHAR(20),
    available_in VARCHAR(20) REFERENCES branch(branchID)
);



CREATE TABLE employee (
    empID INTEGER PRIMARY KEY,
    empname VARCHAR(20),
    designation VARCHAR(20),
    DOB date,
    ph_no VARCHAR(10),
    works_in VARCHAR(20) REFERENCES branch(branchID)
);

CREATE TABLE Orders (
    ph_no VARCHAR(10) REFERENCES customers(ph_no),  
    item_no INTEGER REFERENCES menu_items(item_no),
    bill_amt INTEGER,
    payment_method VARCHAR(10)
);



insert into customers values ('Siddhant' , 9999444510 , 'Delhi' , 'Vasant Kunj');
insert into customers values ('Akshay' , 6888557769 , 'Pune' , 'sector 14');
insert into customers values ('Vinayak' , 7756698465 , 'Allahabad' , 'Vijaypur');
insert into customers values ('Aditya' , 9834263846 , 'Surat' , 'Rohini');
insert into customers values ('Anant' , 8920955668 , 'Delhi' , 'Vasant Vihar');
insert into customers values ('Piyush' , 9945055332 , 'Chandigarh' , 'sector 17');
insert into customers values ('Gautham' , 8860135103 , 'Manipal' , 'Block 15');
insert into customers values ('Parv' , 9113778005 , 'Bangalore' , 'turn road');
insert into customers values ('Akshit' , 7029991776 , 'Amritsar' , 'mahipalpur');
insert into customers values ('Karman' , 9555227368 , 'Delhi' , 'Delhi cantt'); 


insert into branch values ('A001' , 'No Hit n Run' , 'Block 14');
insert into branch values ('A002' , 'Janani' , 'Block 15');
insert into branch values ('A004' , 'Hi Kitchen' , 'AB5');
insert into branch values ('A005' , 'Apoorva' , 'AB3');
insert into branch values ('A003' , 'Manipal Fried Cafe' , 'SP');



insert into menu_items values (1 , 75 , 10 , 'Idli', 'A001'); 
insert into menu_items values (2 , 55 , 5 , 'Dosa', 'A001'); 
insert into menu_items values (3 , 40 , 7 , 'Vada', 'A002'); 
insert into menu_items values (4 , 90 , 2 , 'Pizza', 'A002'); 
insert into menu_items values (5 , 100, 4 , 'Burger', 'A003'); 
insert into menu_items values (6 , 50 , 6 , 'Sandwhich', 'A004'); 
insert into menu_items values (7 , 100, 2 , 'Noodles', 'A005'); 
insert into menu_items values (8 , 20 , 20 , 'Tea', 'A005'); 
insert into menu_items values (9 , 15, 16 , 'Coffee', 'A004');  
insert into menu_items values (10 , 30, 15 , 'Ice Lime', 'A003'); 



insert into employee values (1001,'Amit','Cashier',DATE '1989-12-07',8857775656,'A002');
insert into employee values (1002,'Rohan','Server',DATE '1997-11-27',6555378465,'A002');
insert into employee values (1003,'Yash','Waiter',DATE '1973-02-17',9943678436,'A002');
insert into employee values (1004,'Parth','Cleaner',DATE '2000-04-17',9834875726,'A001');
insert into employee values (1005,'Lavanya','Manager',DATE '1993-07-23',9910885775,'A001');
insert into employee values (1006,'Anshika','Clerk',DATE '1999-01-31',9036298374,'A004');
insert into employee values (1007,'Srishti','Cashier',DATE '1995-04-23',7872346432,'A004');
insert into employee values (1008,'Shavik','Waiter',DATE '1989-11-19',9993274326,'A003');
insert into employee values (1009,'Khushi','Server',DATE '1997-12-15',7898967868,'A003');
insert into employee values (1010,'Pavanaj','CEO',DATE '1987-03-28',7328746892,'A005');



insert into Orders values (9999444510 ,3,150,'Cash');
insert into Orders values (8920955668 ,5,100,'Cash');
insert into Orders values (6888557769 ,2,80,'UPI');
insert into Orders values (9834263846 ,5,90,'UPI');
insert into Orders values (7756698465 ,7,75,'Cash');
insert into Orders values (9945055332 ,10,30,'UPI');
insert into Orders values (9113778005 ,1,100,'UPI');
insert into Orders values (7029991776 ,8,110,'UPI');
insert into Orders values (9555227368 ,4,180,'Cash');
insert into Orders values (8860135103 ,1,70,'Cash');

select * from customers;
select * from branch;
select * from menu_items;
select * from employee;
select * from Orders;
