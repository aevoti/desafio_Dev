# Desafio Final para Analista Desenvolvedor da AEVO

Olá candidato,

Primeiramente, parabéns por ter chegado até aqui! Essa tem sido uma jornada seletiva de altíssimo nível, mas você brilhou em cada etapa e não temos dúvidas de que fará isso mais uma vez! <br>

Esse desafio consiste em uma pequena implementação para avaliarmos seu conhecimento em back-end (.NET, C#) e Front-End (HTML5, CSS, JavaScript e Angular)

Para realizá-lo, você deverá dar um fork neste repositório e depois cloná-lo em alguma pasta de sua preferencia, na máquina que estiver realizando o teste.

Crie um branch com seu nome a partir da master e, quando finalizar todo o desenvolvimento, você deverá enviar um pull-request com sua versão.<br>

Neste repositório, existe um projeto base em .NET Core 3.1 baseado em um tutorial do Macorrati (referência quando o assunto é .NET) http://www.macoratti.net/19/10/ang7_apinc1.htm . Fique à vontade para explorar o tutorial com os detalhes da configuração do projeto. Apesar de o projeto deste repositório estar atualizado para a versão 3.1, a estrutura é a mesma do tutorial.

# O Desafio
## Back-End/.NET
A primeira etapa será o desenvolvimento back-end!

Descrição:

Neste repositório já existe uma implementação básica com o CRUD para o objeto Aluno. Você deverá desenvolver novos métodos para a 'mini api' ou reutilizar métodos existentes do projeto base para as implementações necessárias.

Cada Aluno possui as propriedades AlunoId, Nome e Email. Sugerimos o retorno dessa 'mini api' nas seguinte urls: 

/alunos      -[GET] deve retornar todos os alunos cadastrados.<br>
/alunos       -[POST] deve cadastrar um novo aluno. <br>
/alunos/{id}  -[GET] deve retornar o aluno com ID especificado. <br>
/alunos/{id}  -[PUT] deve atualizar os dados do aluno com ID especificado. <br>
/alunos/{id}  -[DELETE] deve apagar o aluno com ID especificado. <br>

Você pode utilizar um banco de dados local SQL Server para a persistência dos dados. Utilizar a migration existente no projeto .NET base, para gerar a base de dados pode ajudar bastante!

## Front-End /Angular
Para a segunda etapa do teste, você deverá desenvolver uma SPA (Single Page Application) utilizando Angular. Nela, deverá ser possível:

- Ver a lista de alunos cadastrados
- Criar um novo aluno
- Editar um aluno existente
- PEsquisar um aluno pelo nome


### Observações importantes:
A base para o projeto Front-End não está neste repositório. Você deverá criar a sua baseado na versão do Angular de sua preferência.<br>
Você não deve se prender somente aos arquivos do repositório. Fique à vontade para criar outros.<br>
Você pode usar ferramentas de automação, mas deverá informar o uso completo para funcionamento do desafio.<br><br>

Serão considerados pontos positivos, porém não são obrigatórios: 
- utilização de testes de unidade
- boas práticas de orientação a objetos
- design patterns e rotinas para testes
- utilização de documentação para o mini projeto
- publicação do projeto em algum ambiente online 
<br>

Qualquer problema ou dificuldade com o repositório, você pode entrar em contato conosco pelos e-mails, marcelo.cogo@aevo.com.br ou rh@aevo.com.br para que possamos sanar todas as dúvidas!
<br><br>
Estamos sempre em busca de melhoria. Por isso, caso tenha alguma sugestão, fique à vontade para compartilhar conosco! Boa sorte! 💛




