# Desenvoldedor.IO - Nerd Store Enterprise

O objetivo é criar uma aplicação _e-commerce_ voltada para a área corporativa usando boas práticas e estratégias levando em consideração escalabilidade, segurança, modelagem do negócio/software e afins.

---

## Visão geral da arquitetura adotada

A arquitetura proposta para esta aplicação não serve de modelo ou template para qualquer outra. Assim cada aplicação deve ter uma arquitetura específica de acordo com o cenário e nuances do problema do negócio. Assim, a arquitetura da aplicação é diretamente proporcional a complexidade do negócio.

Dado o contexto, a solução arquitetural adotada para esta aplicação é a **distribuída**, ou também comumente chamada de **monolíto distribuído**. Uma das suas principais características é a divisão da aplicação por [contextos delimitados](https://www.eduardopires.net.br/2016/03/ddd-bounded-context/), consequentemente distribuindo a aplicação em serviços responsáveis, onde cada um cuida de um subdomínio do negócio. A imagem abaixo demonstra a visão geral da arquitetura, contendo 6 contextos delimitados (subdomínios), que são: **Pagamentos, Clientes, Catalogos, Pedidos (core da aplicação), Carrinho e Pagamentos**.

![Arquitetura da aplicação](./docs/arquitetura-aplicacao.png)

Esta aplicação **não possui uma arquitetura em microserviços, e sim baseada em microserviços**. Isto se dá porque ela abre mão de "regras" que são necessárias em uma aplicação em microserviços. Além disso, aplicações nesse estilo arquitetural são complexas e quase sempre desnecessárias para o contexto do problema de negócio que se deseja resolver, como é citado pelo Eduardo Pires:

> *"Usar aplicações em microservices são para poucos cenários, onde são necessários extremamente de atualizações e escalabilidade (a cada pouco tempo tem que subir novidades tendo milhares/milhões de usuários), como por exemplo em aplicações como: Netflix, Uber, Amazon e afins. Agora em cenários de aplicações corporativas em qualquer tipo de setor comercial/industrial pode ser muito bem entregue no modelo com arquitetura distribuída. E caso evolua muito a aplicação este modelo está a poucos passos de se tornar um microserviço."*

Dessa forma, utilizarmos uma arquitetura em microserviços dependendo da complexidade do negócio pode ser uma *"bazuca para matar uma barata"*.

<hr>

## Como executar?

Existem duas maneiras principais de execução da aplicação: a partir do [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/), ou usando [Docker](https://www.docker.com/). Também pode ser usado [Visual Code](https://code.visualstudio.com/download), mas os dois citados anteriormente são mais práticos.

### Execução pelo Visual Studio

Para executar no Visual Studio, basta seguir os seguinte passos:

- Instalar as seguintes ferramentas: .Net 6, SQL Server (preferencialmente com o SSMS) e Docker;
- Criar uma instância do RabbitMQ a partir de um container docker por meio do seguinte comando:

    ```
    docker run -d --hostname rabbit-host --name rabbit-nerdstore -p 15672:15672 -p 5672:5672 rabbitmq:3-management-alpine
    ```

- Para criação da base de dados existem duas maneiras. Uma delas é executar o script chamado *BackupDbScript.sql* presente no diretório */sql* no banco de dados. Outra forma é rodar as *migrations* presentes no código fonte em cada um dos projetos através do [*PMC (Package Manager Console)*](https://www.learnentityframeworkcore.com/migrations/commands/pmc-commands) do Visual Studio. Caso escolha a segunda maneira basta rodar o seguinte comando em cada projeto no *PMC*:

    ```
    Update-Database -Context {nome_contexto} -StartupProject {nome_projeto_startup}
    ```

- Coloque todos os projetos para rodar no modelo *SelfHosting* ao invés do *IIS*, pois todas URL's/endpoints configurados estão usando as configurações de *SelfHosting* presentes no *launchSettings.json*;
- Configurar a solution da aplicação no Visual Studio para iniciar vários projetos, exatamente com os mesmos projetos mostrados na figura abaixo:

    ![Selecionando os projetos para executar no visual studio](./docs/executar-aplicacao-visual-studio-1.PNG)

- Agora basta startar a aplicação. Mas uma observação importante também é fazer o unload do projeto *NSE.WebApp.MVC6*, pois o principal é o *NSE.WebApp.MVC* que usa o .NET MVC 5.

    ![Startar a aplicação com N projetos](./docs/executar-aplicacao-visual-studio-2.PNG)

### Execução pelo Docker

A execução pelo Docker, mais especificamente pelo [Docker Compose](https://docs.docker.com/compose/), é muito mais simples e rápido do que anterior, pois não é necessário ter toda a stack necessária para executar a aplicação, mas somente o Docker. E esse setup rápido é um de seus benefícios, além da escalabilidade proporcionada e a maior facilidade de implantação da aplicação. Dado isso, basta seguir os seguintes passos:

- Obviamente, instalar o Docker habilitando o WSL2 e virtualização, principalmente se estiver no SO Windows;
- Abra o terminal no diretório */deploy* e execute o seguinte comando:

    ```
    docker-compose -f nerdstore-producao.yml up --build
    ```

    **OBS.:** *--build* é uma flag opcional que força a criação de todas as imagens docker.

- Para remover todos os containers docker gerados a partir das imagens docker basta usar o seguinte comando:

    ```
    docker-compose -f nerdstore-producao.yml down
    ```

<hr>

## Referências

Abaixo estão os links das principais fontes para realização desse projeto, com ênfase no curso da plataforma de cursos [Desenvolvedor.IO](https://desenvolvedor.io/).

- [ASP.NET Core Enterprise Applications](https://desenvolvedor.io/curso-online-asp-net-core-enterprise-applications);
- [Dev-Store Github Repo](https://github.com/desenvolvedor-io/dev-store);
- [eShopContainers Github Repo](https://github.com/dotnet-architecture/eShopOnContainers);
- [.NET Microservices: Architecture for Containerized .NET Applications](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/);
- [Design a microservice-oriented application](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/microservice-application-design);
- [Creating a simple data-driven CRUD microservice](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/data-driven-crud-microservice);
- [Design a DDD-oriented microservice](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice).