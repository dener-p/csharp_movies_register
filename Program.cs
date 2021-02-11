using System;
using Series;
using Filmes;
namespace Shows
{
  class Program
  {
    static void Main(string[] args)
    {
      string opcaoUsuario = userOption();
      while (opcaoUsuario != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            SerieRegras serieRegras = new SerieRegras();
            serieRegras.usuarioOpcao();
            break;
          case "2":
            FilmesRegras filmesRegras = new FilmesRegras();
            filmesRegras.usuarioOpcao();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        Console.WriteLine();
        opcaoUsuario = userOption();

      }

      Console.WriteLine("Obrigado pro utilizar nossos serviços.");
      Console.ReadLine();

    }
    private static string userOption()
    {
      Console.WriteLine("bem vindo ao seu app de filmes e séries");
      Console.WriteLine("Escolha uma das opções abaixo: ");
      Console.WriteLine("1 - Ver séries");
      Console.WriteLine("2 - Ver filmes");
      Console.WriteLine("C - Limpar tela");
      Console.WriteLine("X - sair");

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
