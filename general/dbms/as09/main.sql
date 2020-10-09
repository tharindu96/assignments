-- 05

drop database if exists assignment9;

create database assignment9;

use assignment9;

-- 06

create table department (
       d_id char(4) primary key,
       d_name varchar(100) unique key,
       d_manager char(4) unique key
);

create table employee (
       e_id char(4) primary key,
       e_name varchar(50),
       e_designation varchar(50),
       e_salary int,
       e_dept char(4),
       foreign key(e_dept) references department(d_id)
);

alter table department add foreign key(d_manager) references employee(e_id);

create table customer (
       c_nic char(10) primary key,
       c_name varchar(50),
       c_tel int(10)
);

create table product (
       p_id char(4) primary key,
       p_name varchar(50) unique,
       p_price int,
       p_customer char(10),
       foreign key(p_customer) references customer(c_nic)
);

create table project (
       pr_id char(4) primary key,
       pr_name varchar(50) unique,
       pr_lead char(4),
       pr_product char(4),
       foreign key(pr_lead) references employee(e_id),
       foreign key(pr_product) references product(p_id)
);

create table project_employee(
       pe_project char(4),
       pe_employee char(4),
       primary key(pe_project, pe_employee)
);


-- 07

-- describe employee;
-- describe department;
-- describe product;
-- describe project;
-- describe customer;
-- describe project_employee;

-- 08

insert into department
values ('d01', 'implementation', NULL),
       ('d02', 'testing', NULL);

insert into employee
values ('e01', 'Ranjana', 'programmer', 35000, 'd01'),
       ('e02', 'Kumara', 'analyst', 42000, 'd02'),
       ('e03', 'Saman', 'analyst', 62000, 'd02'),
       ('e04', 'Kasun', 'programmer', 43000, 'd01');

insert into customer
values ('753652645v', 'Nuwan', 0715436576),
       ('758643654v', 'Ruwan', 0715364745);

insert into product
values ('p01', 'Inventory Control System', 225000, '753652645v'),
       ('p02', 'Payroll System', 150000, '753652645v');

insert into project
values ('pr01', 'inv 01', 'e02', 'p01'),
       ('pr02', 'pay 01', 'e03', 'p02');

insert into project_employee
values ('pr01', 'e01'),
       ('pr02', 'e01'),
       ('pr01', 'e02'),
       ('pr01', 'e04'),
       ('pr02', 'e03'),
       ('pr01', 'e03');

update department set d_manager = 'e01' where d_id = 'd01';

update department set d_manager = 'e03' where d_id = 'd02';

-- select * from department;
-- select * from employee;
-- select * from project;
-- select * from product;
-- select * from customer;
-- select * from project_employee;

-- 09

select e_name as name, e_salary as salary
from employee, project
where pr_lead = e_id;

-- 10

select e_name as name, d_name as department
from employee, department
where d_manager = e_id;

-- 11

select e_id as id, e_name as name
from employee, project
where pr_lead = e_id;


-- 12

select count(*) as count
from project_employee
where pe_project = (
      select pr_id
      from project
      where pr_product = (
      	    select p_id
	    from product
	    where p_name = 'Inventory Control System'
      )
);


-- 13

select e_name as name
from employee
left join project_employee
on e_id = pe_employee
group by e_id
having count(pe_employee) > 1;

-- 14

select p_name as name
from product
left join project on p_id = pr_product
left join project_employee on pr_id = pe_project
group by p_name
having count(pe_employee) > 1;

-- 15

select e_id as id, e_name as name
from employee
left join department on e_dept = d_id
where e_designation = 'analyst'
      and d_name = 'testing';

-- 16

select e_name as name
from employee
where e_salary < (
      select MIN(e_salary)
      from employee, project
      where pr_lead = e_id
      )
      and e_id not in (
      select e_id
      from employee, project
      where pr_lead = e_id
      );

-- 17

select e_name as name
from employee, department, project
where d_manager = e_id
      and pr_lead = e_id;

-- 18

select e_name as name, e_salary as salary
from employee
order by e_salary ASC
limit 1;

-- 19

select e_name as name
from employee
left join project_employee on pe_employee = e_id
left join project on pr_id = pe_project
left join product on p_id = pr_product
where p_name = 'Inventory Control System';

-- 20

select p_name as 'product name', count(e_id) as '# of employees'
from employee
left join project_employee on pe_employee = e_id
left join project on pr_id = pe_project
left join product on p_id = pr_product
group by p_id;

-- 21

select p_name as name, p_price as 'original price', p_price - (p_price * 0.1) as 'discounted price' from product;

-- 22

create view manager as
select e_name as m_name, e_salary as m_salary, d_id as m_department
from employee, department
where e_id = d_manager;

-- 23

select * from manager;

-- 24

update employee
set e_salary = e_salary + (e_salary * 0.05)
where e_id in
(
select e_id
from (select * from employee) as something
left join project_employee on pe_employee = e_id
left join project on pr_id = pe_project
left join product on p_id = pr_product
where p_name = 'Inventory Control System'
);
