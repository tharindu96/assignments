drop database if exists ass12;

create database ass12;

use ass12;

create table project (
       p_code char(4),
       p_location varchar(200),
       p_description varchar(200),
       primary key(p_code)
);

create table work (
       w_p_code char(4),
       w_leader varchar(200),
       w_budget double,
       w_persons int,
       primary key(w_p_code, w_leader),
       foreign key(w_p_code) references project(p_code)
);

insert into project values
('p01', 'ABC Company', 'Payroll'),
('p02', 'Simaya Hotel', 'Room booking System'),
('p03', 'XYZ Traders', 'Point of Sale System'),
('p04', 'CP Holdings', 'HRM System');

insert into work values
('p01', 'Silva', 0.75, 12),
('p02', 'Gamage', 5, 22),
('p03', 'Perera', 2, 7),
('p04', 'Gamage', 1.5, 26);

delimiter //
create procedure p1()
begin
	select 'This is my 1st stored procedure';
end//
delimiter ;

delimiter //
create procedure display_projects()
begin
	select * from project;
end//
delimiter ;

delimiter //
create procedure dis_details()
begin
	select * from project;
	select p_description, w_leader from project, work where p_code = w_p_code;
end//
delimiter ;

-- Declaring Variables
-- declare a,b int;
-- declare a int default 10;

-- Passing Parameters
delimiter //
create procedure dis_persons(IN no int)
begin
	select * from work where w_persons > no;
end//
delimiter ;

delimiter //
create procedure project_details(IN leader varchar(200))
begin
	select p_description, work.* from project, work where w_leader = leader and w_p_code = p_code;
end//
delimiter ;

call project_details('Silva');
