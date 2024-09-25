# Sistema 123 Vendas


## Configurando o Projeto 

Abra o projeto e certifique-se de que as connections strings irão apontar para um servidor local do seu SQL Server. Todas eles estão no arquivo .json do projeto SistemaVendasWebAPI. 

Abra o Package Manager Console (Visual Studio) e selecione o projeto de infrastructure.Data e rode o comando "update-database" (Migrations) para criar a intância do banco de dados e toda a sua estrutura (tabelas, colunas, chaves.. etc.). 

Selecione o projeto Web chamado SistemaVendasWebAPI como projeto de inicialização no Visual Studio. 

Rode a aplicação e no Swagger navegue pelos serviços de criação, edição e remoção de Vendas e Clientes. 

O seed do migration irá deixar alguns dados pré cadastrados de Clientes e Produtos, para que se possa fazer operações de vendas pelo sistema. 

## Arquitetura do Projeto 

O projeto foi separado em camadas se baseando na arquitetura original do DDD adaptada para o tipo de projeto em questão. A arquitetura foi feita de forma que pudesse ser expandida para um grande projeto sem dificuldades. 

O projeto SistemaVendasWebAPI faz parte da camada de apresentação enquanto as outras camadas tem seu nome por si só tal qual sua função, como Application sendo a aplicação de serviços do projeto, Domain o domínio cerebral de toda a estrutura e o Infrastructure sendo a parte responsável pelos dados do projeto. O modelo de injeção de dependência foi feito pela CrossCutting, onde colocamos configurações inerentes a qualquer parte do projeto.  

Toda proteção do projeto foi pensada para ser feita com JWT (apesar de não implementado) e todo mapeamento de valores com as instâncias dos objetos foram feitas com AutoMapper. 

Os objetos foram feitos com desnormalização e External Identities, fazendo objetos únicos e tendo cada domínio seu próprio descritivo informativo sem precisar de uma responsabilidade ou ligação de outra entidade domínio ligada a ele. 

As operações foram destacadas com logs, usando Serialog na camada de application. De forma que poder ser substituida por um message broker facilmente no futuro.

## Considerações Finais 

Fiz o máximo que pude sobre o projeto tendo em vista que não tive muito tempo livre. Mas acredito que já de pra passar toda a minha bagagem de conhecimento por ele. 

No mais, qualquer dúvida sobre o projeto, peço para que entre em contato com o desenvolvedor. 

## Autor 
Jonathan Crístian Ribeiro Coelho