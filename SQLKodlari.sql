create database Doviz
go
use Doviz
go
create table ParaBirimi
(ID uniqueidentifier primary key,
Code nvarchar(8),
Tanim nvarchar(70),
UyariLimit decimal -- 0 2.34     2.33  > 2.34 < 2.43
)
go

create table Kur
(
ID uniqueidentifier primary key,
ParaBirimiID uniqueidentifier,
Alis decimal,
Satis decimal,
OlusturmaTarih datetime
)
go
create table KurGecmis
(
ID uniqueidentifier primary key,
KurID uniqueidentifier,
ParaBirimiID uniqueidentifier,
Alis decimal,
Satis decimal,
OlusturmaTarih datetime
)
go
insert into ParaBirimi(ID,Code,Tanim,UyariLimit)values(NEWID(),'PLN','USDPLN',4)
insert into ParaBirimi(ID,Code,Tanim,UyariLimit)values(NEWID(),'EUR','USDEUR',0)
insert into ParaBirimi(ID,Code,Tanim,UyariLimit)values(NEWID(),'TRY','USDTRY',0)

select * from ParaBirimi

go 
create proc KurKayitEKLE
(
@ID uniqueidentifier,
@KurID uniqueidentifier,
@ParaBirimiID uniqueidentifier,
@Alis decimal,
@Satis decimal,
@OlusturmaTarih datetime
)
as
begin

if((select count(*) from Kur where ParaBirimiID=@ParaBirimiID)>0)
begin 
--kur tablosundaki mevcut kaydi bizim kur gecmis tablosuna aktarmamiz gerekiyor.
insert into KurGecmis(ID,KurID,ParaBirimiID,Alis,Satis,OlusturmaTarih)select newid(),@KurID,@ParaBirimiID,@Alis,@Satis,@OlusturmaTarih 
from Kur where ParaBirimiID=@ParaBirimiID


--Kur bilgilerimizi guncelleyelim
update Kur set
Alis=@Alis,
Satis=@Satis
where
ParaBirimiID=@ParaBirimiID


end
else
begin 
insert into Kur(ID,ParaBirimiID,Alis,Satis,OlusturmaTarih)values(@ID,@ParaBirimiID,@Alis,@Satis,@OlusturmaTarih)
end
end
