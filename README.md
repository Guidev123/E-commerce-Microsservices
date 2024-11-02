
<h1>YourSneakerEnterprise👟</h1>

<h2>This project is a fully functional E-commerce system. It was developed using the following technologies:</h2>
<ul>
    <li>ASP.NET🛠️</li>
    <li>C#🛠️</li>
    <li>.NET🛠️</li>
    <li>Entity Framework🛠️</li>
    <li>SQL Server🛠️</li>
    <li>RabbitMQ🛠️</li>
    <li>Docker🛠️</li>
    <li>JsonWebToken (JWT) for data encryption🛠️</li>
    <li>JavaScript🛠️</li>
    <li>Dapper🛠️</li>
</ul>

<br/>
<strong>In addition, the following development principles were applied:</strong>
<ul>
    <li>Domain Driven Design📜</li>
    <li>SOLID📜</li>
    <li>OOP (Object-Oriented Programming)📜</li>
    <li>CQRS📜</li>
    <li>Clean Code📜</li>
    <li>Repository Pattern and Unit of Work📜</li>
    <li>Api BFF (Gateway)📜</li>
</ul>

<br/>
<strong>Architecture: </strong>
<br/>
<img src="https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/e3d8aef4-f28b-473e-843a-86463f1be828" alt="Architecture Diagram">

<br/>
<strong>Other services used:</strong>
<ul>
    <li>EasyNetQ💼</li>
    <li>Polly💼</li>
    <li>MediatR💼</li>
    <li>Swagger UI with JWT support💼</li>
</ul>

<h2>Description</h2>
<strong>The project consists of a system composed of 6 REST APIs, 1 API Gateway, and an MVC web app:</strong>
<ul>
    <li>Identity: API responsible for handling user authentication and authorization.</li>
    <li>Payment: API responsible for managing payment transactions.</li>
    <li>Catalog: API responsible for managing products and the catalog.</li>
    <li>Cart: API responsible for adding, removing, and editing items in the shopping cart, as well as implementing discount coupons.</li>
    <li>Customers: API responsible for managing customer data, such as CPF and name, and validating this information.</li>
    <li>Order: API responsible for processing and managing orders.</li>
    <li>Payment: API responsible for approving orders and simulating a payment gateway.</li>
</ul>

<br/>
<strong>The Purchase API Gateway acts as an entry point for functionalities related to purchases, coordinating calls to the individual APIs.</strong>

<h1>File Structure</h1>
<br/>
<ul>
    <li><strong>src: </strong>Root folder of the project.</li>
    <br/>
    <li><strong>Building Blocks:</strong> This directory contains the fundamental elements that will be shared among all APIs. Here, you will find basic functionalities, common data models, and other reusable components.</li>
    <br/>
    <li><strong>Services:</strong> All individual APIs are implemented in this directory. Each API is responsible for a specific functionality of the application, and this is where its implementations reside.</li>
    <br/>
    <li><strong>Api BFF/YourSneaker.BFF.Compras:</strong> This directory contains the API Gateway, which acts as an abstraction layer for the various service APIs. Here, customer requests are routed to the appropriate APIs, aggregated as needed, and sent back to the customer.</li>
    <br/>
    <li><strong>Web/YourSneaker.WebApp.MVC:</strong> This directory contains the MVC web application, which is the user interface of the application. Here, users interact with the application through a web browser, accessing and manipulating the data provided by the service APIs.</li>
</ul>

<h1>How the Application Works</h1>
<br/>
<br/>
<br/>
<br/>


https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/6551fd48-3c81-4739-885a-11cd98602720

https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/49fda926-2442-4a7c-8313-ca79ff2f65eb

https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/b5ee6760-f334-4373-9000-638b6edcb1de

<br/>
<br/>
<br/>
<h1>Developed APIs:</h1>
<br/>
<br/>
<br/>
<h1>Identity API</h1>
<img src="https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/6327906b-ce06-4d57-97ef-6e7659cf8485" alt="Identity API">

<h1>Customers API</h1>
<img src="https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/7241993b-2985-4b1b-8d97-394c139da037" alt="Customers API">

<h1>Catalog API</h1>
<img src="https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/f3c7070f-0f34-4262-8932-122b15217d50" alt="Catalog API">

<h1>Cart API</h1>
<img src="https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/23cf89fa-241b-4b0d-8993-7f9472835bd1" alt="Cart API">

<h1>API Gateway</h1>
<img src="https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/36113818-7642-4563-8f21-090d76231d61" alt="API Gateway">

<h1>Order API</h1>
<img src="https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/b8bace60-1c62-48f9-a941-1e5f79aa51ae" alt="Order API">

<h1>Payment API and Payment Gateway</h1>
<img src="https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/e01929d3-aa58-4c9f-b4d2-ab497fa78c90" alt="Payment API">
<img src="https://github.com/Guidev123/YourSneakerEnterprise/assets/155389912/d1c4c082-8143-45d4-8b99-f271e52cf355" alt="Payment Gateway">
