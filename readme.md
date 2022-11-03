# Plus Minus App

# VPS deployment application

Use this project to learn how to deploy to a Digital Ocean VPS.

## Run the app locally first

Before you deploy see if you can run this application on your local machine from IntelliJ and from the terminal.

Clone the app locally: 

`git clone https://github.com/codex-academy/PlusMinusDotNet`

In the terminal run these commands

To change into the right folder

```
cd PlusMinusDotNet
```

Then compile and run the app:

```
dotnet restore
dotnet build  -c Release
dotnet bin/Release/net6.0/PlusMinus.dll --urls=http://localhost:6007/
```

See if you can access the application from the browser at `http://localhost:6007`


### Start the app in the background using this command:

```
nohup dotnet bin/Release/net6.0/PlusMinus.dll --urls=http://localhost:6007/ 2>&1 &
```

Note the process `id number` that is printed to the screen.

Use that to stop the app using:

```
kill -9 <the id number>
```

## VPS deployment steps

* Create a server on Digital Ocean
 * I sent you an invitation
 * Cloud servers are called `droplets`
 * Create an Ubuntu `$4` server (droplet) in *Amsterdam* - Datacenter 3 (speak to me if you don't have a `$4` - server option there)
 * Use password authentication
 * Rename your server to be called "YourFirstName-Server" in Digital Ocean
 * Please take a screen shot of this page - and keep it aside.
* Login to the server using ssh
 * Login to the server using root : `ssh root@your.ip.address`
 
 * Server setup:

    * Run this command on your server: `apt update` to ensure you got all the latest packages. It will take a while.
    * Install `dotnet` on the server 
        * First run these commands:
        
        ```
        wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
        sudo dpkg -i packages-microsoft-prod.deb
        rm packages-microsoft-prod.deb
        ```
        
        Followed by:
        
        ```
        sudo apt-get update && \
          sudo apt-get install -y dotnet-sdk-6.0
        ```
        
        * after running these commands the `dotnet` command should work on your server.
    * `git` should already be installed on the server. If not install `git` on the server using: `apt install git`.

* Link the server to a domain name
    * Email the IP address of your server to `mentors@projectcodex.co`
    * The mentors will link your server to domain name for you.
    * `yourname.projectcodex.net`
  
* Run a `dotnet` Web App on the server
    * create an `apps` folder using `mkdir apps`
    * change into the folder using `cd apps`
    * clone the java project to the server:
        `git clone https://github.com/codex-academy/PlusMinusDotNet`
    * change into this folder using`cd PlusMinusDotNet/`
    * run these maven commands:
        
        * `dotnet restore`
        * `dotnet build  -c Release`
        * In your dotnet app folder run this command to start the application:  `dotnet bin/Release/net6.0/PlusMinus.dll --urls=http://localhost:6007/`
        
    * At this point your app should be running at: `http://your-server-ip-address:6007`
    * See if others are able to access your application
    * Please take some screenshots of :
            * your deployed application running the browser
            * your terminal window where you are running the application from
  * stop the process running in the terminal using the ctrl-c command - you should not be able to access your application now.
  
  * run your app in the background using this command:
    ```
    nohup dotnet bin/Release/net6.0/PlusMinus.dll --urls=http://localhost:6007/ > vps.log 2>&1 &
    ```
    
    You can also see this command to the `process id` for the app:
    
    ```
    ps -eafw | grep PlusMinus
    ```
    
  * now you can logout of your server using the `exit` command
  * log back into your server and stop the java process using the `kill`

## Screen shots & list of commands used

Please ensure you have screenshots of:
* your Digital Configuration setup in Digital Ocean,
* showing your deployed app running on your domain,
* the terminal showing your app running.

Run the `history` command to keep a list of all the commands you used during this workshop. Store these commands in a `history.txt` file.

## Delete your server

Please delete your server in Digital Ocean.
 
