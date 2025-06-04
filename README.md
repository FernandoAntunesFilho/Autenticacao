# Autenticação

Projeto de autenticação em .NET 8.0, utilizando JWT para autenticação de usuários.

## Estrutura do Projeto

- `Controllers/` - Controladores da API (ex: UserController)
- `DTO/` - Objetos de transferência de dados para requisições e respostas de login
- `Models/` - Modelos de domínio (ex: User)
- `Repositories/` - Interfaces e implementações para acesso a dados de usuários
- `Services/` - Serviços de negócio (pasta reservada)
- `TokenConstants.cs` - Constantes relacionadas ao token JWT
- `Program.cs` - Ponto de entrada da aplicação
- `appsettings.json` - Configurações da aplicação

## Como rodar

1. Instale o [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
2. Restaure os pacotes:
   ```sh
   dotnet restore
   ```
3. Execute a aplicação:
   ```sh
   dotnet run
   ```

## Endpoints

- **POST** `/login`  
  Recebe um usuário e senha, retorna um token JWT em caso de sucesso.

- **POST** `/signup`
  Recebe dados de um novo usuário e retorna um token JWT.

## Configuração do Token

O segredo do token JWT está definido em [`TokenConstants.Secret`](TokenConstants.cs):

```csharp
public const string Secret = "4d82a63bbdc67c1e4784ed6587f3730c";
```

Altere este valor para um segredo mais seguro em produção.

## Observações

- O projeto utiliza pacotes como `Microsoft.AspNetCore.Authentication.JwtBearer` e `System.IdentityModel.Tokens.Jwt` para autenticação.
- As configurações de ambiente podem ser ajustadas em `appsettings.json` e `appsettings.Development.json`.

---