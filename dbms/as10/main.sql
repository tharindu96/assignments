drop database if exists assignment10;
create database assignment10;
use assignment10;

create table employee(e_id char(4) primary key, e_d_id char(4), e_name varchar(20), e_desig varchar(20), e_salary decimal(9,2));
insert into employee values('e01','d01','ranjana','programmer',35000);
insert into employee values('e02','d02','Kumara','Analyst',42000);
insert into employee values('e03','d02','Saman','Analyst',62000);
insert into employee values('e04','d01','Kasun','programmer',43000);
create table dept(d_id char(4) primary key, d_name varchar(20), d_manager char(4));
insert into dept values('d01','implementation','e01');
insert into dept values('d02','Testing','e03');
create table product(p_id char(4) primary key, p_pr_id char(4),p_name varchar(30), p_price decimal(9,2));
insert into product values('p01','pr01','Inventry Control system',225000);
insert into product values('p02','pr02','Payroll system',150000);
create table project( pr_id char(4) primary key, pr_name varchar(20), pr_leader char(4));
insert into project values('pr01','inv 01','e02');
insert into project values('pr02','Pay 01','e03');
create table work(w_pr_id char(4), w_e_id char(4));
insert into work values('pr01','e01');
insert into work values('pr02','e01');
insert into work values('pr01','e02');
insert into work values('pr01','e04');
insert into work values('pr02','e03');
insert into work values('pr01','e03');
create table customer(c_nic char(10) primary key, c_name varchar(15), c_tel_no varchar(10));
insert into customer values('750000000v','Nuwan','0712546890');
insert into customer values('800000001v','Nuwan','0772546895');


-- 01

show tables;

-- 02

select * from employee;
select * from dept;
select * from product;
select * from project;
select * from work;
select * from customer;

-- 03

select e_id as id, e_name as name
from employee, project
where e_id = pr_leader;

-- 04

select count(e_id) as '# employees'
from employee
left join work on w_e_id = e_id
left join project on pr_id = w_pr_id
left join product on p_pr_id = pr_id
where p_name = 'Inventry Control System';


-- 05

select e_name as name
from employee
left join work on w_e_id = e_id
group by e_id
having count(w_e_id) > 1;

-- 06

select p_name as name
from product
left join project on p_pr_id = pr_id
left join work on pr_id = w_pr_id
group by p_name
having count(w_e_id) > 1;

-- 07

select e_name as name
from employee
left join dept on d_id = e_d_id
where e_desig = 'Analyst'
and d_name = 'testing';

-- 08

select e_name as name
from employee
where e_salary < (
      select MIN(e_salary)
      from employee, project
      where pr_leader = e_id
      )
      and e_id not in (
      select e_id
      from employee, project
      where pr_leader = e_id
      );

-- 09

select e_name as name
from employee, dept, project
where d_manager = e_id
      and pr_leader = e_id;


-- 10

select e_name as name, e_salary as salary
from employee
order by e_salary ASC
limit 1;

-- 11

select e_name as name
from employee
left join work on w_e_id = e_id
left join project on pr_id = w_pr_id
left join product on p_pr_id = pr_id
where p_name = 'Inventry Control System';

-- 12

select p_name as 'product name', count(e_id) as '# of employees'
from employee
left join work on w_e_id = e_id
left join project on pr_id = w_pr_id
left join product on p_pr_id = pr_id
group by p_id;

-- 13

select w_e_id as id
from work
group by w_e_id
having count(w_e_id) > (
       select count(w_e_id)
       from work
       where w_e_id = 'e02'
       group by w_e_id
);

-- 14

select p_name as name, p_price as 'original price', p_price - (p_price * 0.1) as 'discounted price' from product;

-- 15

-- select e_salary from employee;

-- update employee
-- set e_salary = e_salary * 105/100
-- where e_id in (
--       select w_e_id
--       from work
--       where w_pr_id in (
--       	    select p_pr_id
-- 	    from product
-- 	    where p_name = 'Payroll System'
--       )
-- );

update employee
set e_salary = e_salary + (e_salary * 0.05)
where e_id in
(
select e_id
from (select * from employee) as something
left join work on w_e_id = e_id
left join project on pr_id = w_pr_id
left join product on p_pr_id = pr_id
where p_name = 'Payroll System'
);

-- select e_salary from employee;

-- 16

create view manager as
select e_name as m_name, e_salary as m_salary, d_id as m_dept
from employee, dept
where e_id = d_manager;

-- 17

select * from manager;

-- 18

update manager
set m_salary = m_salary + 10000;

-- 19

select e_salary
from employee;

-- 20

create view inventory as
select e_name as i_name, e_desig as i_desig, e_salary as i_salary
from employee
where e_id in (
      select w_e_id
      from work
      where w_pr_id in (
      	    select p_pr_id
	    from product
	    where p_name = 'Inventry Control System'
      )
);

-- 21

describe inventory;

-- 22

select i_name as name, i_desig as designation
from inventory;

-- 23

create table staff as
select employee.*
from employee;

-- 24

create table inv as
select inventory.*
from inventory;

-- 25

alter table employee
add foreign key (e_d_id) references dept(d_id)
on update cascade;

update dept
set d_id = 'd05'
where d_name = 'Implementation';
