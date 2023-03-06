<h1 align="center">Restraunt communication</h1>

<h2 align="center">About project</h2>
<p>This program is responsible for communication between the waiter and the customer. Waiter has CRM, that notify him about orders on tables</p>
<p>User have a QR code on the Table. He scan and linked to QR menu. Next step order dish and pay</p>

<h2>Stack</h2>
<li>ASP.NET Core MVC + API</li>
<li>IdentityServer4 + Microsoft.Identity + Google auth</li>
<li>JavaScript, jQuery</li>
<li>Bootstrap, CSS, HTML</li>
<li>EntityFramework Core</li>
<li>SignalR</li>

<h2 align="center">Tasks</h2>
<li>Create DB</li>
<li>Setting up relationships in the database</li>
<ol>Users</ol>
<ol>Dishes</ol>
<ol>Tables</ol>
<ol>Roles</ol>
<li>Authentication and authorization </li>
<ol>Read how working IdentityServer4</ol>
<ol>IdentityServer4 authentication and authorization</ol>
<ol>Claims</ol>
<ol>Access and refresh tokens</ol>
<li>CRUD operations of dishes</li>
<ol>Create Entity Dish</ol>
<ol>Create DishRepository</ol>
<li>CRUD operations of orders</li>
<ol>Create Entity Order</ol>
<ol>Create OrderRepository</ol>
<li>CRUD operations of tables</li>
<ol>Create QRCode</ol>
<ol>Create Entity Table</ol>
<ol>Create TableRepository</ol>
<li>CRM</li>
<ol>CRM for administrator</ol>
<ol>CRM for waiter</ol>
<li>Notification</li>
<ol>Notification on waiter's CRM</ol>


<h2 align="center">User actions</h2>
<li> User sit down at the table</li>
<li> Use QR code and link to the menu</li>
<li> Selects the menu</li>
<li> How'll leave pays</li>

<p align="center"><img width="658" height="60" alt="Customer" src="https://user-images.githubusercontent.com/69418373/212341649-4d439b79-dcba-4078-ac5c-4e276fab4ebb.jpg"></p>

<h2 align="center"> Waiter actions</h2>
<li>Checks the CRM</li>
<li>If notify about order'll go to the table and refines the order</li>
<li>Serves the table</li>
<li>Closes the table</li>

<p align="center"><img width="658" height="50" alt="Screenshot 2023-01-12 at 15 05 20" src="https://user-images.githubusercontent.com/69418373/212168216-d250a49a-4a4f-43c8-9293-bb12d9122f1b.png"></p>


<h2 align="center">Site map</h2>
<li>Main page</li>
<li>QR menu</li>
<li>CRM for waiter</li>
<li>CRM for admin</li>
