# Projeto Django Combio

Este é um projeto Django desenvolvido para a Combio, uma descrição resumida do projeto.

## Funcionalidades

- Sistema de menu baseado em tabelas e permissões.
- Autenticação de usuários com login via Google.
- Outras funcionalidades relevantes do projeto.

## Requisitos

- Python 3.x
- Django
- Outras dependências (listar todas as dependências relevantes)

## Instalação

1. Clone este repositório para o seu ambiente local.
2. Crie um ambiente virtual usando o comando: `python -m venv venv`.
3. Ative o ambiente virtual com o comando: 
   - No Windows: `venv\Scripts\activate`
   - No Linux/Mac: `source venv/bin/activate`
4. Instale as dependências com o comando: `pip install -r requirements.txt`.
5. Execute as migrações do banco de dados com o comando: `python manage.py migrate`.
6. Inicie o servidor de desenvolvimento com o comando: `python manage.py runserver`.

## Configuração

Antes de executar o projeto, é necessário realizar algumas configurações adicionais.

1. Crie um projeto no Google Cloud Platform (GCP) para obter as credenciais de autenticação do login via Google.
2. Configure as credenciais do login via Google no arquivo de configuração do projeto (`settings.py`).
3. Configure as tabelas e permissões do sistema de menu de acordo com os requisitos da Combio.
4. Outras configurações específicas do projeto (se houver).

## Uso

- Acesse o sistema através do seu navegador web e faça login usando a opção de login via Google.
- Explore o sistema de menu para acessar as diferentes funcionalidades disponíveis.
- Realize as ações relevantes do projeto (criar, editar, excluir, etc.) de acordo com as permissões atribuídas ao seu usuário.


## Licença

Este projeto é licenciado sob a [MIT License](LICENSE).
