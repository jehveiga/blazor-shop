# Blog Web API

[![NPM](https://img.shields.io/github/license/jehveiga/Blog-api)](https://github.com/jehveiga/blazor-shop/blob/main/LICENCE)

# Sobre o projeto

Desenvolvimento de uma aplicação Blazor Webassembly consumindo os end-points de uma aplicação Web API com ASP.NET Core. Neste projeto foi desenvolvido por completo uma aplicação Blazor Web Assembly com ASP.NET MVC Web API.

Este projeto suporta todas as versões do ASP.NET Core (até a 8.0) e foi utilizado o Visual Studio 2022 para a construção da aplicação final.

O projeto está disponível na versão 8.0 foi realizado uma criação de vitrine de produtos de uma loja contendo os dados dos produtos Ex: "Nome, Descrição, Imagem do produto, Preço, Quantidade" que são os dados que foram obtidos pela API que foi criada para o projeto obtendo as informações pelo projeto Blazor, implementado um carrinho de compra que são adicionados produtos contendo os dados dos produtos e dados adicionais como "Quantidade Total dos produtos do carrinho" e "Valor total dos produtos adicionados".
Utilizado o tratamento de erros caso algum problema no servidor ou outra exceção ocorrer, implementação de uma library de classes Dtos para trafego de dados entre a aplicação Blazor e API, utilizados as validações das classes Dtos usando as regras de negócios disponíveis na aplicação.

Usado nos envios/retorno se necessário envio de parâmetro, foi utilizado informações para o consumo dos end-points as Dtos para transitar dados para as classes modelos para persistencias de dados no banco, utilizados Serialização e Deserialização JSON a quem estará consumindo o serviço da Web API, usado as Models, Controller, Rotas no projeto como padrão de arquitetura, utilizado SQL Server como banco de dados alvo e com suporte de mudança se necessário usando príncipios de Injeção de Dependência e Inversão de controle do contexto que representa o banco de dados na aplicação, nomeado os end-points conforme o dados que transita na aplicação, utilizado os métodos Assíncronos para melhor velocidade de resposta e melhor processamentos de informações.

Utilizado o conceito de cache na aplicação Blazor para melhorar o desempenho na apresentação dos produtos na vitrine de produtos da loja web. 
Implementados adição e exclusão de produtos do carrinho de compra e alteração da quantidade de produto escolhido no carrinho atualizado seu preço e quantidade totais em tempo real.  
Utilizando a arquitetura limpa e principios SOLID nos projetos.

# Apresentação Blazor - Vitrine Produtos

## Vitrine de produtos - visualização dos produtos separados por categoria e visualização dos detalhes individuais
![Apresentacao Blazor Vitrine de Produtos](https://github.com/jehveiga/blazor-shop/blob/main/assets/apresentacao-vitrine-produtos.gif)

# Apresentação Blazor - Carrinho de Compras

## Carrinho de Compras - adicionar, atualizar quantidade e excluir produtos do carrinho
![Apresentacao Blazor Carrinho de Compras](https://github.com/jehveiga/blazor-shop/blob/main/assets/apresentacao-carrinho-compras.gif)

# Apresentação - Web API (Produtos e Categoria)

![Apresentacao Web API Produtos e Categoria](https://github.com/jehveiga/blazor-shop/blob/main/assets/apresentacao-API.gif)

# Tecnologias Utilizadas

## Back end

- C#

## Outras Tecnologias

- Blazor Webassembly
- Swagger
- Asp.Net Core
- Asp.Net Web API
- Blazored Local Storage
- Boostrap 5
- Boostrap Icons
- JavaScript
- CSS
- Html
- Docker

## Banco de Dados

- SQL Server

# Autor 

Jefferson Veiga

https://www.linkedin.com/in/jefferson-veiga-dev/
