# Creating an Azure Virtual Machine (VM) with Linux

In this guide, we'll walk you through the steps to create an Azure Virtual Machine (VM) running a Linux operating system.

## Prerequisites

Before you begin, make sure you have the following:

- An Azure account. If you don't have one, you can [create an Azure account](https://azure.com) for free.
- Azure CLI installed on your local machine. You can [install Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli) if you haven't already.


## Step 1: Log in to Azure

Open a terminal and log in to your Azure account using the following command:
```shell
az login

Step 2: Create a Virtual Machine or step 3

Now, let's create the Virtual Machine. Use the following command as a template, replacing the placeholders with your own values.

Step 3: Create a Resource Group and webjob

Crate webjob and upload zip files from debaging to run console app on Azure.

Step 4: Connect to the VM

You can now connect to your VM using SSH. Replace <public-ip> with the public IP address of your VM:
ssh <admin-username>@<public-ip>


Step 5: Check dotnet version

$ dotnet version

Step 6: Install dotnet 

sudo snap install dotnet-sdk

Step 7: Craete map 

sudo mkdir /usr/repos

Step 8: Clone repositoriy from github

repos$ git clone https://github.com/AntonKozak/TcpUdpServerClient.git

Step 9: Run the program in right map

$ sudo dotnet run