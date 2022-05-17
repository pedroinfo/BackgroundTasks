# BackgroundTasks


Sometimes we need run recurring tasks in our applications.

For example, that every X seconds a query is made in the database and an email is sent to all users with status Y.

This application is a small example of how you can do this using the .NET BackgroundService class.

As a database I used LiteDb. 

The process is simple I make the call in an api and save the data in the LiteDb every X seconds.

If you have a lot of heavy tasks with heavy traffic, it might be more appropriate to use another approach like Hangfire, Quartz.Net 
or a more appropriate messaging service.


