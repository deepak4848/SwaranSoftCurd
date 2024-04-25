Create database COSwarnSoft_180424
use COSwarnSoft_180424

create table tblstudent
(
id int primary key identity,
name varchar(50),
Email varchar(100),
mobile bigint,
State int,
City int,
AboutYourself varchar(200),
UploadPhoto varchar(50)
)

create table tblstate
(
Sid int primary key identity,
Sname varchar(50)
)
INSERT INTO tblstate (Sname) VALUES ('Bihar');
INSERT INTO tblstate (Sname) VALUES ('U.P');
INSERT INTO tblstate (Sname) VALUES ('Haryana');
INSERT INTO tblstate (Sname) VALUES ('M.P');
INSERT INTO tblstate (Sname) VALUES ('Rajasthan');

create table tblCity
(
Cid int primary key identity,
Sid int,
Cname varchar(50)
)
select * from tblstate
insert into tblcity (Sid,Cname) values(1,'Nalanda')
insert into tblcity (Sid,Cname) values(1,'Gaya')
insert into tblcity (Sid,Cname) values(2,'Knapur')
insert into tblcity (Sid,Cname) values(2,'Lucknow')
insert into tblcity (Sid,Cname) values(3,'Gurugram')
insert into tblcity (Sid,Cname) values(3,'Karnal')
insert into tblcity (Sid,Cname) values(4,'Indore')
insert into tblcity (Sid,Cname) values(4,'Jabalpur')
insert into tblcity (Sid,Cname) values(5,'Jaipur')
insert into tblcity (Sid,Cname) values(5,'Kota')
select * from tblcity


truncate table tblstate

insert into tblstate(Sname)values('Bihar','U.P','Haryana','M.P','Rajasthan')

insert into tblstate (Sname)
values ('Bihar'), ('U.P'), ('Haryana'), ('M.P'), ('Rajasthan')

create procedure sp_ShowList
as
begin
select * from tblstudent
end

CREATE procedure SP_ALL_Swarnsoft
@id int =0,
@name varchar(50)=null,
@Email varchar(100)=null,
@mobile varchar(100)=null,
@State int,
@City int,
@AboutYourself varchar(200)=null,
@UploadPhoto varchar(50)=null,
@action varchar(25)

as
begin
if(@action='Insert')
begin
Insert into tblstudent values(@name,@Email,@mobile,@State,@City,@AboutYourself,@UploadPhoto)
end

else if(@action='sp_ShowList')
begin
select * from tblstudent join tblstate on tblstudent.state=tblstate.sid join tblCity on tblstudent.city=tblCity.cid
select * from tblstudent
end

else if(@action='Edit')
begin
select * from tblstudent where id=@id
end


else if(@action='Delete')
begin
delete  from tblstudent where id=@id
end

else if(@action='Update')
begin
update  tblstudent set name=@name,Email=@Email,mobile=@mobile,state=@State,city=@City,AboutYourself=@AboutYourself,UploadPhoto=@UploadPhoto where id=@id
end

end