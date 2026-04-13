**ETAPA 1 – MODELAGEM DO BANCO DE DADOS**

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


<img width="971" height="615" alt="image" src="https://github.com/user-attachments/assets/3690889f-f1e3-4e1b-8551-ae3efd2cf2a0" />



Esse modelo atende às regras de negócio propostas, garantindo organização e consistência dos dados.
(A entidade CATEGORIA, foi a categoria Extra que foi acrescentada).




________________________________________
1.2 Mapeamento com Entity Framework
O modelo conceitual foi convertido em um modelo relacional utilizando o Entity Framework, que atua como um mapeador objeto-relacional (ORM). Essa tecnologia permite a integração entre o código em C# e o banco de dados SQL Server.
As entidades foram representadas como classes no sistema, e os relacionamentos foram definidos por meio de propriedades de navegação e chaves estrangeiras.

Modelo Relacional – Gerado no SSMS



<img width="951" height="567" alt="image" src="https://github.com/user-attachments/assets/9e07a8b0-9723-4c62-9a36-278d7274533c" />



Classes
 
 
<img width="886" height="397" alt="image" src="https://github.com/user-attachments/assets/8bcba1bf-9dd7-4a12-896d-ab774c1c1649" />



<img width="886" height="345" alt="image" src="https://github.com/user-attachments/assets/2f297764-a333-444b-8efb-12f4018abd1e" />



<img width="886" height="457" alt="image" src="https://github.com/user-attachments/assets/99235b16-197a-46db-adf9-dfccdd78431f" />


 
 <img width="886" height="519" alt="image" src="https://github.com/user-attachments/assets/4e184bda-1b36-478c-98c0-dee8156af817" />

 

 <img width="886" height="493" alt="image" src="https://github.com/user-attachments/assets/855e8361-4cf5-42a2-8890-7aaefd029941" />


 
________________________________________
1.3 Chaves Primárias e Estrangeiras
Para garantir a integridade dos dados, foram definidas chaves primárias (Primary Keys) em todas as entidades e chaves estrangeiras (Foreign Keys) para representar os relacionamentos.
A entidade Locação possui chaves estrangeiras que referenciam Cliente e Veículo. Já a entidade Veículo possui chaves estrangeiras para Fabricante e Categoria.
Essas definições impedem inconsistências, garantindo que todos os registros estejam corretamente relacionados.


<img width="1018" height="614" alt="image" src="https://github.com/user-attachments/assets/0e76883e-ad03-4118-a81a-e3e246191700" />

<img width="886" height="636" alt="image" src="https://github.com/user-attachments/assets/acf00ff6-4756-4815-a595-b9909a8830ce" />

<img width="886" height="441" alt="image" src="https://github.com/user-attachments/assets/036bb349-b8ba-48e2-b5d7-2d1cd9ce346d" />


________________________________________
1.4 Implementação das Classes
As tabelas do banco de dados foram representadas por classes em C#, seguindo o padrão do Entity Framework.
Cada classe contém atributos que representam os campos das tabelas e propriedades de navegação que representam os relacionamentos entre as entidades.

<img width="886" height="517" alt="image" src="https://github.com/user-attachments/assets/49a28fa4-4236-48bb-8494-9da37fa95fb6" />

 ________________________________________
1.5 Quantidade de Entidades
O sistema possui cinco entidades principais: Cliente, Veículo, Fabricante, Categoria e Locação, atendendo ao requisito mínimo proposto (sendo CATEGORIA a entidade extra que foi acrescentada.
________________________________________


ETAPA 2 – IMPLEMENTAÇÃO DO BACKEND
2.1 Desenvolvimento da API
O backend do sistema foi desenvolvido utilizando ASP.NET Core, seguindo o padrão de arquitetura RESTful. A aplicação permite a comunicação entre o cliente e o servidor por meio de requisições HTTP.

<img width="886" height="478" alt="image" src="https://github.com/user-attachments/assets/b92b5b9d-0c13-4c60-878a-6a9c016314c3" />

 
________________________________________
2.2 Operações CRUD
Foram implementadas operações CRUD (Create, Read, Update e Delete) para as principais entidades do sistema.
Essas operações permitem:
•	Criar novos registros
•	Consultar dados existentes
•	Atualizar informações
•	Remover registros
 
 
 <img width="886" height="481" alt="image" src="https://github.com/user-attachments/assets/e124d60c-c87c-428c-af29-16c6b752d428" />
 
<img width="886" height="768" alt="image" src="https://github.com/user-attachments/assets/3c40f087-61bd-49dc-bb7c-4dc87c40ceab" />

<img width="886" height="435" alt="image" src="https://github.com/user-attachments/assets/8bdc54e3-f74a-4a0e-8221-d371e3566268" />

<img width="886" height="768" alt="image" src="https://github.com/user-attachments/assets/b9317e4c-476c-423d-bc5c-b21e8802f889" />

<img width="886" height="755" alt="image" src="https://github.com/user-attachments/assets/d52fe2f8-1f11-4604-bb16-a5492a7b81f9" />


 
 
________________________________________
2.3 Integração com Banco de Dados
A integração com o banco de dados SQL Server foi realizada por meio do Entity Framework, permitindo manipular os dados de forma eficiente através do código.
 

<img width="886" height="215" alt="image" src="https://github.com/user-attachments/assets/7607c1d6-0eee-4e73-9e2a-934dbae290a6" />




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
<img width="886" height="812" alt="image" src="https://github.com/user-attachments/assets/42a13787-28b7-4d12-83a7-0c9c7647e258" />


 

________________________________________



Filtro  – Veículos por Categoria
Este filtro retorna todos os veículos pertencentes a uma determinada categoria.
 
 
 <img width="886" height="526" alt="image" src="https://github.com/user-attachments/assets/34771f1f-5294-4224-9cc9-ed4247c6f0cf" />
 
<img width="886" height="517" alt="image" src="https://github.com/user-attachments/assets/b7cb414e-90e3-41ad-b734-c90cbf1741c4" />

<img width="886" height="591" alt="image" src="https://github.com/user-attachments/assets/0c71a173-6df2-420e-8e9c-f70fbeb85ee6" />


________________________________________
Filtro  – Veículos por Fabricante
Este filtro retorna todos os veículos de um fabricante específico.

<img width="886" height="535" alt="image" src="https://github.com/user-attachments/assets/e926aff3-7665-46a7-b975-dff196e918b9" />

 <img width="886" height="441" alt="image" src="https://github.com/user-attachments/assets/65e998d9-4843-4a13-8448-7ba7579b2f39" />

 ________________________________________
Filtro 4 – Locações por Valor
Este filtro retorna locações com valor total acima de um determinado valor.

<img width="853" height="239" alt="image" src="https://github.com/user-attachments/assets/739dac29-bbea-4d3f-9d83-014f77853a8f" />

 ________________________________________
Filtro 5 – Relatório Completo de Locações
Este filtro retorna um relatório completo contendo dados da locação, cliente, veículo, categoria e fabricante.
 
 <img width="770" height="338" alt="image" src="https://github.com/user-attachments/assets/9584d3b9-25af-455c-ab05-18d0d318a7d8" />
 
<img width="886" height="482" alt="image" src="https://github.com/user-attachments/assets/1c3f248a-7095-4220-9287-7e57bf74a64f" />

<img width="886" height="472" alt="image" src="https://github.com/user-attachments/assets/21cb0f3f-fed4-4fca-8ec2-7fbc65bb9133" />

______________________
Esses filtros demonstram o uso de diferentes tipos de joins entre tabelas, garantindo consultas mais completas e eficientes no sistema.





