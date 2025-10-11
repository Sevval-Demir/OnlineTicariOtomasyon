insert into dbo.Uruns
(UrunAd,Marka,Stok,AlisFiyat,SatisFiyat,Durum,
UrunGorsel,Kategori_KategoriID)
values
('Buzdolabý','Arçelik',25,18000,21500,1,'test',1),
('Çamaþýr Makinesi','Bosch',30,14500,17000,1,'test',1),

('iPhone 15 Pro','Apple',50,45000,52000,1,'test',2),
('Galaxy S24','Samsung',70,38000,44500,1,'test',2),

('Türk Kahve Makinesi','Arzum',150,1200,1750,1,'test',3),
('Blender Seti','Tefal',90,2100,2800,1,'test',3);

select *from dbo.Uruns;