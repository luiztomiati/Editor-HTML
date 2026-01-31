<h1>📝 Editor de Texto no Console (C#)</h1>
<p>
  Um editor de texto simples desenvolvido em C# para terminal, com suporte a escrita linha por linha, navegação básica e salvamento de arquivos.
O projeto foi criado com o objetivo de praticar lógica, manipulação de teclado (ConsoleKey) e controle de cursor no console.
</p>

<h1>🚀 Funcionalidades</h1>
<ul>
 
   <li> Menu inicial no terminal </li>
  
   <li> Modo editor de texto </li>
  
   <li> Captura de teclas em tempo real </li>
   
   <li>Controle manual do cursor no console </li>
  
   <li>Salvamento do texto em arquivo .txt</li>
  
  <li>Criação automática do arquivo no diretório atual caso a pasta não exista</li>

</ul>

<h2>Suporte às teclas:</h2>
<pre>
⌨   Caracteres normais
↵   Enter (nova linha)
␣   Espaço
⇥   Tab
⌫   Backspace (inclusive voltando linha)
⎋   ESC (sair do editor)
</pre>

<h1>🧠 Conceitos aplicados</h1>
<ul>
  <li> Console.ReadKey(true) </li>
  
  <li> ConsoleKey </li>
  
  <l1> StringBuilder para edição de texto </l1>
  
  <h2> Controle de cursor com: </h2>
  
  <li> Console.CursorLeft </li>
  
  <li> Console.CursorTop </li>
  
  <li> Console.SetCursorPosition </li>
  
  <li> Manipulação de linhas usando List<int> </li>
  
  <li> Estrutura de menus no console </li>
  
  <li> Escrita de arquivos com StreamWriter </li>
</ul>
<h1>📂 Estrutura do projeto</h1>
<pre>
  Editor-HTML/
  │
  ├── Menu.cs        # Menu principal e layout da tela
  ├── Editor.cs      # Lógica do editor de texto
  ├── Program.cs     # Ponto de entrada
</pre>

<h1>▶️ Como executar</h1>
<pre>
Clone o repositório:
git clone https://github.com/luiztomiati/Editor-HTML

Entre na pasta do projeto:
cd Editor-HTML

Execute:
dotnet run
</pre>

<h1>💾 Salvamento de arquivos</h1>
<pre>
Ao pressionar ESC, o editor pergunta se deseja salvar.
O usuário informa o caminho do arquivo.

Caso a pasta não exista, o arquivo é salvo no diretório atual.
</pre>

<h1>⚠️ Observações</h1>
<pre>
O editor funciona inteiramente no console.

Não utiliza bibliotecas externas.
O controle de cursor e linhas é feito manualmente, simulando um editor real.
Projeto focado em lógica e domínio do terminal, não em interface gráfica.
</pre>
