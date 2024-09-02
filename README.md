# Conecta-Brasil


1 Introdução
A globalização facilita e muito o dia a dia, nunca antes as informações e notícias estiveram tão acessíveis. Atualmente qualquer pessoa com um celular, acesso a internet e um conhecimento básico de como utilizar consegue adquirir informações sobre qualquer assunto. 
Porém nem sempre as informações são fáceis de serem encontradas, e é necessária um pouco mais de experiência e conhecimento de onde encontrar que tipo de informação. Por exemplo, na cidade de Videira, se quiser saber sobre um acidente que ocorreu em determinado local é preciso acessar o Facebook ou o site de alguma das emissoras de rádio. Para saber sobre os eventos abertos ao público como feiras, shows ou amostras é preciso acessar a rede social dos organizadores ou “dar a sorte” de ouvir quando é anunciado na rádio se chegar a ser anunciado.
O problema detectado é de descentralização de informações, porém não é algo exclusivo da cidade de Videira, isso pode ser encontrado em todos os tipos de comunidades. Buscando solucionar essa “dor” a ideia sugerida é um site em que tanto pessoas normais quanto organizações podem publicar informações sobre eventos, acontecimentos, situações perigosas e quaisquer outras informações que sejam relevantes para  a comunidade.


2 Desenvolvimento
O site Conecta Brasil é um portal de notícias e avisos que pode ser utilizado por qualquer pessoa. Tem como objetivo ser uma plataforma com funcionamento semelhante ao reddit, mas voltado para notícias e informações. 

2.1 Escopo
Para que o site esteja completo e funcional, deve oferecer algumas funcionalidades.
A criação de contas, login e logoff é necessária para que cada usuário possa acessar o portal e visualizar conteúdos relevantes para ele. 
A interface do feed principal seria algo semelhante com o redit com um campo para fazer pesquisas, na esquerda uma lista com alguns filtros principais, na parte central serão exibidos os conteúdos e na direita algumas sugestões de conteúdos e anúncios de eventos. 
Cada usuário pode criar suas próprias publicações, durante a publicação é necessário que sejam marcados alguns temas que melhor representem a publicação, como por exemplo notícia, aviso, evento e local. Depois de criada vai passar por uma análise de conteúdo e ser publicada.

2.2 Requisitos funcionais.
1 - Cadastro de usuário
Pessoas podem criar perfis particulares;
Empresas podem criar perfis comerciais;
2 - Configuração de preferência
Deve ser possível selecionar o tipo de informações deseja receber;
Realizar buscas com filtros personalizados;
3 - Criação e visualização de publicações
Criar publicações de notícias ou avisos;
Visualizar as publicações de outras pessoas ou empresas;
4 - Autenticação e validação
Cada usuário pode fazer login apenas em sua conta;

2.3 Requisitos não funcionais.
1 - Desempenho
Deve atualizar as publicações em tempo real;
2 - Usabilidade
Deve ter interface amigável e responsiva;
3 - Segurança
Deve proteger os dados dos usuários;
4 - Manutenibilidade
Código bem documentado para facilitar o seu aprimoramento;
5 - Compatibilidade
Deve possuir interface para computadores e para dispositivos móveis;
Deve estar disponível para todos os navegadores mais utilizados;


3 Diagramação

3.1 Diagrama de classes
O diagrama representa a forma que os usuários serão cadastrados e como interagem com as publicações. Representa a divisão dos usuários entre pessoas comuns e instituições públicas ou empresas. Também representa que cada usuário pode criar diversas publicações e visualizar todas as publicações.




3.2 Diagrama de sequências
O diagrama representa a interação de login e a interação de criar publicação.




3.3 Diagrama de casos de uso
O diagrama representa as funções do sistema e quais delas cada um dos atores pode realizar. 




4 Stack de Desenvolvimento
Para a prototipagem do projeto, será utilizado um conjunto de tecnologias robustas e eficientes. O Visual Studio 2022 foi selecionado como IDE devido à sua ampla gama de ferramentas e integração com as tecnologias .NET.
A linguagem de programação C# será empregada no desenvolvimento do backend, em conjunto com os frameworks ASP.NET MVC e ASP.NET Web API. O ASP.NET MVC fornecerá uma estrutura sólida para a construção de aplicações web com um padrão de projeto Model-View-Controller, enquanto o ASP.NET Web API será utilizado para a criação de APIs RESTful, facilitando a comunicação entre o frontend e o backend.
O frontend da aplicação será desenvolvido utilizando as linguagens HTML e CSS, que são os pilares da construção de interfaces web.
Para o armazenamento e gerenciamento dos dados, será utilizado um banco de dados SQL. A escolha por um SGBD relacional se justifica pela necessidade de modelar dados de forma estruturada e pela facilidade de implementação de consultas complexas.
