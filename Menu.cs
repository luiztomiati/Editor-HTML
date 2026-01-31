public class Menu
{
  public int originalBufferWidth;
  public int originalBufferHeight;
  public static void Show()
  {
    try
    {
      int originalBufferWidth = Console.BufferWidth;
      int originalBufferHeight = Console.BufferHeight;
      var largura = 30;
      var altura = 10;
      var menu = new Menu();
      menu.ConfiguraTerminal(true);
      CriacaoTela(largura, altura);
      MenuOpcoes(largura);
      int opcao;
      if (!int.TryParse(Console.ReadLine(), out opcao))
      {
        Show();
      }
      ValidarOpcao(opcao);
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }
  public static void CriacaoTela(int largura, int altura)
  {

    Console.Clear();
    var texto = "EDITOR DE TEXTO";
    var titulo = " " + texto + " ";
    int traco = largura - titulo.Length;
    Console.Write('+' + new string('-', traco / 2) + titulo + new string('-', traco / 2) + '+');
    for (var i = 1; i < altura; i++)
    {
      Console.SetCursorPosition(0, i);
      Console.Write("|");
      Console.SetCursorPosition(largura, i);
      Console.Write("|");
    }
    Console.SetCursorPosition(0, altura);
    Console.Write('+' + new string('-', largura - 1) + '+');
  }
  public static void MenuOpcoes(int largura)
  {
    OpcaoTexto("OPÇÕES", largura, 2, true);
    OpcaoTexto("1 - Criar Texto", largura, 4);
    OpcaoTexto("0 - Sair", largura, 5);
    OpcaoTexto("Opção: ", largura, 7);
  }
  public static void ValidarOpcao(int opcao)
  {
    switch (opcao)
    {
      case 1: Editor.Show(); break;
      case 0:
        {
          Console.Clear();
          Environment.Exit(0);
          break;
        }
    }
  }
  private void ConfiguraTerminal(bool iniciar)
  {
    if (!OperatingSystem.IsWindows())
    {
      return;
    }
    if (iniciar)
    {
      var largura = 60;
      var altura = 30;
      var BufferWidth = Math.Max(largura, Console.WindowWidth);
      var BufferHeight = Math.Max(altura, Console.WindowHeight);
      Console.SetBufferSize(BufferWidth, BufferHeight);
    }
    else
    {
      Console.SetBufferSize(originalBufferWidth, originalBufferHeight);
    }
  }
  static void OpcaoTexto(string texto, int largura, int linha, bool central = false)
  {
    int coluna = 0;
    if (central)
    {
      coluna = (largura - texto.Length - 1) / 2;
      Console.SetCursorPosition(coluna, linha);
      Console.Write(texto);
    }
    else
    {
      coluna = largura / 2;
      Console.SetCursorPosition(coluna / 2, linha);
      Console.Write(texto);
    }
  }
}
