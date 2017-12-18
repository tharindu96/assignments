drop database if exists books;

create database books;

use books;

create table subject (
       id int primary key auto_increment,
       name varchar(100) unique not null
);

create table author (
       id int primary key auto_increment,
       name varchar(50) not null,
       subject int not null,
       foreign key(subject) references subject(id)
);

create table book (
       id int primary key auto_increment,
       title varchar(100) not null,
       pub_year int(4) not null,
       author int not null,
       subject int not null,
       foreign key(author) references author(id),
       foreign key(subject) references subject(id)
);

create table edition (
       number int,
       book int,
       primary key(book, number),
       foreign key(book) references book(id)
);

insert into subject (name)
values
	('Computer Science'),
	('Mathematics'),
	('Physics'),
	('Chemistry'),
	('History');

insert into author (
       name, subject
) values
	('Helmo SA', 1),
	('Yoshua Bengio', 1),
	('David Hilbert', 2),
	('Alan Turing', 2),
	('Albert Einstein', 3),
	('Paul Dirac', 3),
	('Robert H. Crabtree', 4),
	('Roald Hoffmann', 4),
	('David McCullough', 5),
	('Edward Gibbon', 5);

insert into book (
       title, pub_year, author, subject
) values
	('Introduction to DBMS', 2016, 1, 1),
	('Learning Deep Architectures for AI', 2009, 2, 1),
	('Deep Learning', 2016, 2, 1),
	('The Foundations Of Geometry', 1899, 3, 2),
	('Principles of Mathematical Logic', 1950, 3, 2),
	('Pure mathematics', 1992, 4, 2),
	('Collected Works of A.M. Turing', 1992, 4, 2),
	('Relativity: The Special and the General Theory', 1916, 5, 3),
	('The Meaning of Relativity', 1922, 5, 3),
	('General Theory of Relativity', 1975, 6, 3),
	('The Principles of Quantum Mechanics', 1930, 6, 3),
	('The organometallic chemistry of the transition metals', 1988, 7, 4),
	('Advanced Organic Chemistry', 2011, 7, 4),
	('Chemistry imagined', 1993, 8, 4),
	('Solids and Surfaces: A Chemists View of Bonding in Extended Structures', 1988, 8, 4),
	('John Adams', 2001, 9, 5),
	('The Wright Brothers', 2015, 9, 5),
	('The Christians and the Fall of Rome', 2004, 10, 5),
	('An Abridgment of Mr. Gibbons History of the Decline and Fall of the Roman Empire', 1776, 10, 5);


insert into edition (
       book, number
) values
	(1, 1),
	(2, 1),
	(3, 1),
	(4, 1),
	(5, 1),
	(6, 1),
	(7, 1),
	(8, 1),
	(9, 1),
	(10, 1),
	(11, 1),
	(12, 1),
	(13, 1),
	(14, 1),
	(15, 1),
	(16, 1),
	(17, 1),
	(18, 1),
	(19, 1),
	(1, 2),
	(3, 2),
	(5, 2),
	(7, 2),
	(9, 2),
	(11, 2),
	(13, 2),
	(15, 2),
	(17, 2),
	(19, 2),
	(1, 3);
