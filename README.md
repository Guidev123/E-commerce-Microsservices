# YourSneakerEnterprise👟

<h2>Este projeto foi desenvolvido utilizando as seguintes tecnologias:</h2>

<li>ASP.NET🛠️</li>
<li>C#🛠️</li>
<li>.NET🛠️</li>
<li>Entity Framework🛠️</li>
<li>SQL Server🛠️</li>
<li>RabbitMQ🛠️</li>
<li>Docker🛠️</li>
<li>JasonWebToken (JWT) para criptografia dos dados.🛠️</li>
<li>Javascript🛠️</li>
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

![Arquitetura](https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/66b16d2c-697a-4bfd-973a-ba706521f554)


<br/>
<strong>Outros serviços utilizados:</strong>

<li> EasyNetQ💼</li>
<li> Polly💼</li>
<li> MediatR💼</li>
<li> Swagger UI com suporte para JWT💼</li>
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
<strong>(Não está finalizada, irei atualizando o video de acordo com o desenvolvimento. Esta pendente somente a API de Pagamento. ULTIMA ATUALIZAÇÃO 19/05/2024)</strong>
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

