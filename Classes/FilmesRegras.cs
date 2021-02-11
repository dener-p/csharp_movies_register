using System;
using Shows;
namespace Filmes
{
  public class FilmesRegras
  {
    static FilmesRepositorios repositorio = new FilmesRepositorios();

    public void usuarioOpcao()
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarFilmes();
            break;
          case "2":
            InserirFilme();
            break;
          case "3":
            AtualizarFilme();
            break;
          case "4":
            ExcluirFilme();
            break;
          case "5":
            VisualizarFilme();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsuario = ObterOpcaoUsuario();
      }
    }
    public void ListarFilmes()
    {
      Console.WriteLine("Listar Filmes");

      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhum filme encontrado.");
        return;
      }
      int count = 0;
      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();
        if (!excluido)
        {
          Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
          count++;
        }

      }
      if (count == 0)
      {
        Console.WriteLine("Nenhum filme encontrado.");
      }
    }

    public void InserirFilme()
    {
      Console.WriteLine("Inserir novo Filme");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.WriteLine("Digite o gênero das opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o título do filme: ");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o Ano de Lançamento do filme: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a Descrição do filme: ");
      string entradaDescricao = Console.ReadLine();

      Console.WriteLine("Digite a duração(min): ");
      int entradaDuracao = int.Parse(Console.ReadLine());

      Filmes novoFilme = new Filmes(
        id: repositorio.ProximoId(),
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        ano: entradaAno,
        descricao: entradaDescricao,
        duracao: entradaDuracao
      );

      repositorio.Insere(novoFilme);
    }

    public void AtualizarFilme()
    {
      Console.WriteLine("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.WriteLine("Digite o gênero das opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o título do filme: ");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o Ano de lançamento do filme :");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a Descrição do filme: ");
      string entradaDescricao = Console.ReadLine();

      Console.WriteLine("Digite a duração do filme(min): ");
      int entradaDuracao = int.Parse(Console.ReadLine());

      Filmes atualizaFilme = new Filmes(id: indiceFilme,
      genero: (Genero)entradaGenero,
      titulo: entradaTitulo,
      ano: entradaAno,
      descricao: entradaDescricao,
      duracao: entradaDuracao);

      repositorio.Atualiza(indiceFilme, atualizaFilme);

    }

    public void ExcluirFilme()
    {
      Console.WriteLine("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      repositorio.Exclui(indiceFilme);
    }

    public void VisualizarFilme()
    {
      Console.WriteLine("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      var filme = repositorio.RetornaPorId(indiceFilme);
      // vai mostrar o ToString():
      Console.WriteLine(filme);
    }
    public string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Dio Filmes a seu dispor!");
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine("1 - Listar Filmes");
      Console.WriteLine("2 - Inserir Filme");
      Console.WriteLine("3 - Atualizar Filme");
      Console.WriteLine("4 - Excluir Filme");
      Console.WriteLine("5 - Visualizar Filme");
      Console.WriteLine("C - Limpar tela");
      Console.WriteLine("x - Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;

    }
  }
}