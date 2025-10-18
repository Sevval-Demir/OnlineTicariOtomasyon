update tablo1 set stok=(select count(stok) from Uruns)

CREATE TRIGGER ARTTIR
ON URUNS
AFTER INSERT
AS
UPDATE TABLO1 SET STOK = STOK+1

Create Trigger SatisStokAzalt
On SatisHarekets
After insert
as 
Declare @Urunid int
Declare @Adet int
Select @Urunid=Urunid,@Adet=Adet from inserted
Update Uruns set stok=stok-@Adet where UrunID=@Urunid