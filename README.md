# 🎮 FIAP Cloud Games – Fase 1

## 📌 Objetivo

Desenvolver uma API REST em .NET 8 para gerenciamento de usuários e biblioteca de jogos digitais, incluindo autenticação, controle de acesso e persistência de dados.

---

## 🚀 Como executar o projeto

### 1. Clonar o repositório

git clone <seu-repositorio>
cd FiapCloudGames

---

### 2. Configurar o banco

No arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "ConnectionString": "Server=.;Database=FiapCloudGames;Trusted_Connection=True;TrustServerCertificate=True"
}
```
### 3. Rodar migrations

dotnet ef database update --project Infrastructure --startup-project FiapCloudGames

### 4. Executar a API

dotnet run --project FiapCloudGames

### 5. Acessar Swagger

https://localhost:<porta>/swagger

🔑 Autenticação

1 - Faça Login em: POST /Auth/Login
2 - Copie o token retornado
3 - Clique em Authorize no Swagger
4 - Informe: Bearer SEU_TOKEN

📚 Principais funcionalidades
Gerenciamento de usuários (Admin)
Autenticação via JWT
Cadastro de jogos (Admin)
Criação de promoções (Admin)
Aquisição de jogos pelo usuário
Consulta da biblioteca do usuário
