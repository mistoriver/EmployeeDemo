use master;

if DB_ID('Employee_TestDB') is not null 
	drop database Employee_TestDB;

create database Employee_TestDB;

use Employee_TestDB;

create table Employees 
(
	employee_id int primary key not null,
	employee_name varchar(50) not null,
	is_male bit not null,
	birth_date date not null,
	constraint unique_emps unique (employee_name, birth_date),
	constraint age_check check ((year(getdate()) - year(birth_date)) between 14 and 100)
);
create table Employee_Documents 
(
	employee_id int not null,
	doc_id int primary key not null,
	series_number varchar(10) not null,
	doc_type int not null,
	from_date date not null,
	by_date varchar(100) not null,	
	constraint unique_doctype_and_seriesnumbers unique (series_number, doc_type)
);
create table Doc_Types
(
	doc_type int primary key not null,
	doc_name varchar(50) not null
);
create table Employee_Phones
(
	phone_id int primary key not null,
	phone_number varchar(12) not null,
	employee_id int not null,
	phone_type int not null
);
create table Phone_Types
(
	phone_type int primary key not null,
	phone_type_name varchar(50) not null
);
insert into Employees values (1, 'Иван Иванов', 1, dateadd(year, -20, getdate()));
insert into Employees values (2, 'Пётр Петров', 1, dateadd(year, -30, getdate()));
insert into Employees values (3, 'Ивания Петрова', 0, dateadd(year, -40, getdate()));

insert into Doc_Types values (0, 'Паспорт РФ');
insert into Doc_Types values (1, 'Паспорт моряка');

insert into Employee_Documents values (1, 1, '1234123456', 2, getdate(), getdate());
insert into Employee_Documents values (2, 2, '4321654321', 1, getdate(), getdate());
insert into Employee_Documents values (3, 3, '1234432100', 1, getdate(), getdate());

insert into Phone_Types values (0, 'Домашний');
insert into Phone_Types values (1, 'Мобильный');

insert into Employee_Phones values ('9000000000',1,2);
insert into Employee_Phones values ('9000000001',2,1);
insert into Employee_Phones values ('9000000002',3,2);

/*update Employee_Phones set employee_id = 9, phone_type = 1 where phone_number= 9000000000;

select * from Employee_Phones where phone_number= 9000000000;*/