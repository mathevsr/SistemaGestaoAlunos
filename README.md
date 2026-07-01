# SistemaGestaoAlunos – API REST

API REST desenvolvida em ASP.NET Core (.NET 8) para gestão de alunos, treinos e avaliações físicas.

Projeto criado com foco em aprendizado, boas práticas de backend e organização de código, servindo como projeto de portfólio.

---

## 📌 Objetivo do Projeto

Praticar conceitos fundamentais do desenvolvimento backend:

- Arquitetura em camadas
- Criação de APIs REST
- Autenticação e segurança com JWT
- Repository Pattern
- Separação de responsabilidades
- Injeção de dependência
- Programação assíncrona
- Organização e versionamento de código com Git

---

## 🧱 Arquitetura

O projeto segue arquitetura em camadas com fluxo unidirecional de dependências:

```
API → Application → Domain → Infrastructure
```

### 📂 Camadas

**API**
- Controllers
- Endpoints HTTP
- Configuração da aplicação (Program.cs)

**Application**
- Services
- DTOs (Data Transfer Objects)
- Regras de aplicação

**Domain**
- Entidades
- Interfaces de repositório
- Regras de negócio

**Infrastructure**
- Implementação dos repositórios
- Entity Framework Core
- Configuração do DbContext
- Migrations

---

## 🚀 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT (JSON Web Token)
- BCrypt.Net
- Swagger (OpenAPI)
- C#
- Git e GitHub

---

## 📡 Endpoints

### Auth

| Método | Rota | Descrição | Auth |
|--------|------|-----------|------|
| POST | /api/auth/register | Registrar usuário | ❌ |
| POST | /api/auth/login | Autenticar e obter token | ❌ |

### Alunos

| Método | Rota | Descrição | Auth |
|--------|------|-----------|------|
| POST | /api/alunos | Criar aluno | ✅ |
| GET | /api/alunos | Listar alunos | ✅ |
| GET | /api/alunos/buscar | Buscar por nome | ✅ |
| PUT | /api/alunos/{id} | Atualizar aluno | ✅ |
| DELETE | /api/alunos/{id} | Remover aluno | ✅ |

---

## 🧪 Exemplos de Payload

**Register**
```json
{
  "nome": "Matheus",
  "email": "matheus@email.com",
  "senha": "suasenha123"
}
```

**Login**
```json
{
  "email": "matheus@email.com",
  "senha": "suasenha123"
}
```

**Criar Aluno**
```json
{
  "nome": "Matheus Souza",
  "dataNascimento": "1995-05-10",
  "altura": 1.75,
  "peso": 80
}
```

---

## 🔐 Autenticação

A API utiliza JWT (JSON Web Token). Para acessar os endpoints protegidos:

1. Registre um usuário em `POST /api/auth/register`
2. Faça login em `POST /api/auth/login` e copie o token retornado
3. Nas requisições, envie o header:

```
Authorization: Bearer {token}
```

---

## ▶️ Como Executar

**Pré-requisitos**
- .NET 8 SDK
- SQL Server
- Visual Studio ou VS Code

**Passos**

```bash
dotnet restore
dotnet ef database update --project SistemaGestaoAlunos.Infrastructure --startup-project SistemaGestaoAlunos.Api
dotnet run --project SistemaGestaoAlunos.Api
```

Acesse o Swagger em: `https://localhost:7241/swagger`

---

## 📌 Status do Projeto

🚧 Em desenvolvimento — próximas features: Treinos e Avaliações Físicas
