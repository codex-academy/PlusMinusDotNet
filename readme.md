# Plus Minus App

# VPS deployment application

Use this project to learn how to deploy dotnet Core Apps to a Digital Ocean VPS.

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

If there is not id on the screen you can use this command to find the id of the running process:

```
ps -eaf | grep PlusMinus
```


Use that to stop the app using:

```
kill -9 <the id number>
```

## VPS deployment steps

* Create a server on Digital Ocean
 * I sent you an invitation
 * Cloud servers are called `droplets`
 * Create an Ubuntu `20.04` `$4` server (droplet) in *Amsterdam* - Datacenter 3 (speak to me if you don't have a `$4` - server option there)
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
    * dotnet installation guidance on Ubuntu [here](https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu)
    * `git` should already be installed on the server. If not install `git` on the server using: `apt install git`.

* Link the server to a domain name
    * Email the IP address of your server to `mentors@projectcodex.co`
    * The mentors will link your server to domain name for you.
    * `yourname.projectcodex.net`

* Install `nginx` on the server:
   * [nginx](https://www.nginx.com/) is a web server that we will use as a [reverse proxy](https://docs.nginx.com/nginx/admin-guide/web-server/reverse-proxy/) to send HTTP request to our `dotnet` app
   * Install it using this command: `sudo apt-get install nginx`
   * Start it using this command: `sudo /etc/init.d/nginx start` 
   * You should be able to access the running nginx web server now using this command: `http://your ip adress here`
* Configure `nginx` to forward requests to our `dotnet` web app.
   * Open the `/etc/nginx/site-available/default` file using the `nano` editor like this `nano /etc/nginx/site-available/default`
   * and change the `location` section from something like this:

   ```
   location / {
                # First attempt to serve request as file, then
                # as directory, then fall back to displaying a 404.
                try_files $uri $uri/ =404;
   }
   ```
  
   to look like this:

   ```
   location / {
     # First attempt to serve request as file, then
     # as directory, then fall back to displaying a 404.
     # try_files $uri $uri/ =404;
     proxy_pass http://localhost:6007;
     proxy_http_version 1.1;
     proxy_set_header Upgrade $http_upgrade;
     proxy_set_header Connection keep-alive;
     proxy_set_header Host $host;
     proxy_cache_bypass $http_upgrade;
     proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
     proxy_set_header X-Forwarded-Proto $scheme;
   }
   ```
   * Save the changes and restart `nginx` using this command: `sudo /etc/init.d/nginx reload`
   * Check what you see in the browser at: `http://your ip adress here` - you should see an `502 Bad Gateway` error now.
   * This means that it can't find our dotnet app running on port 6007. We will fix that in the next step below.
   
* Run a `dotnet` Web App on the server
    * create an `apps` folder using `mkdir apps` - in your home folder `/root`
    * change into the folder using `cd apps`
    * clone the java project to the server:
        `git clone https://github.com/codex-academy/PlusMinusDotNet`
    * change into this folder using`cd PlusMinusDotNet/`
    * run these dotnet commands - to restore all local dependencies & to build & run the app:
        
        * `dotnet restore`
        * `dotnet build  -c Release`
        * `dotnet bin/Release/net6.0/PlusMinus.dll --urls=http://localhost:6007/`
        
    * At this point the app should be running at: `http://your-server-ip-address`
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
 
