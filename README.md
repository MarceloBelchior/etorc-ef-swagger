#Order Management System REST API 
This project requires you to develop a simplified Order Management System using C#, .NET, Microsoft SQL Server, Entity Framework, T-SQL, and stored procedures. 

 The system will have REST API endpoints to create and read data for two entities: Products, and Orders. 



 Please be sure to read through all of the Overview, Specifications and Optional Extras before you begin work.



You should implement SOLID principles and at least the following design patterns: 

● Dependency Injection (DI) 

● Repository Pattern 

● Unit of work 



This project will allow the candidate to demonstrate their knowledge and skills in C#, .NET, Entity Framework, T-SQL, stored procedures, and REST API design. 



**Note: Project must be well organized following GitHub repository structure best practices and include a comprehensive README.md **



The project should take approximately one hour and a half to complete. 

Setting up the project and designing the database schema: ~15 minutes 
Writing the API endpoints and implementing the data access code: ~55 minutes 
Writing the stored procedure: ~10 minutes 
Writing the limited set of tests: ~10 minutes 


#Specifications 


Entity Design 

● Product: Products have an ID, name, and price. 

● Order: Orders have an ID, a customer ID, a product ID, quantity of the product, and total 

cost. 



API Endpoints 

● Product: A GET endpoint to read a product by its ID. 

● Order: A POST endpoint to create a new order and a GET endpoint to read an order by 

its ID. 



Database Access 

● You should use Microsoft SQL Server (either SQL Server Management Studio or just Microsoft SQL Server docker image) and Entity Framework to interact with the database.

 This includes defining the DbContext and the DbSet for each entity, and writing LINQ queries to perform the read operations. 

● T-SQL will be used to create the tables and pre-populate them with some initial data. 



Data Persistence 

You will write a stored procedure to calculate the total cost and create a new order.

Call this stored procedure from your C# code using Entity Framework when the POST endpoint for creating a new order is hit. 



Authentication 

At least the POST endpoint must require authentication; you should use ASP.NET Identity with JWT.

 Optional: role-based authorization (no specifications for roles) 



Data Validation 

At least validate that product ID exists when creating an order and that the quantity is positive. 



Testing 

Write critical unit tests to validate the functionality of the API endpoints and the stored procedure.

 Suggested testing framework: xUnit. 



Note: we have considerably reduced the scope of this topic so candidate can focus on the main areas of the project. 



The critical areas to test are: 

● Database access methods 

○ 		Minimum: test create order 

● API endpoints 

○ 		Minimum: test POST endpoint 

● Error handling

 ○ 	Minimum: test error handling for non existent products 



#Optional Extras
 Here is a list with some improvements that you can use to highlight your work. 



Entity Design 

● Add the Customers entity 



Testing: 

● Integration testing to test the stored procedure. 

● Mocking database operations. 



Authentication 

● Use JWT authentication for the POST endpoint 



Pagination and sorting using query parameters 

● Paginate and sort all GET endpoints 



Logging 

● Implement logging with Serilog or NLog 



Dockerize the application



API documentation using Swagger



Create a basic web client using TypeScript 



#How to submit
Please upload the code for this project to GitHub, and post a link to your repository below.
