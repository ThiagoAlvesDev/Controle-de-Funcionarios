# Sistema de Gerenciamento de Colaboradores

* Um sitema que efetua cadastro e edição de seus colaboradores, consumindo a api para validar o cnpj digitado.

* A API utilizada foi ReceitaWS sua documentação está disponivel em <a href="https://www.receitaws.com.br/">ReceitaWS</a>

## Arquitetura e Stack
<hr />

* Foi adotado a Arquitetura MVC(Model, View, Controller)
* A implementação é feita em C#;
* A persistência dos dados é feita em SQLite usando o <a href="https://learn.microsoft.com/en-us/ef/">EntityFramework </a>
* Foi utilizado framework Asp.Net (documentação disponivel em <a href="https://dotnet.microsoft.com/pt-br/apps/aspnet">Aps.Net</a>)
* As bibliotecas utilizadas no projeto podem ser  visualizadas em [PackageReference.txt](/ControleDeFuncionarios/PackageReference.txt)

## Execução
<hr>


* Executar as bibliotecas.
* Configure o SQLite   <a href="https://www.sqlite.org/index.html">documentação SQLite</a>    
* Configurar o banco de dados. criando a connection string e adicionando em "ConfigureServices" dentro de Startup.cs
* Apos as configurações de connection String e SQLite  inicie o banco de dados no projeto.
* Comando para adicionar o banco de dados local. 
  -- Package Manager Console     
 
       Add-Migragrion NomeQueDesejar
       update-database
       
  -- Terminal
      
       dotnet ef migrations add NomeDaMigracao
       dotnet ef database update

      
 * Comando para Executar o projeto    
   -- Package Manager Console
       
       dotnet run
    

   -- Terminal

       dotnet watch run  





