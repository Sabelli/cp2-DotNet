# 🎬 CP2 - API REST de Filmes e Avaliações

API RESTful desenvolvida em ASP.NET Core para gerenciamento de filmes e avaliações, com persistência em banco de dados Oracle e documentação via Swagger.

---

## Integrantes do Grupo

| Nome | RM |
|------|----|
| Victor Sabelli | RM566224 |
| Gustavo Crevelari | RM561408 |
| Lucca Gomes | RM561996 |
| Rafaela Ferreira | RM561671 |

---

## Tecnologias Utilizadas

- C# / .NET 8
- ASP.NET Core Web API (Controllers)
- Entity Framework Core
- Oracle Database
- Swagger (OpenAPI / Swashbuckle)

---

## Como Rodar o Projeto

### Pré-requisitos

- .NET 8 SDK instalado
- Acesso ao banco de dados Oracle
- Visual Studio 2022 ou VS Code

### Passo a passo

1. Clone o repositório:
```bash
git clone https://github.com/Sabelli/cp2-DotNet
```

2. Configure a connection string no `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "OracleConnection": "Data Source=oracle.fiap.com.br:1521/orcl;User Id=SEU_RM;Password=SUA_SENHA;"
  }
}
```

3. Aplique as migrations:
```bash
dotnet ef database update
```

4. Execute o projeto:
```bash
dotnet run
```

5. Acesse o Swagger em:
```
https://localhost:{porta}/swagger
```

---

## Endpoints Disponíveis

### Filme — `/api/filme`

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/filme` | Lista todos os filmes |
| GET | `/api/filme/{id}` | Busca um filme pelo ID |
| GET | `/api/filme/catalogo/{genero}` | Busca filmes por gênero |
| GET | `/api/filme/lancamento/{anoLancamento}` | Busca filmes por ano de lançamento |
| POST | `/api/filme` | Adiciona um novo filme |
| PUT | `/api/filme/{id}` | Edita um filme existente |
| DELETE | `/api/filme/{id}` | Remove um filme |

### Avaliação — `/api/avaliacao`

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/avaliacao` | Lista todas as avaliações |
| GET | `/api/avaliacao/{id}` | Busca uma avaliação pelo ID |
| GET | `/api/avaliacao/filme/{filmeId}` | Busca avaliações de um filme específico |
| POST | `/api/avaliacao/{filmeId}` | Adiciona uma avaliação para um filme |
| PUT | `/api/avaliacao/{id}` | Edita uma avaliação existente |
| DELETE | `/api/avaliacao/{id}` | Remove uma avaliação |

---

## 📦 Exemplos de Requisição (JSON)

### POST `/api/filme` — Criar filme

```json
{
  "titulo": "Interestelar",
  "anoLancamento": 2014,
  "genero": "Ficção Científica",
  "duracaoMin": 169
}
```

### PUT `/api/filme/{id}` — Editar filme

```json
{
  "titulo": "Interestelar",
  "anoLancamento": 2014,
  "genero": "Ficção Científica",
  "duracaoMin": 169
}
```

### POST `/api/avaliacao/{filmeId}` — Criar avaliação

```json
{
  "autor": "João Silva",
  "nota": 9,
  "comentario": "Filme incrível, roteiro impecável."
}
```

### PUT `/api/avaliacao/{id}` — Editar avaliação

```json
{
  "autor": "João Silva",
  "nota": 10,
  "comentario": "Revi e continua sendo obra-prima.",
  "filmeId": 1
}
```

---

## 📊 Status Codes Utilizados

| Status | Situação |
|--------|----------|
| `200 OK` | Operação realizada com sucesso |
| `204 No Content` | Nenhum dado encontrado |
| `400 Bad Request` | Dados inválidos ou erro inesperado |
| `404 Not Found` | Recurso não encontrado |

---

## 🗄️ Estrutura do Projeto

```
cp2-DotNet/
├── .github/
├── .gitignore
├── README.md
└── CP2-DotNet/
    ├── CP2-DotNet.slnx
    └── CP2-DotNet.API/
        ├── Controllers/
        │   ├── AvaliacaoController.cs
        │   └── FilmeController.cs
        ├── Data/
        │   └── ApplicationContext.cs
        ├── Migrations/
        ├── Models/
        │   ├── AvaliacaoEntity.cs
        │   └── FilmeEntity.cs
        ├── Properties/
        ├── appsettings.json
        ├── appsettings.Development.json
        └── Program.cs
```

---

## 🗃️ Modelagem das Entidades

### FilmeEntity (`tb_filme`)

| Campo | Tipo | Validação |
|-------|------|-----------|
| Id | int | Chave primária |
| Titulo | string | Obrigatório, 1–200 caracteres |
| AnoLancamento | int | Obrigatório, entre 1888 e 2100 |
| Genero | string | Obrigatório, 1–50 caracteres |
| DuracaoMin | int | Obrigatório, entre 1 e 51420 minutos |

### AvaliacaoEntity (`tb_avaliacao`)

| Campo | Tipo | Validação |
|-------|------|-----------|
| Id | int | Chave primária |
| Autor | string | Obrigatório, 3–100 caracteres |
| Nota | int | Obrigatório, entre 1 e 10 |
| Comentario | string? | Opcional, máximo 1000 caracteres |
| DataAvaliacao | DateTime | Gerado automaticamente |
| FilmeId | int | Obrigatório, FK para Filme |