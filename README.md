# Plataforma integrada
Exercício feito com único propósito de ingresso no processo de seleção para oportunidade de desenvolvimento na Uppertools Tecnologia da Informação

# Justificativas
Este projeto foi desenvolvido com a ferramenta **Entity Framework** na plataforma **.NET 4.7** e **C# 7.0**, com utilizando o Visual Studio como IDE a fim de facilitar o desenvolvimento da solução. Também por meio do Entity Framework foi possível a abordagem Code-First, com uso de migrações de bancos de dados a partir das classes geradas por código em C#.
Além disso, utiliza-se ao máximo arquitetura REST, com a utilização dos métodos HTTP para inserção, listagem e deleção além disso, procura-se ao máximo o uso de códigos de status às respostas em conformidade com as recomendações do IANA.
Para o desenvolvimento do projeto, preferiu-se a implementação da versão Web API à solução do problema proposto por simples questão de afinidade, sendo possível dessa forma obter o máximo de proveito dos recursos da linguagem e das ferramentas utilizadas aqui, sem preocupações com problemas menos funcionais, como layout e disposição dos elementos, por exemplo. De mesma forma ocorre para a opção por uso de banco de dados local MSSQLLocalDB
De certa maneira, foi possível notar alguma dificuldade na implementação deste projeto quanto à utilização da ferramenta Entity Framework, seja este o primeiro projeto utilizando tal ferramenta. Entretanto, foi-se possível entender melhor e driblar os erros causados, podendo dar prosseguimento ao desenvolvimento da aplicação.

## Arquitetura
Algumas separações de conceitos feitas:
- **Model:** Aqui deverão estar as entidades a serem modeladas para os bancos de dados da aplicação.
- **Controller:** Aqui estão as classes controladoras da aplicação e instanciações da maioria dos objetos a serem utilizados.
- **Resources:** Nesta pasta ficam as classes que têm referências externas à aplicação, não sendo exatamente partes integrantes da solução.
- **Repository:** Aqui se implementa a classe principal para as inserções no banco de dados. Sendo em torno da qual roda a maioria das funcionalidades da aplicação.


> É possível rodar a aplicação utilizando **Visual Studio** com **Entity Framework** instalado utilizando o comando _update-database_

## Dificuldades gerais
Na rota do aprendizado há sempre pedras no caminho. Às vezes maiores, às vezes menores. O importante é sempre caminhar. E é importante perceber os pontos de dificuldade para saber lidar com eles numa próxima caminhada.
Gostaria então de ressaltar aqui alguma dificuldade para o entendimento do mecanismo do Entity Framework. Que, de tão fácil e inteligente, algumas coisas acontecem sem que nem saibamos (haha).
Também ressalto uma dificuldade para o registro dos vetores de vetores. As listas de propriedades da entidade Empresa, como ```List<Atividade_Principal>```, que nunca era gravada no banco de dados a princípio e depois nunca era retornada do jeito como deveria, acabando com um nome no singular para representar uma lista dessa entidade. Além disso, terminou retornando algumas propriedades que não deveriam ser acessíveis ao Cliente, como Id para registro no Banco, que, para isso, foi iniciada a tentativa de uma abordagem de ModelFactory para a entidade Empresa, mas que não foi possível implementar por completo.
No entando, foi um projeto definitivamente muito prazeroso.

## Conclusão
Agradeço à Uppertools pela oportunidade de desenvolver este projeto, com o qual não tenho como mensurar o quanto aprendi, me descabelei e pulei de alegria.
Espero muito poder participar deste time de desenvolvimento.

Gratidão !
