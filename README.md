# Cronos
Deloitte Gama Cronos case desafio Back End

API para gerenciamento do conteúdo do site institucional da Agência Cronos.

A API faz CRUD de Serviços, Posts e Integrantes da Equipe, permitindo que o administrador
do site consiga criar, editar, deletar e visualizar os dados através de um painel
administrativo.

REQUISITOS MÍNIMOS BACK-END
1. Códigos neste repositório com README.md descrevendo a tecnologia do projeto
*** Tecnologia do Projeto ***
A solução é composta de 3 projetos, todos desenvolvidos com a versão 6.0, the latest version of .Net Core which was released on November 8, 2021.
✦ Projeto Cronos.Api => API REST conectada a um bano de dados relacional InMemory;
✦ Projeto Cronos.UnitTest => Testes automáticos para os serviços da api;
✦ Projeto Cronos.Console => Testes automáticos em aplicativo console.

Foi desenvolvida com o Visual Studio 2022. Pode ser aberta com duplo clique no arquivo CronosCase.slh.

Os testes automáticos podem ser executados pela execução do Cronos.Console ou pelo Visual Studio, a partir do Test Explorer.

2. API
a. CRUD (Criar, ler, atualizar e deletar) de Serviços => Ver Cronos.Api.Controllers.ServiceController
b. CRUD (Criar, ler, atualizar e deletar) de Posts => Ver Cronos.Api.Controllers.PostController
c. CRUD (Criar, ler, atualizar e deletar) de Integrantes da Equipe  => Ver Cronos.Api.Controllers.TeamMemberController
3. Banco de dados:
a. Utilizar banco de dados relacional => Incluído um banco InMemory, om a tecnologia EntityFramework
b. Adicionar dados para teste => dados inicias foram inseridos nos módulos SeedPost, SeedService e SeedTeamMember

OPCIONAIS BACK-END
*** Autenticação de administrador para gerenciamento do conteúdo ***
  Os recursos para a autenticação foram instalados com base em 2 bibliotecas:
  Microsoft.AspNetCore.Identity.EntityFrameworkCore e
  Microsoft.AspNetCore.Authentication.JwtBearer
  refletidos na api pelos módulos:
  JwtAndIdentity.cs => Configura a autenticação no builder da aplicação web
  e AuthetivateController.cs => Endpoint que autentica o usuário.
  Mas a autrenticação não foi ainda implementada, faltano o seguinte:
  TODO => Permitir o cadastro de novos usuários;
  TODO => Autenticar os usuários e o Admin;
  TODO => Restringir o acesso apenas aos usuários autenticados
  TODO => Autoriza apenas ao Admin, o acesso à gestão
  (ainda resta algum tempo, vou continuar implemntando até a meia noite)
*** 

3. Documentação da API => Autodoumentada
4. Testes automatizados => ptojetos Cronos.Console e Cronos.UnitTests
5. Deploy da aplicação => Nas pastas Deploy (api) e DeployConsole.
6. Deploy no Docker => https://registry.hub.docker.com/scartaxo



