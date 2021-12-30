
<!-- About this Project -->
## About the Project

Built with
•	Back-End
o	ASP.NET Core 3.1
o	MS Sql
•	Front-End
o	React.js
o	Bootstrap
o	Azure AD login

<!-- Installation -->
## Installation

### Database Installation
1.	Please download the database file "datatoolDB" provided in the backend file project and use the restore Database function of Microsoft SQL server to install the database.

/…….
2.	Run MSSql server service 
3.	Use windows authentication service for database.
3. Get the connection string to the database.
	a- once your are done intalling the database, from visual studio open Server explorer
    b- 	select icon Sql server object explorer then select add SQL server.
	c Browse your local directory, open the one with you computer name and connect using windows Authentication.
    d- under SQL server Object Explorer , you can now open a drop down with your laptop name and see all database
	e - select datatoolDB and right click on properties where you can copy the connection string for the database 
	d copy the connection string in your backend application file name appsettings.json under connection strings

### Backend Installation
1 Clone the repo
   ```sh
   git clone https://github.com/hermben/ToolManagementApp
   ```
Preferably using visual studio 2019




### React front end installation
1 Clone the repo
 ```sh
   git clone https://github.com/hermben/Toolmanapp
   ```
Preferably using Visual studio code.

    
2.	Install NPM Package
    ```sh
    Run NPM install 
    ```sh

3.	Run NPM start
     ```sh
 

Author
•	Herman Benao Microsoft Software developer Leap program .
License 

Distributed under the MIT License.
