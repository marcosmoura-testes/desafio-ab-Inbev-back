
# API de Funcionários

API dedicada a gerenciar as informações dos Funcionários

## Configuração do Ambiente de trabalho

Inciando a configuração do ambiente do desenvolvedor.

### Criando o banco de dados

* Pré requisitos: 
Para criar o banco de dados estamos utilizando um container Docker do banco de dados MySQL que fica dentro da pasta **db** do repositório.

Acesse a pasta `./db` e execute o comando para iniciar o Docker



#### Rodando o Migration para criar as tabelas



Atualização do banco de dados

* Criando um novo Migrate
	- dotnet ef migrations add AtualizandoColunas --project ../infra --startup-project .
	
* Atualizando o banco com as alterações
	- dotnet ef database update --project ../infra --startup-project .

* Remove o ultimo Migrate
	- dotnet ef migrations remove --project ../infra --startup-project .

* Verifica o Status do Migrate
	- dotnet ef migrations list --project ../infra --startup-project .

* Aplicar migration expecífica
	- dotnet ef database update [[NOME DA MIGRATION]] --project ../infra --startup-project .

* Reverte uma migration expecífica
	- dotnet ef database update NomeDaMigrationAnterior --project ../infra --startup-project .



