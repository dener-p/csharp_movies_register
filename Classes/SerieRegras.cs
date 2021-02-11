using System;
using Shows;
namespace Series
{
  public class SerieRegras
  {
    static SeriesRepositorio repositorio = new SeriesRepositorio();

    public void usuarioOpcao()
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarSeries();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
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
    public void ListarSeries()
    {
      Console.WriteLine("Listar Séries");

      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada.");
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
        Console.WriteLine("Nenhuma série cadastrada.");
        return;
      }
    }

    public void InserirSerie()
    {
      Console.WriteLine("Inserir nova série");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.WriteLine("Digite o gênero das opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o título da série: ");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o Ano de Início da Série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      Console.WriteLine("Digite o número de episódios: ");
      int entradaEpisodios = int.Parse(Console.ReadLine());

      Serie novaSerie = new Serie(id: repositorio.ProximoId(),
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        ano: entradaAno,
        descricao: entradaDescricao, episodios: entradaEpisodios);

      repositorio.Insere(novaSerie);
    }

    public void AtualizarSerie()
    {
      Console.WriteLine("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.WriteLine("Digite o gênero das opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o título da série: ");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o Ano de Início da Série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      Console.WriteLine("Digite o número de episódios: ");
      int entradaEpisodios = int.Parse(Console.ReadLine());

      Serie atualizaSerie = new Serie(id: indiceSerie,
      genero: (Genero)entradaGenero,
      titulo: entradaTitulo,
      ano: entradaAno,
      descricao: entradaDescricao,
      episodios: entradaEpisodios);

      repositorio.Atualiza(indiceSerie, atualizaSerie);

    }

    public void ExcluirSerie()
    {
      Console.WriteLine("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      repositorio.Exclui(indiceSerie);
    }

    public void VisualizarSerie()
    {
      Console.WriteLine("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(indiceSerie);
      // vai mostrar o ToString():
      Console.WriteLine(serie);
    }
    public string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Dio Séries a seu dispor!");
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine("1 - Listar Séries");
      Console.WriteLine("2 - Inserir séries");
      Console.WriteLine("3 - Atualizar série");
      Console.WriteLine("4 - Excluir série");
      Console.WriteLine("5 - Visualizar Série");
      Console.WriteLine("C - Limpar tela");
      Console.WriteLine("x - Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;

    }
  }
}