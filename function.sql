create or replace trigger sv_after_insert
after insert on sv for each row
begin
insert into tblsv
(id, name, age)
VALUES
(:new.id, 'INSERT', 19);
end;

create or replace trigger sv_after_delete
before delete on sv for each row
begin
if :old.id<12 then
(id, name, age)
VALUES
(:old.id, 'delete', 19);
end if;
end;

insert into sv
(id, first_name, age)
VALUES
(28, 'hoan', 19);
delete from sv where id=11;
select * from tblsv;
select * from sv;

--function string/char
select CHR(65)from dual;
insert into tblsvselect COMPOSE('a' || unistr('\0302') )from dual;
select CONCAT('a','b')from dual;
select DECOMPOSE('Très bien')from dual;
select INITCAP('NGUYEN VAN A') from dual;--viet hoa chu dau
select UPPER('nguyen van a')from dual;--viet hoa
select INSTR('Tech on the net', 'e') from dual;
select LENGTH(' ') from dual;
select LENGTH2(2) from dual;
select LPAD('hello',7,0) from dual;
select LTRIM('llhello word','l') from dual;--xoa bentrai
select RTRIM('hello wordll','l') from dual;--xoa ben phai
select NCHR(9731) from dual;
select id, first_name, REGEXP_INSTR (first_name, 'a|e|i|o|u', 1, 1, 0, 'i') as first_occurrence from sv;
select REPLACE('123hello123','123',' ')from dual;--thay the =>hello
select SUBSTR('hello word',2,3) from dual;--lay chuoi
select TRANSLATE('12hello 34','23','56') from dual;--thay chuoi=> 15hello 64
select TRIM(leading '1' from '12hello 34') from dual;-- cat ben trai
select TRIM(trailing '34' from '12hello 34') from dual;-- cat ben phai
select TRIM(both '1' from '12hello 34') from dual;-- cat 2 ben

--function number/math
select ABS(-12)from dual;-- tra ve gia trij tuyet doi
select id,AVG(age)from sv group by ID;--tinh tuoi tb theo id
select CEIL(-32.32) from dual;--lam tron
select FLOOR(-32.32)from dual;
select count(*)from sv;
select EXP(2) from dual; --luy thua cua e=2.71828
select COS(-32.32)from dual;
select ACOS(1)from dual;--nghich dao cos
select GREATEST(1,2,3,4)from dual;--lay gia tri lon nhat 4
select LEAST(1,2,3,4)from dual;--lay gia tri nho nhat 1

select id, max(age)from sv  group by id;
select age, first_name from sv where age=(select max(age)from sv);
select MEDIAN(age)from sv;--trung binh
select age from sv where age=(select min(age)from sv);
select mod(2,3) from dual;--chia lay du
select POWER(2,3) from dual;--tinh luy thua
select REMAINDER(15,6) from dual;
select ROUND(123.123,2) from dual;--lam tron den so thap phan nhat dinh
select SIGN(15) from dual; --  nunber>0=1,  nunber<0=-1,  nunber=0=0,
select SQRT(15) from dual;-- tinh can bac 2
select sum(age) from sv;
select * from sv;

--date time
select ADD_MONTHS('01-Aug-03',-3) from dual;
ALTER SESSION SET TIME_ZONE = '7:0';
select CURRENT_DATE from dual;--tra ve time now
select CURRENT_TIMESTAMP from dual;
select DBTIMEZONE from dual;



