# SEP3
The project allows a user to make an account and login to a recipe application. The user can view all recipes and filter based on category. He can select a recipe 
to view the ingredients needed and the cooking instructions. He can order a recipe and choose which ingredients of the selected recipe he wants to buy. The system
selects the best price for the ingredients available in different shops and delivers them to the user. The user can view his orders.
An administrator can add more recipes and ingredients to the shops. He can also view all users orders.

A heterogeneous system using c# and java. It allows a user to create an account and order recipes. 
For the client side Blazor was used to create the pages for login, register, view and filter recipes, order recipes and view past orders.
ASP.NET framework was used to create a RESTful web service to allow the communication of the presentation tier with the business tier.
Sockets was used for the communication of business tier with data tier.
With LINQ a connection to the SQL database was made.
A Java client tier was made for an administrator to manage the recipes in the database. The Java client tier communicates with the Java business tier with sockets 
and the business tier with the C# data tier with sockets.
