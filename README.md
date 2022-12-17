# Configuração do sonarqube no GITLAB em um projeto .NET Core

# Acessar o gitlab e criar um novo projeto

- ![images.png](.attachments/gitlab_new_project.png)

- Escolher essa opção:
- ![images.png](.attachments/gitlab_new_project2.png)

- Escolher nome e criar novo projeto
- ![images.png](.attachments/new_project.png)

- Faça o clone do seu projeto
- ![images.png](.attachments/clone.png)

- Com terminal aberto execute o comando:
- ![images.png](.attachments/dotnet.png)

- Também vamos precisar de um projeto de testes:
- ![images.png](.attachments/tests.png)

- Vamos adicionar a referência da nossa API no projeto de testes
- ![images.png](.attachments/reference.png)

- Perceba que foi adicionado a referência no arquivo Tests.csproj
- ![images.png](.attachments/reference2.png)

- Vamos apagar o arquivo da pasta Controller e criar um HomeController com o seguinte código:
- ![images.png](.attachments/endpoint.png)

- Dentro do projeto de Tests vamos criar uma pasta chamada Controllers.Tests e um arquivo chamado HomeControllerTest com o seguinte código:

- ![images.png](.attachments/endpoint_test.png)

# O projeto de API e TESTS estão configurados, vamos configurar o sonarqube

- Com o docker vamos executar o seguinte comando:
- ![images.png](.attachments/docker.png)

- Após a execução do comando vamos entrar em http://localhost:9000 fazer o login (user e password são: admin)
- ![images.png](.attachments/admin.png)

Após o login será necessário trocar a senha
- ![images.png](.attachments/admin2.png)

- Acessando o painel do sonarqube vamos clicar em manualy
- ![images.png](.attachments/dashboard.png)

- Vamos adicionar um nome e uma project key
- ![images.png](.attachments/key.png)

- Vamos selecionar a opção gitlab
- ![images.png](.attachments/gitlab.png)

- Vamos escolher a linguagem/framework, nesse caso .NET
- ![images.png](.attachments/language.png)

- O tutorial diz para criarmos essas variaveis no gitlab 
- ![images.png](.attachments/config_sonar.png)

- Vamos clicar em Generate Token para gerar o token de acesso ao sonarqube
- ![images.png](.attachments/token.png)

- Copie o Token de acesso ao sonarqube, vamos ao gitlab na opção de configurações>CI/CD
- ![images.png](.attachments/config_sonar2.png)

- Na opção de variaveis vamos clicar em EXPAND
- ![images.png](.attachments/config_sonar3.png)

- Vamos adicionar as variaveis do sonarqube
- ![images.png](.attachments/variable.png)
- ![images.png](.attachments/v1.png)

- Na variavel SONAR_HOST_URL precisamos adicionar o IP ou DNS da maquina que está executando o sonarqube / runner (vamos configurar o runner ainda)
- ![images.png](.attachments/v2.png)

- Na terceira etapa do tutorial precisamos criar um arquivo no nosso projeto chamado .gitlab-ci.yml, esse arquivo é o triger para disparar a pipeline do gitlab
- ![images.png](.attachments/config_sonar4.png)

- Vamos criar o arquivo .gitlab-ci.yml na raiz do projeto e colar o script sugerido pelo tutorial do sonarqube
- ![images.png](.attachments/config_sonar5.png)

- Ao entrar no menu CI/CD>Pipeline, vamos ver que é necessário um runner para executar o script yml que criamos
- ![images.png](.attachments/runner1.png)

- Antes de configurar o runner, vamos fazer algumas mudanças no arquivo yml com o seguinte código:
- ![images.png](.attachments/update_ci.png)

- Nesse momento se commitarmos o código perceba que no menu de CI/CD>Pipeline foi criado uma nova pipeline porém não está sendo executada
- ![images.png](.attachments/pipeline1.png)

- Para que a pipeline seja executada precisamos configurar o runner que é o software que vai executar o arquivo yml
- ![images.png](.attachments/pipeline2.png)

# Configuração do runner

- Instalação do runner [DOCUMENTAÇÃO RUNNER](https://docs.gitlab.com/runner/install/) instale de acordo com o S.O que você estiver usando, no meu caso devo baixar o binário para windows (x64)
- ![images.png](.attachments/bin.png)

- Vamos no menu Settings>CI/CD e copiar a url e registration token
- ![images.png](.attachments/config_runner2.png)

- É importante que a opção (Enable shared runners for this project) esteja desabilitada
- ![images.png](.attachments/config_runner3.png)

- Mova o executável para C: e excute os comandos - Se aparecer acesso negado, execute o gitlab-runner como admin
- ![images.png](.attachments/config_runner.png)

- Execute o gitlab-runner register com os parametros a seguir:
- ![images.png](.attachments/config_runner4.png)

- O runner foi criado, perceba que ainda não está ativo
- ![images.png](.attachments/config_runner5.png)

- Execute o comando a seguir e perceba que o runner já está ativo
- ![images.png](.attachments/config_runner6.png)

- Agora só precisamos executar o comando a seguir:
- ![images.png](.attachments/config_runner7.png)

- Já temos uma pipeline sendo executada
- ![images.png](.attachments/pipeline3.png)


- Com isso podemos finalizar a etapa 3 do tutorial do sonarqube e ir para etapa 4 que é somente aguardar a pipeline executar os comandos do sonarqube
- ![images.png](.attachments/sonar.png)

- Após finalização da pipeline, conseguimos finalizar a implementação do sonarqube no gitlab em um projeto .net
- ![images.png](.attachments/pipeline4.png)
- ![images.png](.attachments/sonarqube.png)
