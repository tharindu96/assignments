drop database if exists contract;

-- 02 
create database contract;

-- 03
use contract;

-- 04
select table_name, constraint_name, constraint_type from information_schema.table_constraints;

-- 05
select table_schema, table_name, constraint_name, constraint_type
from information_schema.table_constraints
where table_schema='contract';

-- 06
create table PROJ (
       p_code int primary key auto_increment,
       p_location varchar(255),
       p_description varchar(255)
);

-- 07
alter table PROJ AUTO_INCREMENT = 100;

-- 08
select table_schema, table_name, constraint_name, constraint_type
from information_schema.table_constraints
where table_schema='contract' and table_name='PROJ';

-- 09
insert into PROJ (p_location, p_description)
values ('Matara', 'Building'),
       ('Tangalle', 'Road'),
       ('Galle', 'Landscape'),
       ('Weligama', 'Building');

-- 10
create table DEPT (
       d_code char(4) primary key,
       d_p_code int,
       d_pname char(4) unique,
       d_pmgr varchar(50),
       d_budget float,
       d_persons int
);

-- 11
select table_schema, table_name, constraint_name, constraint_type
from information_schema.table_constraints
where table_schema='contract' and table_name='DEPT';

-- 12
insert into DEPT values ('D01', 100, 'B1a', 'Silva S.K.', 50.00, 12);
insert into DEPT values ('D02', 101, 'R1a', 'Gamage', 270.00, 22);
insert into DEPT values ('D02', 100, 'B1b', 'Perera G.', 2.00, 7);
insert into DEPT values ('D04', 103, 'B1a', 'Gamage', 90.00, 35);
       
-- cannot insert the last two entries because of `D02` in d_code column and `B1a` in d_p_code column

-- 13
alter table DEPT drop primary key;

-- 14
alter table DEPT add primary key(d_code, d_p_code);

-- 15
alter table DEPT add foreign key(d_p_code) references PROJ(p_code);

insert into DEPT values ('D02', 100, 'B1b', 'Perera G.', 2.00, 7);
insert into DEPT values ('D04', 103, 'B1c', 'Gamage', 90.00, 35);

-- 16
delete from PROJ where p_location = 'Weligama';

-- cannot delete this record because it is referenced from the DEPT table and
-- the default is to not allow the record to be deleted

-- 17
insert into DEPT values ('D02', 104, 'L2a', 'Herath A.K.', 120, 40);

-- cannot insert because the p_code doesn't exists in the PROJ table so it is a violation of the foreign key

-- 18
select constraint_name
from information_schema.table_constraints
where table_schema='contract' and table_name='DEPT' and constraint_type = 'FOREIGN KEY';

alter table DEPT
drop foreign key DEPT_ibfk_1;

-- 19
select table_schema, table_name, constraint_name, constraint_type
from information_schema.table_constraints
where table_schema='contract';

-- 20
insert into DEPT values ('D02', 104, 'L2a', 'Herath A.K.', 120, 40);

-- 21
insert into PROJ values (104, 'Hambantota', 'Cricket Stadium');

-- 22
alter table DEPT add foreign key(d_p_code) references PROJ(p_code)
on delete cascade;

-- 23
delete from PROJ where p_location = 'Weligama';

-- it allows the record to be deleted because we have set
-- the `on delete cascade` which also deletes all the records
-- which has a reference to the record that is about to be deleted

-- 24
select d_p_code from DEPT;

-- 103 is missing, because it was deleted when we delete the record
-- p_location = 'Weligama' which was the record that has the id of 103

-- 25
drop table DEPT;

-- 26
select table_schema, table_name, constraint_name, constraint_type
from information_schema.table_constraints
where table_schema='contract';

-- 27
drop table PROJ;

-- 28
drop database contract;
