[![Build status](https://dev.azure.com/escolaparaprogramadores/CSharpBaseProject/_apis/build/status/ASP.NET%20Core-CI)](https://dev.azure.com/escolaparaprogramadores/CSharpBaseProject/_build/latest?definitionId=4)

# Run Dockerfile
```sh
$ docker build -f Dockerfile -t marknit/aspnetcore:3.1 .
```
# Create a Container
```sh
$ docker run -d --name aspnetcore -p:5000:80 marknit/aspnetcore:3.1
```
# Docker-compose
```sh
$ docker-compose build
$ docker-compose up -d --build
$ docker-compose down
```
# AWS
```sh
$ Logar na AWS: aws ecr get-login-password --region us-east-2 | docker login --username AWS --password-stdin 404124426437.dkr.ecr.us-east-2.amazonaws.com
```
# Criar tag da imagem
```sh
$ docker tag marknit/aspnetcore:3.1 404124426437.dkr.ecr.us-east-2.amazonaws.com/aspnetcorebase:latest
```
# Push da Imagem para o ECR (Elastc Container Registry)
```sh
$ docker push 404124426437.dkr.ecr.us-east-2.amazonaws.com/aspnetcorebase:latest
```
# GIT
- Cria um repositório Git.
```sh
$ git init
```

- Adicionar informações do Desenvolvedor.
```sh
$ git config --local user.name "Seu nome aqui"
$ git config --local user.email "seu@email.aqui"
```

- Verifica o estado do repositório.
```sh
$ git status
```
- Adiciona os arqivos na stagin área, preparando-os para serem posteriormente commitados.
```sh
$ git add .
```
- Salva as alterações e cria um check point das mudanças.
```sh
$ git commit -m "commit message"
```


# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references


# Build and Test

TODO: Describe and show how to build your code and run the tests. 

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)