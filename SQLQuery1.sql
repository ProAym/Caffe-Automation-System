INSERT INTO UrunIngredients (UrunID, UrunAdi, UniteAdeti)
VALUES
-- Soğuk Kahveler
(2, 'Espresso', 18), -- ICE LATTE
(2, 'Milk', 230),
(1004, 'Espresso', 18), -- ICE CARAMEL LATTE
(1004, 'Milk', 230),
(1004, 'Caramel Sosu', 20);


INSERT INTO Stok (UrunAdi, Adet, Threshold)
VALUES
('Espresso', 100, 20),
('Milk', 500, 100),
('Caramel Sosu', 50, 10),
('Çikolata Sosu', 30, 5),
('Beyaz Çikolata Sosu', 40, 8),
('Berry Şurubu', 20, 4),
('Frappe Tozu', 80, 15),
('Chai Tea Latte Tozu', 60, 12),
('Su', 200, 40),
('Türk Kahvesi', 150, 30);

