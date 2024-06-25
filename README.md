# YourSneakerEnterprise👟

<h2>Este projeto é um E-commerce 100% funcional. Foi desenvolvido utilizando as seguintes tecnologias:</h2>

<li>ASP.NET🛠️</li>
<li>C#🛠️</li>
<li>.NET🛠️</li>
<li>Entity Framework🛠️</li>
<li>SQL Server🛠️</li>
<li>RabbitMQ🛠️</li>
<li>Docker🛠️</li>
<li>JasonWebToken (JWT) para criptografia dos dados🛠️</li>
<li>Javascript🛠️</li>
<li>Dapper🛠️</li>
<br/>
<strong>Além disso, foram aplicados os seguintes princípios de desenvolvimento:</strong>

<li> Domain Driven Design📜</li>
<li> SOLID📜</li>
<li> OOP (Programação Orientada a Objetos)📜</li>
<li> CQRS📜</li>
<li> Clean Code📜</li>
<li> Unit of Work📜</li>
<li> Api BFF (Gateway)📜</li>
<br/>
<strong>Arquitetura: </strong>
<br/>

![Screenshot_8](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/e3d8aef4-f28b-473e-843a-86463f1be828)

<br/>
<strong>Outros serviços utilizados:</strong>

<li> EasyNetQ💼</li>
<li> Polly💼</li>
<li> MediatR💼</li>
<li> Swagger UI com suporte para JWT💼</li>
<h2>Descrição</h2>

<strong>O projeto consiste em um sistema composto por 6 APIs REST, 1 API Gateway e App web MVC:
</strong>
<br/>
<li>Identidade: API responsável por lidar com autenticação e autorização de usuários.</li>
<li>Pagamento: API responsável por gerenciar transações de pagamento.</li>
<li>Catálogo: API responsável pelo gerenciamento de produtos e catálogo.</li>
<li>Carrinho: API responsável pela adição, remoção e edição de itens do carrinho de compras, além de implementar cupons de desconto.</li>
<li>Clientes: API responsável pelo gerenciamento dos dados dos clientes, como CPF e nome, além de validar essas informações.</li>
<li>Pedido: API responsável pelo processamento e gerenciamento de pedidos.</li>
<li>Pagamento: API responsável por aprovar pedidos e simular um gateway de pagamento.</li>
<br/>
<strong>O API Gateway de Compras atua como um ponto de entrada para as funcionalidades relacionadas a compras, coordenando as chamadas para as APIs individuais.</strong>


<h1></h1>

<h1>Estrutura de Arquivos</h1>
<br/>

<li><strong>src: </strong>Pasta raiz do projeto.</li>
<br/>

<li><strong>Building Blocks:</strong> Este diretório contém os elementos fundamentais que serão compartilhados entre todas as APIs. Aqui, você encontrará funcionalidades básicas, modelos de dados comuns e outros componentes reutilizáveis.</li>
<br/>

<li><strong>Services:</strong> Todas as APIs individuais são implementadas neste diretório. Cada API é responsável por uma funcionalidade específica da aplicação, e este é o local onde suas implementações residem.</li>
<br/>

<li><strong>Api BFF/YourSneaker.BFF.Compras:</strong> Este diretório contém a API Gateway, que atua como uma camada de abstração para as diversas APIs de serviços. Aqui, os pedidos do cliente são direcionados para as APIs apropriadas, agregados conforme necessário e enviados de volta ao cliente.</li>
<br/>

<li>Web/YourSneaker.WebApp.MVC: Este diretório contém a aplicação web MVC, que é a interface do usuário da aplicação. Aqui, os usuários interagem com a aplicação por meio de um navegador da web, acessando e manipulando os dados fornecidos pelas APIs de serviços.
<br/>
  
<h1></h1>
<h1>Funcionamento da aplicação</h1>
<br/>
<br/>
<br/>
<br/>

https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/6551fd48-3c81-4739-885a-11cd98602720

https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/49fda926-2442-4a7c-8313-ca79ff2f65eb

https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/b5ee6760-f334-4373-9000-638b6edcb1de





<h1></h1>
<br/>
<br/>
<br/>
<h1>API's desenvolvidas:</h1>
<br/>
<br/>
<br/>
<h1>API de Identidade</h1>

![id](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/6327906b-ce06-4d57-97ef-6e7659cf8485)

<h1></h1>
<br/>
<br/>
<br/>
<h1>API de Clientes</h1>

![clientes](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/7241993b-2985-4b1b-8d97-394c139da037)


<h1></h1>
<br/>
<br/>
<br/>
<h1>API de Catalogo</h1>

![catalogoo](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/f3c7070f-0f34-4262-8932-122b15217d50)


<h1></h1>
<br/>
<br/>
<br/>
<h1>API de Carrinho</h1>

![Carrinho](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/23cf89fa-241b-4b0d-8993-7f9472835bd1)


<h1></h1>
<br/>
<br/>
<br/>
<h1>API Gateway</h1>

![apibff](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/36113818-7642-4563-8f21-090d76231d61)

<br/>
<br/>
<br/>
<h1>API de Pedido</h1>


![pedido](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/b8bace60-1c62-48f9-a941-1e5f79aa51ae)

<br/>
<br/>
<br/>
<h1>API de Pagamento e Gateway de pagamento</h1>

![Screenshot_9](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/e01929d3-aa58-4c9f-b4d2-ab497fa78c90)

![Screenshot_10](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/d1c4c082-8143-45d4-8b99-f271e52cf355)



<h1>Tutorial para Rodar o Projeto Localmente</h1>
<p>Este guia irá orientá-lo a configurar e rodar o projeto localmente. Certifique-se de seguir cada etapa cuidadosamente.</p>

  <h2>Pré-requisitos</h2>
    <ul>
        <li>.NET Core SDK</li>
        <li>Docker</li>
        <li>RabbitMQ</li>
    </ul>

  <h2>Passo a Passo</h2>

  <h3>1. Clonar o Repositório</h3>
    <p>Primeiro, clone o repositório do projeto para o seu ambiente local:</p>
    <pre><code>git clone 
    </code></pre>

  <h3>2. Criar o Banco de Dados</h3>
    <p>Use o comando <code>update-database</code> para criar o banco de dados:</p>
    <pre><code>dotnet ef database update
    </code></pre>

  <h3>3. Ajustar as Configurações de Inicialização</h3>
    <p>Certifique-se de que todos os projetos estão configurados para inicializar no ambiente de desenvolvimento (DEV). Abra o arquivo de configuração de inicialização e ajuste as configurações conforme necessário. No arquivo <code>launchSettings.json</code> de cada projeto, verifique se o ambiente está definido como <code>Development</code>.</p>
    <pre><code>{
    "IIS Express DEV": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express PROD": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Production"
      }
    },
    </code></pre>

  <h3>4. Criar e Iniciar o Contêiner Docker com RabbitMQ</h3>
    <p>Para criar e iniciar um contêiner Docker com RabbitMQ, siga os passos abaixo:</p>
    
  ![image](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/48b780fa-e14e-47f5-b6e6-5f8fed527719)


  <h3>5. Inicializar o Projeto</h3>
    <p>Por fim, inicialize o projeto no ambiente de desenvolvimento. No terminal, navegue até a pasta de cada projeto e execute:</p>
    <pre><code>dotnet run
    </code></pre>

