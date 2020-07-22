# Teste para Analista Desenvolvedor da AEVO

Olá candidato,

Primeiramente parabéns por ter chegado até aqui! 

Esse desafio consiste em uma pequena implementação para avaliarmos seu conhecimento em back-end (.NET, C#) e Front-End (HTML5, CSS, JavaScript e Angular)

Para realizar o teste, você deve dar um fork neste repositório e depois clona-lo na pasta <document_root> da máquina que está realizando o teste.

Crie um branch com seu nome, e quando finalizar todo o desenvolvimento, você deverá enviar um pull-request com sua versão.

Neste repositório existe um projeto base em .NET Core 3.1 baseado em um tutorial do Macorrati (referência quando o assunto é .NET) http://www.macoratti.net/19/10/ang7_apinc1.htm 
Fiquem a vontade para explorar o tutorial. Apesar do projeto do respositório estar atualizado para a versão 3.1, a estrutura é a mesma.

# O teste
## Back-End/.NET
A primeira etapa será o desenvolvimento backend!

Descrição:

Neste respositório já existe uma implementação básica com o CRUD para o objeto Aluno.
Você deverá desenvolver novos métodos para a 'mini api' e reutilizar métodos existentes do projeto base, conforme especificação abaixo:


Você pode utilizar um banco de dados local SQL Server para a persistência dos dados.
Cada carro deve ter ID, Marca, Modelo, Ano.
Sugerimos o retorno dessa 'mini api' nas seguinte urls:

/carros - [GET] deve retornar todos os carros cadastrados.
/carros - [POST] deve cadastrar um novo carro.
/carros/{id}[GET] deve retornar o carro com ID especificado.
/carros/{id}[PUT] deve atualizar os dados do carro com ID especificado.
/carros/{id}[DELETE] deve apagar o carro com ID especificado.


## Front-End
Para a segunda etapa do teste, você deverá desenvolver uma SPA (Single Page Application) e nela deve ser possível:

Ver a lista de carros cadastrados
Criar um novo carro
Editar um carro existente
Apagar um carro existente
Obs:

A página deve ser responsiva.
A página deve funcionar 100% via AJAX, sem outros carregamentos de páginas.
Ao criar/editar um carro, o campo "marca" deverá ser um SELECT
Observações importantes:
Você não deve se prender aos arquivos do repositório. Fique a vontade para criar outros.
Você pode usar frameworks, tanto para o front-end, quanto para o back-end, mas um código limpo será melhor avaliado.
Você pode usar ferramentas de automação (Grunt, Gulp), mas deverá informar o uso completo para funcionamento do teste.
Será considerado ponto positivo no teste a utilização de JS puro, orientação a objetos, design patterns e rotinas para testes.
Será considerado ponto positivo o tempo gasto na realização do teste. Menos tempo e tudo funcionando conforme pedido será melhor avaliado.



