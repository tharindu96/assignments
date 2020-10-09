
drop database if exists s9935medi;

-- 01

create database s9935medi;

use s9935medi;

-- 02

create table testing_info (
       lab_code char(5),
       test_name varchar(25),
       sample varchar(15),
       time_taken time,
       price int,
       primary key (lab_code)
);

-- 03

describe testing_info;


-- 04

insert into testing_info values
('FBC', 'Full Blood Count', 'Blood', '00:45:00', 400),
('FBS', 'Fasting blood sugar', 'Blood', '01:15:00', 350),
('UDS', 'urine drug screen', 'Urine', NULL, 550),
('UA', 'urinalysis', 'Urine', '02:30:00', 425),
('STLC', 'stool culture', 'Stool', '48:00:00', 700);


-- 05

select lab_code, sample, price
from testing_info;

-- 06


select lab_code, sample
from testing_info
where sample = 'Blood';


-- 07

select test_name, sample
from testing_info
order by sample desc;

-- 08

select distinct sample
from testing_info;

-- 09

create table lab_tecnician (
       tec_code char(4),
       tec_name varchar(25),
       primary key(tec_code)
);

-- 10

insert into lab_tecnician values
('t01', 'Thusith'),
('t02', 'Isadhi'),
('t03', 'Gamage');

-- 11

create table report_info (
       patient_name varchar(50),
       lab_code char(5),
       done_by char(4),
       test_date date,
       issuing_status enum('N', 'Y'),
       foreign key (lab_code) references testing_info(lab_code),
       foreign key (done_by) references lab_tecnician(tec_code)
);

-- 12

insert into report_info values
('K.D. Perera', 'FBS', 't01', '2016-09-21', 'N'),
('T. Samarathunga', 'UDS', 't03', '2016-09-21', 'Y'),
('O.P. Sugandi', 'STLC', 't03', '2016-09-22', 'N'),
('B. Kumai', 'FBS', 't01', '2016-09-23', 'Y'),
('T.K. Ranaweera', 'FBC', 't02', '2016-09-24', 'Y');

-- 13

select constraint_name, constraint_type
from information_schema.table_constraints
where constraint_schema = 's9935medi';

-- 14

select count(*) as '# of tests', test_date
from report_info
group by test_date;

-- 15

select count(*) as '# of tests done by Gamage'
from report_info
where done_by = (
      select tec_code
      from lab_tecnician
      where tec_name = 'Gamage'
);

-- 16

select test_name as 'Tests done by Gamage and Thusith'
from testing_info
left join report_info on report_info.lab_code = testing_info.lab_code
left join lab_tecnician on lab_tecnician.tec_code = report_info.done_by
where tec_name = 'Gamage'
union
select test_name
from testing_info
left join report_info on report_info.lab_code = testing_info.lab_code
left join lab_tecnician on lab_tecnician.tec_code = report_info.done_by
where tec_name = 'Thusith';

-- 17

select test_name as 'Tests done on 2016-09-21'
from testing_info
where lab_code in (
      select lab_code
      from report_info
      where test_date = '2016-09-21'
);


-- 18

select patient_name
from report_info
left join testing_info on report_info.lab_code = testing_info.lab_code
where
	sample = 'Blood' and
	time_taken < '03:00:00';

-- 19

select patient_name
from report_info
left join testing_info on report_info.lab_code = testing_info.lab_code
where
	sample = 'Blood' and
	test_date = '2016-09-23';

-- 20

update testing_info
set price = price + 50
where sample = 'Blood';

-- 21

select SUM(price) as 'income', test_date
from report_info
left join testing_info on report_info.lab_code = testing_info.lab_code
where
	(test_date = '2016-09-21' or test_date = '2016-09-22')
group by test_date;

-- 22

delimiter //

create procedure get_test_count_by_technician(name varchar(25))
begin
	declare tcode char(4);
	select tec_code into tcode from lab_tecnician where tec_name = name;
	select count(*) as '# of tests' from report_info where done_by = tcode;
end//

delimiter ;

-- 23

call get_test_count_by_technician('Gamage');

-- 24

delete from report_info
where lab_code in (
      select lab_code
      from testing_info
      where sample = 'Blood'
);

-- 25

drop table report_info;
