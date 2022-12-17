namespace TextEditor
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Menu();
    }
    static void Menu()
    {
      Console.Clear();
      Console.WriteLine($"====EDITOR DE TEXTOS====");
      Console.WriteLine($"1 - Abrir arquivo");
      Console.WriteLine($"2 - Criar arquivo");
      Console.WriteLine($"0 - Sair");
      Console.WriteLine($"========================");
      Console.Write($"Opção: ");

      short option = short.Parse(Console.ReadLine());

      switch (option)
      {
        case 0:
          {
            Console.Clear();
            System.Environment.Exit(0);
            break;
          }
        case 1: Abrir(); break;
        case 2: Editar(); break;
        default: Menu(); break;
      }
    }
    static void Abrir()
    {
      Console.Clear();
      Console.Write($"Informe o caminho do arquivo: ");
      string path = Console.ReadLine();

      using (var file = new StreamReader(path))
      {
        string text = file.ReadToEnd();
        Console.WriteLine($"{text}");
      }

      Console.WriteLine($"");
      Console.ReadLine();
      Menu();

    }
    static void Editar()
    {
      Console.Clear();
      Console.WriteLine($"Digite seu texto abaixo");
      Console.WriteLine($"ESC - Sai do modo de inserção");
      Console.WriteLine($"=============================");
      string text = "";
      do
      {
        text += Console.ReadLine();
        text += Environment.NewLine;
      }
      while (Console.ReadKey().Key != ConsoleKey.Escape);
      Salvar(text);

    }
    static void Salvar(string text)
    {
      Console.Clear();
      Console.Write($"Informe o caminho para salvar: ");
      var path = Console.ReadLine();
      using (var file = new StreamWriter(path))
      {
        file.Write(text);
      }
      Console.WriteLine($"Arquivo {path} Salvo com Sucesso!");
      Console.ReadLine();
      Menu();

    }
  }
}