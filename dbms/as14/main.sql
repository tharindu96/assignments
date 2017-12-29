DROP DATABASE IF EXISTS vehicle;

-- 01

CREATE DATABASE vehicle;

USE vehicle;

-- 02

CREATE TABLE company (
       c_code CHAR(3),
       c_name VARCHAR(50),
       PRIMARY KEY(c_code)
);

CREATE TABLE vehicle (
       v_code CHAR(3),
       v_brand VARCHAR(50),
       v_type VARCHAR(50),
       FOREIGN KEY(v_code) REFERENCES company(c_code)
);

CREATE TABLE repair (
       r_c_code CHAR(3),
       r_type VARCHAR(50),
       FOREIGN KEY(r_c_code) REFERENCES company(c_code)
);

INSERT INTO company
VALUES ('c01', 'Ruwan Enterprise'),
       ('c02', 'Indra Traders'),
       ('c03', 'Weels Lanka'),
       ('c04', 'Toyota Lanka'),
       ('c05', 'David Peris'),
       ('c06', 'Auto Service');

INSERT INTO vehicle
VALUES ('c02', 'Toyota', 'Car'),
       ('c01', 'Toyota', 'Car'),
       ('c01', 'Mazda', 'Car'),
       ('c02', 'Toyota', 'Van'),
       ('c02', 'Toyota', 'Double Cab'),
       ('c03', 'Mazda', 'Van'),
       ('c04', 'Toyota', 'Bus'),
       ('c03', 'Toyota', 'Car'),
       ('c04', 'Micro', 'Car'),
       ('c05', 'Chery QQ', 'Car');

INSERT INTO repair
VALUES ('c06', 'Car'),
       ('c01', 'Van'),
       ('c04', 'Bus');

-- 03

SELECT v_code
FROM vehicle
WHERE v_type = 'Van'
UNION
SELECT v_code
FROM vehicle
WHERE v_type = 'Bus';

-- 04

SELECT v_code
FROM vehicle
WHERE v_type = 'Van'
UNION ALL
SELECT v_code
FROM vehicle
WHERE v_type = 'Bus';

-- 05

SELECT v_code
FROM vehicle
WHERE v_type = 'Van'
UNION
SELECT r_c_code
FROM repair
WHERE r_type = 'Van';

-- 06

SELECT c_name
FROM company
WHERE c_code in (
      SELECT v_code
      FROM vehicle
      WHERE v_type = 'Van'
      UNION
      SELECT r_c_code
      FROM repair
      WHERE r_type = 'Van'
);

-- 07

SELECT *
FROM company
JOIN vehicle ON v_code = c_code;

-- 08

SELECT *
FROM company
INNER JOIN vehicle ON v_code = c_code;

-- 09

SELECT DISTINCT c_code
FROM company
JOIN vehicle ON v_code = c_code
ORDER BY c_code ASC;

-- 10

SELECT v_code, v_brand, v_type, r_c_code, r_type
FROM vehicle
LEFT JOIN repair ON v_code = r_c_code;

-- 11

SELECT v_code, v_brand, v_type, r_c_code, r_type
FROM vehicle
RIGHT JOIN repair ON v_code = r_c_code;


-- 12

CREATE INDEX comp_index ON company(c_code);

-- 13

SELECT *
FROM company
USE INDEX(comp_index)
WHERE c_code = 'c04';

-- 14

SELECT *
FROM company
IGNORE INDEX (comp_index)
WHERE c_code = 'c04';

-- 15

SHOW INDEXES IN company;


-- 16

DROP INDEX comp_index ON company;


-- 17

SHOW INDEXES IN company;

-- 18

CREATE TABLE vehicle_backup
SELECT v_code, v_brand, v_type
FROM vehicle;


-- 19

DELETE FROM vehicle
WHERE 1;

-- 20


