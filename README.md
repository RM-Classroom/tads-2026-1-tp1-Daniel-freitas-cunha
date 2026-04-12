ETAPA 1 – MODELAGEM DO BANCO DE DADOS
1.1 Modelo Conceitual
O modelo conceitual do sistema foi desenvolvido com base no Diagrama Entidade-Relacionamento (DER), com o objetivo de representar as principais entidades e seus relacionamentos dentro do contexto de uma locadora de veículos.
As entidades definidas foram:
•	Cliente: responsável por armazenar os dados dos clientes, contendo atributos como Id, Nome, CPF e Email.
•	Veículo: representa os veículos disponíveis para locação, contendo atributos como Id, Modelo, Ano e Quilometragem.
•	Fabricante: responsável por armazenar as marcas dos veículos.
•	Categoria: classifica os veículos (Econômico, SUV, Luxo, entre outros).
•	Locação: representa o aluguel de veículos, contendo informações como Data de Início, Data de Fim, Data de Devolução, Quilometragem Inicial e Final, Valor da Diária e Valor Total.
Os relacionamentos foram definidos da seguinte forma:
•	Um cliente pode realizar várias locações (1).
•	Um veículo pode estar associado a várias locações (1).
•	Um veículo pertence a um único fabricante (N:1).
•	Um veículo pertence a uma única categoria (N:1).













Esse modelo atende às regras de negócio propostas, garantindo organização e consistência dos dados.
(A entidade CATEGORIA, foi a categoria Extra que foi acrescentada).




























________________________________________
1.2 Mapeamento com Entity Framework
O modelo conceitual foi convertido em um modelo relacional utilizando o Entity Framework, que atua como um mapeador objeto-relacional (ORM). Essa tecnologia permite a integração entre o código em C# e o banco de dados SQL Server.
As entidades foram representadas como classes no sistema, e os relacionamentos foram definidos por meio de propriedades de navegação e chaves estrangeiras.
Modelo Relacional – Gerado no SSMS













Classes
 
 

 

 
 


________________________________________
1.3 Chaves Primárias e Estrangeiras
Para garantir a integridade dos dados, foram definidas chaves primárias (Primary Keys) em todas as entidades e chaves estrangeiras (Foreign Keys) para representar os relacionamentos.
A entidade Locação possui chaves estrangeiras que referenciam Cliente e Veículo. Já a entidade Veículo possui chaves estrangeiras para Fabricante e Categoria.
Essas definições impedem inconsistências, garantindo que todos os registros estejam corretamente relacionados.











 

 





________________________________________
1.4 Implementação das Classes
As tabelas do banco de dados foram representadas por classes em C#, seguindo o padrão do Entity Framework.
Cada classe contém atributos que representam os campos das tabelas e propriedades de navegação que representam os relacionamentos entre as entidades.
 ________________________________________
1.5 Quantidade de Entidades
O sistema possui cinco entidades principais: Cliente, Veículo, Fabricante, Categoria e Locação, atendendo ao requisito mínimo proposto (sendo CATEGORIA a entidade extra que foi acrescentada.
________________________________________










ETAPA 2 – IMPLEMENTAÇÃO DO BACKEND
2.1 Desenvolvimento da API
O backend do sistema foi desenvolvido utilizando ASP.NET Core, seguindo o padrão de arquitetura RESTful. A aplicação permite a comunicação entre o cliente e o servidor por meio de requisições HTTP.
 
________________________________________
2.2 Operações CRUD
Foram implementadas operações CRUD (Create, Read, Update e Delete) para as principais entidades do sistema.
Essas operações permitem:
•	Criar novos registros
•	Consultar dados existentes
•	Atualizar informações
•	Remover registros
 
 
 
 
 
________________________________________
2.3 Integração com Banco de Dados
A integração com o banco de dados SQL Server foi realizada por meio do Entity Framework, permitindo manipular os dados de forma eficiente através do código.
 





________________________________________
2.4 Validação e Tratamento de Erros
Foram implementadas validações básicas para garantir a consistência dos dados e evitar erros na aplicação.
Foram utilizados retornos apropriados como:
•	BadRequest: quando os dados são inválidos
•	NotFound: quando um registro não é encontrado
Essas práticas melhoram a confiabilidade da API.________________________________________
2.5 Implementação de Filtros com JOIN
Foram implementados filtros utilizando joins entre múltiplas tabelas com o auxílio do Entity Framework.
Para isso, foram utilizados os métodos Include e ThenInclude, que permitem carregar dados relacionados em uma única consulta.
Esses filtros possibilitam a obtenção de informações completas, combinando dados de diferentes entidades.
















________________________________________
Filtro 1 – Locações por Cliente
Este filtro retorna todas as locações associadas a um cliente específico, incluindo os dados do veículo.

 

________________________________________







Filtro  – Veículos por Categoria
Este filtro retorna todos os veículos pertencentes a uma determinada categoria.
 
 
 
________________________________________
Filtro  – Veículos por Fabricante
Este filtro retorna todos os veículos de um fabricante específico.
 
 ________________________________________
Filtro 4 – Locações por Valor
Este filtro retorna locações com valor total acima de um determinado valor.
 ________________________________________
Filtro 5 – Relatório Completo de Locações
Este filtro retorna um relatório completo contendo dados da locação, cliente, veículo, categoria e fabricante.
 
 

 

________________________________________
Esses filtros demonstram o uso de diferentes tipos de joins entre tabelas, garantindo consultas mais completas e eficientes no sistema.





