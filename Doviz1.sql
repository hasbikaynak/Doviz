USE [Doviz]
GO
/****** Object:  StoredProcedure [dbo].[KurKayitEKLE]    Script Date: 3/27/2021 1:00:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[KurKayitEKLE]
(
@ID uniqueidentifier,
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
insert into KurGecmis(ID,KurID,ParaBirimiID,Alis,Satis,OlusturmaTarih)select newid(),ID,@ParaBirimiID,@Alis,@Satis,@OlusturmaTarih 
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