# AnonyQuest

O referente projeto foi desenvolvido em acompanhamento das atividades e conteúdo presentes no curso sobre Blazor da plataforma Udemy (https://www.udemy.com/share/102l0iCEUYc1hTTXo=/), gerenciada pelo engenheiro de Software, *Felipe Gavilán*.

Foi utilizado Blazor, IdentityServer4, Entity Framework Core e outros afins versionados para .Net Core 3.1

## Instruções de execução: 

- após clonar o projeto na máquina local, 
- abrir e compilar a solution com o visual studio 2019 
- pressionar sequencialmente as teclas: 'Alt', 'T', 'N' e 'O' para abrir o console de gerenciamento de pacotes Nuget
- inserir o comando "update-database" para executar o arquivo de migração e criar o banco de dados local
- ao executar o projeto, instale o certificado SSL que será solicitado

## Mascaramento do banco:

Para efetivar o mascaramento no banco de dados com sua finalidade de restringir a exposição de dados sensíveis, 
existe a dependência de um banco de dados com um servidor registrado que não seja o localdb, gerando a necessidade de credenciais específicas para acesso de leitura e facilitando o controle de acesso ao banco.

A fim de validar o comportamento dessa funcionalidade, é possível seguir os passos presentes no link https://www.sqlshack.com/using-dynamic-data-masking-in-sql-server-2016-to-protect-sensitive-data/


### Fazendo o procedimento para o localdb

- Abra o Microsoft SQL Server Management Studio, no modelo de autenticação como Windows insira o nome do servidor como (localdb)\MSSQLLocalDB

- aplique as queries DDL a seguir:

ALTER TABLE Answer  
ALTER COLUMN UserEmail nvarchar(max) MASKED WITH (FUNCTION = 'default()') not null;   

ALTER TABLE ReceiverQuestionnaire  
ALTER COLUMN ReceiverEmail nvarchar(450) MASKED WITH (FUNCTION = 'default()') not null;  

- Crie um usuário

CREATE USER TestMask WITHOUT LOGIN;  
GRANT SELECT ON Answer TO TestMask; 
GRANT SELECT ON ReceiverQuestionnaire TO TestMask; 

- Execute o query de leitura com esse usuário criado

EXECUTE AS USER = 'TestMask';  
SELECT * FROM ReceiverQuestionnaire;
SELECT * FROM Answer;

