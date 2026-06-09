favor ler o readme da branch de devops caso esteja interessado no desenvolvimento referente à matéria de Devops Tools & Cloud Computing

# NEO HORIZON - PREDIÇÃO DE COLISÃO DE DETRITOS ORBITAIS
A Neo Horizon API é uma aplicação REST desenvolvida em ASP.NET Core para o gerenciamento de objetos espaciais e simulação de possíveis colisões entre eles.

O sistema permite cadastrar, consultar, atualizar e remover objetos espaciais armazenados em banco de dados. Além disso, possui uma funcionalidade de predição que calcula a posição futura dos objetos e identifica possíveis colisões com base na distância entre eles e em seus respectivos raios.

Este projeto foi desenvolvido utilizando ASP.NET Core, Entity Framework Core e Oracle Database, seguindo uma arquitetura em camadas para facilitar a manutenção e organização do código.
## Video de Demonstração
https://youtu.be/1y4Ur5C31Vs

## Video pitch
https://youtu.be/huuaQSYgBt4

## Diagramas
  - Diagrama da arquitetura

<img width="360" height="775" alt="image" src="https://github.com/user-attachments/assets/1260ba90-f89a-416d-9ce4-9a897172765b" />

- Diagrama de Classes
<img width="535" height="478" alt="image" src="https://github.com/user-attachments/assets/2e14f712-ed73-4925-9d46-5ea03605a920" />

- Fluxo do Sistema de Predição
<img width="307" height="1179" alt="pehis drawio" src="https://github.com/user-attachments/assets/3062fabe-0574-4bbc-a396-2ea9325d5e9c" />

## Desenvolvimento
Tecnologias Utilizadas
ASP.NET Core 9
Entity Framework Core
Oracle Database
Swagger/OpenAPI
Dependency Injection
REST API
Arquitetura

O projeto foi desenvolvido seguindo uma arquitetura em camadas:

- Controllers: recebem as requisições HTTP.
- Services: concentram as regras de negócio.
- Data Layer (Entity Framework): responsável pela persistência dos dados.
- Oracle Database: armazenamento permanente dos objetos espaciais.
Funcionalidades:
- Space Objects
- Cadastro de objetos espaciais
- Consulta de objetos
- Atualização de objetos
- Remoção de objetos
- Collision Prediction
- Busca todos os objetos cadastrados
- Simula a posição futura após 60 segundos
- Calcula a distância entre todos os pares de objetos
- Determina possíveis colisões utilizando a soma dos raios dos objetos

## Instruções para acesso e exemplo de testes

### Pré-requisitos

Antes de iniciar, certifique-se de possuir os seguintes softwares instalados:

* .NET SDK 9.0 ou superior
* Oracle Database
* Git

### Clonando o repositório

```bash
git clone https://github.com/Primeira-Global-Solution-2semstre/Csharp
cd Csharp
```

### Configurando a conexão com o banco de dados

Abra o arquivo `appsettings.json` e configure a string de conexão com seu banco Oracle:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "User Id=usuario;Password=senha;Data Source=host:1521/servico"
  }
}
```

### Aplicando as migrations

Execute o comando abaixo para criar ou atualizar as tabelas do banco de dados:

```bash
dotnet ef database update
```

### Executando a aplicação

Inicie a API com o comando:

```bash
dotnet run
```

Após a inicialização, a API estará disponível em um endereço semelhante a:

```text
https://localhost:5001
```

ou

```text
http://localhost:5000
```

### Acessando a documentação Swagger

Com a aplicação em execução, acesse:

```text
https://localhost:5001/swagger
```

Através do Swagger é possível visualizar e testar todos os endpoints da API.

### Endpoints disponíveis

#### Objetos Espaciais

* `GET /api/spaceobjects`
* `GET /api/spaceobjects/{id}`
* `POST /api/spaceobjects`
* `PUT /api/spaceobjects/{id}`
* `DELETE /api/spaceobjects/{id}`

#### Predições de Colisão

* `GET /api/predictions`

