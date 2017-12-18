drop database if exists projects;

-- 01
create database projects;
use projects;

-- 02
create table project(
       p_project_id char(3) primary key,
       p_description varchar(255),
       p_budget int,
       p_due_data date
);

create table staff(
       s_emp_no char(4) primary key,
       s_surname varchar(255),
       s_initials varchar(10),
       s_title varchar(50),
       s_hourly_rate double,
       s_manager char(4),
       foreign key(s_manager) references staff(s_emp_no)
);

create table task(
       t_emp_no char(4),
       t_project_id char(3),
       t_task varchar(50),
       t_hours int,
       primary key(t_emp_no, t_project_id, t_task),
       foreign key(t_emp_no) references staff(s_emp_no),
       foreign key(t_project_id) references project(p_project_id)
);

-- 03

insert into staff values ('E105','Peiris','N.C.L.','Project Mg',570.00,null);
insert into staff values ('E110','Sirisena','G.H.','Project Mg',470.00,null);
insert into staff values ('E114','Alwis','J.K.','Project Mg',660.00,null);
insert into staff values ('E123','Fernando','S.K.','Project Mg',300.00,null);
insert into staff values ('E100','Perera','P.B.','Sr.Programmer',500.00,'E105');
insert into staff values ('E101','Silva','D.K.','Analysts',510.00,'E114');
insert into staff values ('E102','Gamage','W.G.','Sr.Programmer',430.00,'E114');
insert into staff values ('E103','Bandara','R.A.','Programmer',330.00,'E105');
insert into staff values ('E104','Soyza','L.','Programmer',410.00,'E123');
insert into staff values ('E106','Dias','P.','Programmer',240.00,'E110');
insert into staff values ('E107','Gunasena','C.','Sr.Programmer',480.00,'E110');
insert into staff values ('E108','Pathirana','M.','Programmer',210.00,'E114');
insert into staff values ('E109','Somapala','K.','Programmer',290.00,'E105');
insert into staff values ('E111','Rathnasena','B.','Sr.Programmer',420.00,'E123');
insert into staff values ('E112','Silva','G.H.','Programmer',370.00,'E105');
insert into staff values ('E113','Fernando','S.','Sr.Programmer',490.00,'E110');
insert into staff values ('E115','Jayakodi','P.','Sr.Programmer',390.00,'E123');
insert into staff values ('E116','Peiris','H.','Consultant',520.00,'E105');
insert into staff values ('E117','David','W.F.','Programmer',360.00,'E114');
insert into staff values ('E118','Dias','G.L.','Programmer',250.00,'E123');
insert into staff values ('E119','Kamaladasa','P.','Sr.Programmer',700.00,'E114');
insert into staff values ('E120','Jayakodi','P.','Programmer',550.00,'E105');
insert into staff values ('E121','Gamage','R.A.','Consultant',450.00,'E110');
insert into staff values ('E124','Smith','R.D.','Programmer',550.00,'E105');
insert into project values ('P01','Inventory',95000,'2012-09-2');
insert into project values ('P02','Payroll',117000,'2012-12-10');
insert into project values ('P03','HRM System',200000,'2012-11-25');
insert into project values ('P04','Billing System',125000,'2012-11-4');
insert into project values ('P05','Rate Cal System',100000,'2012-09-26');
insert into project values ('P06','Payroll',112000,'2013-01-12');
insert into project values ('P07','Stock Control System',99000,'2012-10-1');
insert into project values ('P08','Inventory',140000,'2012-10-12');
insert into task values ('E100','P01','Design',8);
insert into task values ('E100','P01','Implement',5);
insert into task values ('E101','P01','Design',8);
insert into task values ('E101','P05','Design',16);
insert into task values ('E101','P08','Design',10);
insert into task values ('E101','P08','Implement',10);
insert into task values ('E102','P06','Design',10);
insert into task values ('E102','P06','Implement',24);
insert into task values ('E103','P01','Test',26);
insert into task values ('E103','P01','Implement',16);
insert into task values ('E103','P08','Test',8);
insert into task values ('E104','P01','Implement',18);
insert into task values ('E104','P02','Design',16);
insert into task values ('E104','P02','Implement',32);
insert into task values ('E105','P02','Design',24);
insert into task values ('E105','P02','Implement',8);
insert into task values ('E105','P02','Manage',10);
insert into task values ('E106','P03','Test',32);

-- 04

select * from staff;
select * from project;
select * from task;

-- 05

-- information_schema
-- table_constraints
--	constraint_type
--	table_schema
--	table_name
--	constraint_name

select constraint_name, table_name, constraint_type from information_schema.table_constraints where table_schema = 'projects';


-- 06

insert into task values('E101', 'P09', 'Design', 20);

-- cannot add because there is not project with id P09

-- 07

delete from project where p_project_id = 'P05';

-- cannot delete project because there are tasks depending on this project

-- 08

select constraint_name from information_schema.table_constraints where table_schema = 'projects' and table_name = 'task';

-- 09

alter table task
drop foreign key task_ibfk_2;

-- 10

alter table task
add foreign key(t_project_id)
references project(p_project_id)
on delete cascade
on update cascade;

-- 11

update project
set p_project_id = 'P09'
where p_project_id = 'P08';

-- 12

delete from project
where p_project_id = 'P05';

-- 13

drop table project;

-- doesn't let you drop the table because it has a foreign key referencing it

-- 14

select s_emp_no, s_surname from staff where s_emp_no in (select distinct t_emp_no from task);


-- 15

select s_title from staff where s_emp_no in (select distinct t_emp_no from task where t_project_id = 'P01');


-- 16

select distinct s_emp_no, s_hourly_rate, t_task, t_project_id
from staff
left join task
on s_emp_no = t_emp_no
where s_emp_no not in (select distinct t_emp_no from task where t_task = 'Design') and
      s_hourly_rate > 350;


-- 17

select t_emp_no, t_hours
from task
where t_emp_no in (select s_emp_no from staff where s_manager = 'E105');


-- 18

select *
from staff
where s_hourly_rate > (select max(s_hourly_rate) from staff where s_surname = 'Silva');


-- 19

select s_surname, s_title
from staff
where s_title = (select s_title from staff where s_surname = 'Bandara');

-- 20
select *
from staff
where s_manager = (select s_emp_no from staff where s_surname = 'Alwis');

-- 21
select *
from staff
where s_title in ('Programmer', 'Sr.Programmer') and
      s_manager in (select s_emp_no from staff where s_surname in ('Sirisena', 'Alwis'));


-- 22
select distinct s_title
from staff
where s_emp_no in (
      select t_emp_no
      from task
      where t_project_id = 'P01'
);

-- 23
select s_surname
from staff
where s_manager = (
      select s_emp_no from staff where s_surname = 'Peiris' and s_initials = 'N.C.L.'
);

-- 24

select s_emp_no, s_surname
from staff
where s_emp_no in (
      	       select distinct t_emp_no from task
      ) and
      s_manager is NULL;
