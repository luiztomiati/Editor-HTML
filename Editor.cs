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
    short salvar = 0;
    ConsoleKey key;
    var file = new StringBuilder();
    do
    {
      var keyInfo = Console.ReadKey(true);
      key = keyInfo.Key;
      if (key == ConsoleKey.Escape)
      {
        break;
      }
      file.Append(keyInfo.KeyChar);
      Console.Write(keyInfo.KeyChar);
      file.Append(Environment.NewLine);
    } while (true);

    while (salvar != 1 && salvar != 2)
    {
      Console.WriteLine("\nDeseja salvar o arquivo?\n 1 - Salvar\n 2 - Sair");
      salvar = short.Parse(Console.ReadLine());
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
    Console.WriteLine(file);
    Console.WriteLine("Qual o caminho para salvar?");
    var path = Console.ReadLine();
    try
    {
      string directory = Path.GetDirectoryName(path);
      if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
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
