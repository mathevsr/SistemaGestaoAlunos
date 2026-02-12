# SistemaGestaoAlunos – API REST

API REST desenvolvida em **ASP.NET Core (.NET 8)** para gestão de alunos, treinos e avaliações físicas.  
Projeto criado com foco em **aprendizado**, **boas práticas de backend** e **organização de código**, servindo como projeto de portfolio.

---

## 📌 Objetivo do Projeto

O objetivo deste projeto é praticar conceitos fundamentais do desenvolvimento backend, como:

- Arquitetura em camadas
- Criação de APIs REST
- Separação de responsabilidades
- Injeção de dependência
- Programação assíncrona
- Organização e versionamento de código com Git

---

## 🧱 Arquitetura

O projeto segue uma **arquitetura em camadas**, separando claramente as responsabilidades:

API → Application → Domain → Infrastructure

### 📂 Camadas

- **API**
  - Controllers
  - Endpoints HTTP
  - Configuração da aplicação

- **Application**
  - Services
  - DTOs (Data Transfer Objects)
  - Regras de aplicação

- **Domain**
  - Entidades
  - Regras de negócio

- **Infrastructure**
  - Acesso a dados
  - Entity Framework Core
  - Configuração do DbContext

---

## 🚀 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Swagger (OpenAPI)
- C#
- Git e GitHub

---

## 📡 Endpoints Principais

### Alunos

| Método | Rota               | Descrição                |
|------|----------------------|--------------------------|
| POST | `/api/alunos`        | Criar um novo aluno      |
| GET  | `/api/alunos`        | Listar todos os alunos   |
| GET  | `/api/alunos/{id}`   | Buscar aluno por ID      |
| PUT  | `/api/alunos/{id}`   | Atualizar aluno          |
| DELETE | `/api/alunos/{id}` | Remover aluno            |


## 🧪 Exemplo de Payload (Criar Aluno)

```json
{
  "nome": "Matheus Souza",
  "dataNascimento": "1995-05-10",
  "altura": 1.75,
  "peso": 80
}
```
## ▶️ Como Executar o Projeto

### Pré-requisitos
- .NET 8 SDK
- Visual Studio ou VS Code

### Passos
```bash
dotnet restore
dotnet run

Acesse a documentação da API via Swagger:

https://localhost:5001/swagger
````
## 📌 Status do Projeto
🚧 Em desenvolvimento — novas features em andamento (Autenticação, Treinos, Avaliações Físicas)
