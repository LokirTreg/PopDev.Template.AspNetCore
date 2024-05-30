create database Library
alter database Library set recovery simple
go

use Library
-- Удаление
Drop Table if exists Book_Author
Drop Table if exists [Queue]
Drop Table if exists Penalty_Debtor
Drop Table if exists Book_Genre
Drop Table if exists Author
Drop Table if exists Genre
Drop Table if exists Penalty
Drop Table if exists Debtor
Drop Table if exists Issued_book
Drop Table if exists Copy_of_book
Drop Table if exists Librarian
Drop Table if exists Reader
Drop Table if exists Book
Drop Table if exists Publisher
Drop Table if exists Users

-- Добавление таблиц
CREATE TABLE Book(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Book PRIMARY KEY,
  title nvarchar(30),
  year_of_publish nvarchar(30),
  circulation int,
  ID_publisher int
)

CREATE TABLE Publisher(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Publisher PRIMARY KEY,
  title nvarchar(30)
)

CREATE TABLE Author(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Author PRIMARY KEY,
  [name] varchar(30)
)

CREATE TABLE Book_Author(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Book_Author PRIMARY KEY,
  ID_Author int,
  ID_Book int
)

CREATE TABLE Genre(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Genre PRIMARY KEY,
  [name] varchar(30)
)

CREATE TABLE Book_Genre(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Book_Genre PRIMARY KEY,
  ID_Genre int,
  ID_Book int
)

CREATE TABLE Penalty(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Penalty PRIMARY KEY,
  size_of_penalty int
)

CREATE TABLE Debtor(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Debtor PRIMARY KEY,
  ID_Issued_book int
)

CREATE TABLE Penalty_Debtor(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Penalty_Debtor PRIMARY KEY,
  ID_Penalty int,
  ID_Debtor int
)

CREATE TABLE Issued_book(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Issued_book PRIMARY KEY,
  Date_of_issue date,
  Date_of_planned_delivery date,
  ID_Reader int,
  ID_Librarian int,
  ID_Copy_of_book int
)

CREATE TABLE Reader(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Reader PRIMARY KEY,
  [name] nvarchar(50)
)

CREATE TABLE Librarian(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Librarian PRIMARY KEY,
  [name] nvarchar(50)
)

CREATE TABLE Copy_of_book(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Copy_of_book PRIMARY KEY,
  ID_Book int
)

CREATE TABLE [Queue](
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Queue PRIMARY KEY,
  Number_in_queue int,
  ID_Reader int,
  ID_Book int
)

-- Связи
ALTER TABLE Book ADD CONSTRAINT FK_Book_Publisher
FOREIGN KEY(ID_publisher) REFERENCES Publisher(ID)

ALTER TABLE Penalty_Debtor ADD CONSTRAINT FK_Penalty_Debtor_Penalty
FOREIGN KEY(ID_Penalty) REFERENCES Penalty(ID)

ALTER TABLE Penalty_Debtor ADD CONSTRAINT FK_Penalty_Debtor_Debtor
FOREIGN KEY(ID_Debtor) REFERENCES Debtor(ID)

ALTER TABLE Debtor ADD CONSTRAINT FK_Debtor_Issued_book
FOREIGN KEY(ID_Issued_book) REFERENCES Issued_book(ID)

ALTER TABLE [Queue] ADD CONSTRAINT FK_Queue_Reader
FOREIGN KEY(ID_Reader) REFERENCES Reader(ID)

ALTER TABLE [Queue] ADD CONSTRAINT FK_Queue_Book
FOREIGN KEY(ID_Book) REFERENCES Book(ID)

ALTER TABLE Issued_book ADD CONSTRAINT FK_Issued_book_Copy_of_book
FOREIGN KEY(ID_Copy_of_Book) REFERENCES Copy_of_book(Id)

ALTER TABLE Issued_book ADD CONSTRAINT FK_Issued_book_Reader
FOREIGN KEY(ID_Reader) REFERENCES Reader(ID)

ALTER TABLE Issued_book ADD CONSTRAINT FK_Issued_book_Librarian
FOREIGN KEY(ID_Librarian) REFERENCES Librarian(ID)

ALTER TABLE Copy_of_book ADD CONSTRAINT FK_Copy_of_book_Book
FOREIGN KEY(ID_Book) REFERENCES Book(ID)

ALTER TABLE Book_Genre ADD CONSTRAINT FK_Book_Genre_Genre
FOREIGN KEY(ID_Genre) REFERENCES Genre(ID)

ALTER TABLE Book_Genre ADD CONSTRAINT FK_Book_Genre_Book
FOREIGN KEY(ID_Book) REFERENCES Book(ID)

ALTER TABLE Book_Author ADD CONSTRAINT FK_Book_Author_Author
FOREIGN KEY(ID_Author) REFERENCES Author(ID)

ALTER TABLE Book_Author ADD CONSTRAINT FK_Book_Author_Book
FOREIGN KEY(ID_Book) REFERENCES Book(ID)


create table Users
(
	Id int not null identity constraint PK_Users primary key,
	[Login] nvarchar(200) constraint Unique_Users_Login unique not null,
	[Password] nvarchar(max) not null,
	RoleId int not null,
	IsBlocked bit not null,
	RegistrationDate datetime not null,
)

insert into Users values
('dev', '', 1, 0, GETDATE()),
('admin', 'd61d004c03457bac7b90c1e8d4f51113be162346b27af5307caffe21ef88597ff15ab1569e07155302ff7b0af29f7f0431531004568da3849a5708176815a70f', 0, 0, GETDATE())

insert into Users values
('adminPOP', 'd8644687cfaed839240d77eebfb1fcc62020aaa7fdb40b1ed4bcc26db79eb8f8cd24c90083224452281f5c4fe8eb5c912486c346c5ae8b0b8aff0f942f81414a', 1, 0, GETDATE());
-- Заполнение таблиц
Insert into Publisher (title)
Values
('Eng'),
('Аист'),
('Режиссер');
Select * from Publisher

Insert into Book (title, year_of_publish, circulation, ID_publisher)
Values
('Океан у моря', '2024-01-01', 100000, 1),
('Гарри Шпротер', '2003-01-01', 100, 2),
('Волкодав', '1998-01-01', 40000, 3);
Select * from Book

Insert into Author([name])
Values
('Алан Вейк'),
('Макс Фрай'),
('Мария Антуаннета');
Select * from Author

Insert into Book_Author(ID_Author, ID_Book)
Values
(1, 1),
(2, 1),
(3, 2),
(1, 3);
Select * from Book_Author

Insert into Genre([name])
Values
('Хоррор'),
('Фентези'),
('Фантастика');
Select * from Genre

Insert into Book_Genre(ID_Genre, ID_Book)
Values
(1, 1),
(2, 1),
(3, 2),
(1, 3);
Select * from Book_Genre

Insert into Penalty(size_of_penalty)
Values
(100),
(1000),
(10000);
Select * from Penalty

Insert into Reader([name])
Values
('Слава Фролов'),
('Егор Бугаев'),
('Алексей Попович');
Select * from Reader

Insert into Librarian([name])
Values
('Славов Фрол'),
('Егоров Бугй'),
('Алексеев Поп');
Select * from Librarian

Insert into Copy_of_book(ID_Book)
Values
(1),
(1),
(3),
(2);
Select * from Copy_of_book

Insert into Issued_book(Date_of_issue, Date_of_planned_delivery, ID_Reader, ID_Librarian, ID_Copy_of_book)
Values
('2014-12-10', '2015-02-10', 1, 1, 1),
('2016-12-10', '2017-02-10', 2, 2, 2),
('2023-12-10', '2024-02-10', 3, 3, 3),
('2014-12-10', '2018-02-10', 3, 3, 4);
Insert into Issued_book(Date_of_issue, Date_of_planned_delivery, ID_Reader, ID_Copy_of_book)
Values
('2018-01-10', '2020-9-10', 2, 2);
Select * from Issued_book
Insert into Debtor(ID_Issued_book)
Values
(1),
(4),
(2);
Select * from Debtor

Insert into Penalty_Debtor(ID_Penalty, ID_Debtor)
Values
(1, 3),
(2, 3),
(3, 1);
Select * from Penalty_Debtor

Insert into [Queue](Number_in_queue, ID_Book, ID_Reader)
Values
(1, 1, 3),
(2, 1, 2),
(1, 3, 1);
Select * from [Queue]


-- Publisher Book Author Book_Author Genre Book_Genre Penalty Reader Librarian Copy_of_book Issued_book Debtor
-- Penalty_Debtor [Queue]

Select Sum(P.size_of_penalty) as Sum_of_penalty, R.name from Penalty_Debtor
 join Penalty as P on P.ID = ID_Penalty
 join Debtor as D on D.ID = ID_Debtor
 join Issued_book as I on I.ID = D.ID_Issued_book
 join Reader as R on R.ID = I.ID_Reader
group by R.name, I.Date_of_issue
Having I.Date_of_issue > '2015-01-01'

select * from Book
cross join Copy_of_book

SELECT Book.*, Book_Author.ID_Author FROM Book
LEFT JOIN Book_Author ON Book_Author.ID_Book = Book.ID

SELECT Issued_book.*, Librarian.name
FROM Issued_book
RIGHT JOIN Librarian ON Librarian.ID = Issued_book.ID_Librarian

SELECT Book.title, Reader.name, Issued_book.*
FROM Issued_book
FULL JOIN Book ON Book.ID = Issued_book.ID_Copy_of_book
FULL JOIN Reader ON Reader.ID = Issued_book.ID_Reader

SELECT B1.circulation, B2.ID_publisher
FROM Book B1, Book B2
where B1.circulation > B2.circulation

select * from Issued_book as I
cross join Copy_of_book Copy_
select * from Issued_book as I
cross apply (Select * from Copy_of_book as C where I.ID_Copy_of_book = C.ID) S

select title from Book
where ID = Any (select ID from Book where circulation >= 1000)

select title from Book
where ID <= All (select ID from Book where circulation >= 1000)

select [name] from Reader
where ID in (select ID_Reader from Issued_book)

SELECT * From Author WHERE Name LIKE 'А%' 

SELECT circulation From Book WHERE circulation BETWEEN 100 AND 10000

Select DateDiff(year, I.Date_of_issue, I.Date_of_planned_delivery) as DD,
Case
 when DateDiff(year, I.Date_of_issue, I.Date_of_planned_delivery) >= 5 then 'Долго должен'
 when DateDiff(year, I.Date_of_issue, I.Date_of_planned_delivery) >= 2 then 'Средене должен'
 else 'Мало должен'
end C
from Issued_book as I

select Cast(year_of_publish as date) as 'Date', Upper(title) Upper_title from Book
select Convert(nvarchar, Date_of_issue, 103) as 'Date' from Issued_book
select *,
case 
	when isnull(I.ID_Librarian, -1) = -1 then 'Нет библиотекаря'
end
from Issued_book as I

SELECT *, NullIf(I.ID_Reader, I.ID_Librarian) as 'Есть есть читатель и нет библиотекаря' from Issued_book as I


SELECT DISTINCT ID, IIF(ID_Librarian = 3, 'Да', 'Нет') AS 'Выдавал ли библиотекарь 1 эту книгу' FROM Issued_book

select [name], 
Replace([name], 'а', 'А') from Author

select Substring([name], 1, 4) from Author

SELECT STUFF(CONCAT(Name, ' .'), LEN(CONCAT(Name, ' .')), 1, ' Александрович') FROM Author

SELECT CONCAT('Библиотекарь ', Name, ' имеет ID ', STR(ID, 2)) FROM Librarian

select ID_Librarian, CHOOSE(ID_Librarian, 'Павел', 'Саша', 'Маша') from Issued_book

SELECT Name, UNICODE(Name) as 'Код первого символа' FROM Librarian

SELECT DISTINCT DATEPART(day, Date_of_issue) AS 'День', DATEPART(month, Date_of_issue) AS 'Месяц' FROM Issued_book

SELECT DATEADD(YEAR, DATEPART(YEAR, Date_of_planned_delivery), Date_of_issue) FROM Issued_book

SELECT SYSDATETIMEOFFSET() AS Result

--alter table Book nocheck constraint all
--Delete from Publisher

alter table Debtor nocheck constraint all
Delete from Issued_book
where ID_Librarian = 3

go
