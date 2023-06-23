# ProductManager

API em .NET 5, contendo um CRUD simples e seperando bem as responsabilidades de cada camada da aplicação.
- 01 - Application - Onde está nossa API.
- 02 - Services - Nossos DTOs, Validators, Mappers, ErrorValidation e Serviços.
- 03 - Domain - Entidade, Builder, nosso contrato com Repository e nosso DomainValidationException.
- 04 - Infra - Particionado em dois projetos.
- 04.01 - Data - Context, mapeamento do modelo e o Repositor.
- 04.02 - CrossCutting - IoC.
- 05 - Test - Testes xUnit.
