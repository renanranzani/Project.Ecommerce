
<h1 align="center">Ecommerce</h1>

---
## 💻 Sobre o projeto
  
<p align="justify">
  Desenvolvimento de CRUD de uma loja virtual.  
</p>

## ⚙️ Funcionalidades

 - [x] Criação de Produto;
 - [x] Exibição de telas de cadastro e visualização;

---
## 🛠 Tecnologias

.NET 5 <br>
Angular 14.1.0

---
## Migrations

dotnet ef migrations add InitialCreate --project Project.Ecommerce.Infrastructure -s Project.Ecommerce.API <br>
dotnet ef database update --project Project.Ecommerce.Infrastructure -s Project.Ecommerce.API
