public class Menu
{
  public static void Show()
  {
    var largura = 30;
    var altura = 10;
    CriacaoTela(largura, altura);
    MenuOpcoes(largura);
    int opcao = int.Parse(Console.ReadLine());
    ValidarOpcao(opcao);

  }
  public static void CriacaoTela(int largura, int altura)
  {
    Console.Clear();
    Console.SetCursorPosition(1, 0);
    Console.Write('+' + new string('-', largura - 1) + '+');
    for (var i = 1; i < altura; i++)
    {
      Console.SetCursorPosition(1, i);
      Console.Write("|");
      Console.SetCursorPosition(largura + 1, i);
      Console.Write("|");
    }
    Console.SetCursorPosition(1, altura);
    Console.Write('+' + new string('-', largura - 1) + '+');
  }
  public static void MenuOpcoes(int largura)
  {
    Console.SetCursorPosition(largura / 2 - 3, 0);
    Console.WriteLine("EDITOR HTML");
    Console.SetCursorPosition(largura / 2 - 5, 2);
    Console.WriteLine("OPÇÕES");
    Console.SetCursorPosition(largura / 2 - 3, 4);
    Console.WriteLine("1 - Novo arquivo");
    Console.SetCursorPosition(largura / 2 - 3, 5);
    Console.WriteLine("2 - Abrir arquivo");
    Console.SetCursorPosition(largura / 2 - 3, 6);
    Console.WriteLine("0 - Sair");
    Console.SetCursorPosition(largura / 2 - 3, 8);
    Console.Write("Opção: ");
  }
  public static void ValidarOpcao(int opcao)
  {
    switch (opcao)
    {
      case 1: Editor.Show(); break;
      case 2: Console.WriteLine("Exibir arquivo"); break;
      case 0:
        {
          Console.Clear();
          Environment.Exit(0);
          break;
        }
    }
  }
}