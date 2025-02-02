
# Management Employee API

	This API is for management of the Employee on company, the endpoints "Servem" of send and request informations, "Siga" the instructions for run Projects


### Pré requisitos

	* Docker
	* .Net 8
	* Visual Studio (ou outra IDE)
	

## Docker Configurations

This projects use docker for Up database MySQL, "Siga" the instructions for Up Container

* Access Folder ```db``` in repository
* Run command ```docker-compouse -d``` and waiting 
* if success acess your database with database IDE


### Runer Migration database for init Application

to back has the instructions for runner comands migration 

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



