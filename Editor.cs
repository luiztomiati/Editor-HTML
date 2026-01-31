using System;
using System.Text;

public static class Editor
{
  public static void Show()
  {
    Console.Clear();
    Console.WriteLine("MODO EDITOR");
    Iniciar();
  }
  public static void Iniciar()
  {
    bool erro = false;
    short salvar = 0;
    ConsoleKey key;
    var file = new StringBuilder();
    List<int> linhas = new List<int>() { 0 };
    do
    {
      var keyInfo = Console.ReadKey(true);
      key = keyInfo.Key;
      if (key == ConsoleKey.Escape)
      {
        break;
      }
      if (key == ConsoleKey.Tab)
      {
        string tab = "\t";
        file.Append(tab);
        Console.Write(tab);
        continue;
      }
      if (key == ConsoleKey.Enter)
      {
        string enter = Environment.NewLine;
        file.Append(enter);
        Console.Write(enter);
        linhas.Add(0);
        continue;
      }
      if (key == ConsoleKey.Spacebar)
      {
        string barraEspaco = " ";
        file.Append(barraEspaco);
        Console.Write(barraEspaco);
        linhas[linhas.Count - 1]++;
        continue;
      }
      if (key == ConsoleKey.Backspace)
      {
        if (file.Length > 0)
        {
          file.Remove(file.Length - 1, 1);
          var esquerda = Console.CursorLeft;
          var topo = Console.CursorTop;

          if (esquerda > 0)
          {
            Console.SetCursorPosition(esquerda - 1, topo);
            Console.Write(" ");
            Console.SetCursorPosition(esquerda - 1, topo);
          }
          else if (esquerda == 0 && topo != 1 && linhas.Count > 1)
          {
            file.Remove(file.Length - 1, 1);
            linhas.RemoveAt(linhas.Count - 1);

            var ultimaColuna = linhas[linhas.Count - 1];
            Console.SetCursorPosition(ultimaColuna, topo - 1);
          }
          continue;
        }
      }
      if (!char.IsControl(keyInfo.KeyChar))
      {
        file.Append(keyInfo.KeyChar);
        Console.Write(keyInfo.KeyChar);
        linhas[linhas.Count - 1]++;
      }
    } while (true);

    while (salvar != 1 && salvar != 2)
    {
      if (!erro)
      {
        Console.WriteLine("\nDeseja salvar o arquivo?\n 1 - Salvar\n 2 - Sair");
      }
      if (!short.TryParse(Console.ReadLine(), out salvar))
      {
        erro = true;
        Console.WriteLine("Digite uma opção valida");
        continue;
      }
      switch (salvar)
      {
        case 1: Salvar(file); break;
        case 2: Environment.Exit(0); break;
        default:
          Console.WriteLine("Opção invalida digite novamente!"); break;
      }
    }
  }
  public static void Salvar(StringBuilder file)
  {
    var path = string.Empty;
    while (string.IsNullOrEmpty(path))
    {
      Console.WriteLine("Qual o caminho para salvar?");
      path = Console.ReadLine();
    }
    try
    {
      if (!string.IsNullOrEmpty(Path.GetDirectoryName(path)) && !Directory.Exists(Path.GetDirectoryName(path)))
      {
        Console.WriteLine("Pasta não existe, criando arquivo no diretório atual...");
        path = Path.GetFileName(path);
      }

      var diretorio = Path.GetDirectoryName(path);
      if (!string.IsNullOrEmpty(diretorio) && !Directory.Exists(diretorio))
      {
        Console.WriteLine("Pasta não existe, criando arquivo no diretório atual...");
        path = Path.GetFileName(path);
      }
      using (var escrita = new StreamWriter(path))
      {
        escrita.Write(file.ToString());
      }
      Console.WriteLine("Arquivo salvo com sucesso! na pasta: " + Path.GetFullPath(path));
      Thread.Sleep(2000);
      Menu.Show();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }
}
