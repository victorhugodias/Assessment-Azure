# Projeto da faculdade Infnet utilizando C# e Azure para avaliar as competências dos alunos.
#### Descrição do Sistema.

Falta um mês para o natal e os stakeholders decidiram que a loja deverá entrar em produção.

Nesta etapa você deverá:

- Publicar todos os Serviços WCF no Microsoft Azure
Serviço "Gerenciador de Produtos", "Gerenciador de Compras" e Serviço de Dados para obtenção dos produtos disponíveis

- Criar um Banco de Dados SQL com uma Tabela de Produtos contendo os campos do produto.
string Id - Identificador único que um produto. Este atributo não é editável, deverá ser preenchido no construtor da classe.
string Nome - Modelo do produto.
string Categoria - Grupo de produtos semelhantes. Exemplo: Eletrônicos, Livros etc.
string Imagem - Armazenará a URL da imagem do produto (poderá ser armazenada como Blob)
string Preço - Valor cobrado para uma unidade do produto.
int Quantidade - Quantidade disponível em estoque de um produto.

- Opcionalmente desenvolver uma interface simples para compra de produtos
A interface deverá exibir a lista de produtos separados por categoria e possibilitar a compra utilizando o respectivo serviço da WCF.

- Opcionalmente desenvolver uma interface para os empacotadores receberem os pedidos
Essa interface deverá receber as mensagens do "Service Bus"

- Criar um grupo "Estoquistas" e um grupo "Empacotadores" no Active Directory.
Adicionar pelo menos um usuário em cada grupo criado no Active Directory (grupo "Estoquistas" e "Empacotadores").

