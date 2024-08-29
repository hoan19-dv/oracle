--CURSOR CON TRO
create or replace function get_name(sv_id in number)
return varchar2
is sv_name varchar2(50);
cursor c1(s_id in number)
is 
select FIRST_NAME from sv where ID=s_id;
begin
open c1(sv_id);
fetch c1 into sv_name;
if c1%notfound then sv_name:='no name';
end if;
close c1;
return sv_name;
end;

--Exceptions
create or replace function get_age(sv_name in varchar2)
return number
is no_age exception;sv_age number(10);
begin
select AGE into sv_age from sv where FIRST_NAME= sv_name;
if sv_age is null then raise no_age;
end if ;
return sv_age;
exception  
when no_age then    
raise_application_error(-20001, 'age=null');
return 0;
when TOO_MANY_ROWS then 
dbms_output.PUT_LINE('tra ve nhieu hon 1 hang');
return 01422  ;
when others then
--raise_application_error(-20002, 'Error:'|| sqlcode);
raise_application_error(-20002, 'Error msg:'|| sqlerrm);
end;

select * from sv ;
select * from tblsv;
insert into sv (first_name)values('dung');
select get_age('huyen') from dual;
delete from tblsv;
delete from sv where id=3 ;
-- Foreign Keys
after table sv add constraints pk_sv primary key (id);
after table tblsv add constraint fk_tblsv 
foreign key (id)
reference sv(id) on delete key;
insert into sv (id,first_name,last_name,city,age,class)values(sv_seq.NEXTVAL,'huy','do','hcm',11,'12a3');
after table tblsv drop constraints fk_tblsv ;
after table tblsv disable constraint fk_tblsv;
after table tblsv enable constraint fk_tblsv;


--loop
create or replace function get_id (sv_name in varchar2)
return number
is sv_id number(10);
cursor c1 is select id  from sv where first_name=sv_name;
begin
sv_id:=0;
for i in c1
loop
sv_id:=sv_id+i.id;
exit when sv_id>40;
end loop;
return sv_id;
end;

create or replace function get_num(num in number)
return number
is count_num number(10);
begin
count_num:=0;
for i in 1..num
loop count_num:=count_num+i;
end loop;
return count_num;
end;

select get_id('huy') from dual;
select get_num(2)from dual;








