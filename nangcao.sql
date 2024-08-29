--them
alter table sv add ADDRESS varchar2(50);
--sua
alter table sv modify AGE number not null;
--doi ten
alter table sv rename column ADDRESS TO CLASS;
--xoa cot
alter table sv drop column ADDRESS;
--doi ten bang
alter table sv rename to sinh vien;
--doi mk
ALTER USER user_name IDENTIFIED BY new_password;
--rang buoc
alter table sv add constraint check_class check(class in (10,11,12));
alter table sv drop constraint check_class;
alter table sv enable constraint check_class;
alter table sv disable constraint check_class;

create table preson (
id number(10),
namee varchar2 (50),
age number(10),
constraint check_age check (age between 1 and 100)
);
-- CREATE TABLE AS
create table sinh vien as (select * from sv);
-- CREATE USER
create user ORACLEUSER
identified by abc@123
default tablespace tbs_01
temporary tablespace tbs_01
quota 20M on tbs_01;
--bang tam thoi
create global temporary table preson 
( preson_id number(10),
preson_name varchar2(50),
preson_age number(10))on commit delete row;
--xoa bang
drop table preson;
--phan quyen
grant insert on sv to user
revoke insert on sv from user
--chi muc
create index idx_name on sv (FIRST_NAME);
drop index idx_name;

--tra ve ten cos id=5
SELECT DISTINCT first_name
FROM sv
WHERE id = '5';

--Primary Keys
after table sv add constraints pk_sv primary key (id,age);
after table sv drop constraints pk_sv ;

--Procedures
create or replace procedure delete_sv(sv_id in number)
is
begin 
delete from sv where id=sv_id;

end delete_sv;
/
begin
delete_sv(2);
end;

--funtion
create or replace function get_sv(sv_id in number)
return varchar2
is
sv_firstname varchar2(50);
begin
select FIRST_NAME into sv_firstname from sv where ID=sv_id;
return sv_firstname;
end get_sv;
/
select get_sv(2) from dual;

--role
create role test_role identified by abc123;

grant insert,update,delete on sv to test_role;
revoke delete on sv from test_role;
--Sequences  (t? dánh s?)
create sequence sv_seq
minvalue 1
maxvalue 50
start with 1
increment by 1
cache 20;
drop sequence sv_seq;
insert into sv(ID,LAST_NAME)values(sv_seq.NEXTVAL,'huy');
select * from sv;
select * from tblsv;


