# 🚀 Online Ticari Otomasyon Sistemi

<p align="center">
  <img src="https://img.shields.io/badge/ASP.NET-MVC%205-blueviolet" />
  <img src="https://img.shields.io/badge/Entity%20Framework-Code%20First-success" />
  <img src="https://img.shields.io/badge/Database-MS%20SQL%20Server-blue" />
  <img src="https://img.shields.io/badge/Status-Completed-brightgreen" />
</p>

Modern işletmeler için geliştirilen bu web tabanlı **Ticari Otomasyon Sistemi**,  
stoktan satışa, faturadan kargo takibine kadar tüm ticari süreçleri **tek bir merkezden** yönetmeyi amaçlar.

Katmanlı mimari, rol bazlı yetkilendirme ve veritabanı seviyesinde otomasyon ile **ölçeklenebilir ve güvenli** bir yapı sunar.

---

## ✨ Highlights

✔️ Katmanlı mimari
✔️ Rol bazlı yetkilendirme (Admin / Personel / Cari)  
✔️ Trigger destekli otomatik stok ve fatura yönetimi  
✔️ Dinamik dashboard & grafikler  
✔️ Gerçek zamanlı veri takibi  

---

## 🧩 Modules

📦 **Ürün & Stok Yönetimi**  
👥 **Cari & Personel Yönetimi**  
💳 **Satış & Dinamik Fatura Sistemi**  
🚚 **Kargo Takip Modülü**  
💬 **Mesajlaşma (Internal Mail)**  
📊 **Dashboard & İstatistikler**  
📝 **To-Do (Görev) Yönetimi**  
📄 **PDF & QR Kod Çıktıları**

---

## 🏗️ Architecture

- ASP.NET MVC 5  
- N-Tier Architecture  
- Entity Framework (Code First)  
- ORM tabanlı veri erişimi  
- Role-Based Authorization  

**MVC yapısı**, kodun okunabilirliğini ve sürdürülebilirliğini artıracak şekilde uygulanmıştır.

---

## 🗄️ Database Design

- MS SQL Server  
- İlişkisel veri modeli  
- PK / FK ilişkileri  
- Veritabanı seviyesinde iş kuralları  

### ⚙️ Triggers
- 🧾 Fatura kalemi eklendiğinde toplam tutarın otomatik güncellenmesi  
- ➕ Ürün ekleme sonrası stok artışı  
- ➖ Satış sonrası stok azaltımı  

Bu sayede manuel müdahale olmadan **veri tutarlılığı** sağlanır.

---

## 👤 User Roles

### 🔑 Admin
- Tüm modüllere tam erişim  
- CRUD işlemleri  
- Raporlama ve sistem yönetimi  

### 👨‍💼 Personel
- Satış işlemleri  
- Kargo ve mesajlaşma  
- Görev yönetimi  

### 🧑‍💻 Cari
- Sipariş & fatura geçmişi  
- Kargo takibi  
- Mesajlaşma  
- Profil yönetimi  

---

## 🛠️ Tech Stack

- ASP.NET MVC 5  
- Entity Framework  
- MS SQL Server  
- LINQ  
- Bootstrap / AdminLTE  
- Chart.js / Google Charts  

---

## ▶️ Run Locally

```bash
1. Veritabanı script’lerini çalıştır
2. Web.config → connection string’i düzenle
3. Visual Studio üzerinden projeyi başlat
