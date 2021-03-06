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
### References
[Guia de referência](https://devhints.io/git-log)
- Cria um repositório Git.
```sh
$ git init
```

- Adicionar informações do Desenvolvedor.
```sh
$ git config --local ou global user.name "Seu nome aqui"
$ git config --local ou global user.email "seu@email.aqui"
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

### Histórico dos commits
- Visualisa o hitórico.
```sh
$ git log
```

- Visualisa o hitórico de forma simplificada.
```sh
$ git log --oneline
```

- Visualisa o hitórico de forma completa.
```sh
$ git log -p
```

### Ignorando arquivos
 Ignorando arquivos, é necessário criar oa arquivo .gitignore, e dentro do arquivo escrever as pastas ou arquivos a que não quer que seja versionado.
- Exemplo.
```sh
index.html
bin/
```

# Compartilhando trabalho em outros diretórios 
- Inicializa o repositório
### Referência
- [Diferença entre “git init” e “git init --bare”](https://pt.stackoverflow.com/questions/80182/qual-%C3%A9-a-diferen%C3%A7a-entre-git-init-e-git-init-bare)
- O repositório servirá apenas como servidor, para que outros membros da equipe sincronizem seus trabalhos, poupamos espaço de armazenamento desta forma.
```sh
$ git init --bare
```

### Repositórios remotos
- Lista todos repositórios remotos.
```sh
$ git remote -v
```

- Adiciona um repositório remoto.
```sh
$ git remote add serverRemote C:/Users/Documents/git-e-github/servidor
```

- Clonando repositório
```sh
$ git clone /c/Users/ALURA/Documents/git-e-github/servidor meuProjeto
```
# Sincronizando os dados
- Envia mudanças da branch que estou trabalhando para o origin.
```sh
$ git push origin feature/minhaBranch
```
- Renomeando repositório
```sh
$ git remote rename origin local
```

- Atualizando repositório local (Pull)
```sh
$ git pull server develop
```

- Merge, unindo trabalho.
- Usar commit message para o merge: "Merge from feature/newBranch to devlop"
```sh
$ git merge feature/newBranch
```

# Pretty

- Configuração global
```sh
$ git config --global alias.graph "log --graph --abbrev-commit --decorate --format=format:'%C(bold blue)%h%C(reset) - %C(bold green)(%ar)%C(reset) %C(white)%s%C(reset) %C(dim white)- %an%C(reset)%C(auto)%d%C(reset)'"
```
- Acessando o comando
```sh
$ git graph
```

# Desfazer no GIT

### Com o git checkout nós desfazemos uma alteração que ainda não foi adicionada ao index ou stage, ou seja, antes do git add. Depois de adicionar com git add, para desfazer uma alteração, precisamos tirá-la deste estado, com git reset. Agora, se já realizamos o commit, o comando git revert pode nos salvar.

- Desfazer modificações a serem adicionadas
- Irá desfazer em todo o código.
```sh
$ git checkout -- index.html
```

- Desfazer modificações depois de serem adicionadas
- Irá desfazer em todo o código.
```sh
$ git reset HEAD index.html
```

- Desfazer modificações depois de serem comitadas
- Irá criar um novo commit desfazendo o anterior.
```sh
$ git revert ed85f5f
```
