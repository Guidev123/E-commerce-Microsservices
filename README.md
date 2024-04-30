# YourSneakerEnterprise👟

<h2>Este projeto foi desenvolvido utilizando as seguintes tecnologias:</h2>

<li>ASP.NET🛠️</li>
<li>.NET🛠️</li>
<li>Entity Framework🛠️</li>
<li>SQL Server🛠️</li>
<li>RabbitMQ🛠️</li>
<li>JasonWebToken (JWT) para criptografia dos dados.🛠️</li>
<br/>
<strong>Além disso, foram aplicados os seguintes princípios de desenvolvimento:</strong>

<li>Domain Driven Design📜</li>
<li>SOLID📜</li>
<li>OOP (Programação Orientada a Objetos)📜</li>
<h2>Descrição</h2>
<strong>O projeto consiste em um sistema composto por 6 APIs REST e 1 API Gateway:
</strong>
<br/>
<li>Carrinho: Responsável pelo gerenciamento de carrinhos de compras.</li>
<li>Cliente: Gerencia informações relacionadas a criação de clientes.</li>
<li>Pedido: Responsável pelo processamento e gerenciamento de pedidos.</li>
<li>Identidade: Lida com autenticação e autorização de usuários.</li>
<li>Pagamento: Gerencia transações de pagamento.</li>
<li>Catálogo: Responsável pelo gerenciamento de produtos e catálogo.</li>
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
<h1>Funcionamento da aplicação até agora</h1>
<br/>
<strong>(Não está finalizada, irei atualizando o video de acordo com o desenvolvimento. Estão pendendtes as API's de Pedidos, Pagamentos e a API Gateway de compras.)</strong>
<br/>
<br/>
<br/>

https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/40016c1b-5d56-4eee-89e6-ce5415eb67a0

<h1></h1>
<br/>
<br/>
<br/>
<h1>API's desenvolvidas até agora:</h1>
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

![client](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/2cce0fb0-f6ae-4653-85de-b21071c4cb8f)

<h1></h1>
<br/>
<br/>
<br/>
<h1>API de Catalogo</h1>

![catalogo](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/ad4bfc7c-08f6-4a43-9e1d-c51cbaebb902)

<h1></h1>
<br/>
<br/>
<br/>
<h1>API de Carrinho</h1>

![car](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/15b0de2c-c67a-40c2-97d9-5885db0eecd9)

<h1></h1>
<br/>
<br/>
<br/>
<h1>API Gateway</h1>

![APIgateway](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/e3b31941-9b8b-4f23-ae09-91d814ed27ef)
