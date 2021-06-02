using System;
using System.Runtime.InteropServices;
using cadastroDeSeries;
using Classes;


namespace cadastroDeSeries
{
  internal static class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    public static void Main(string[] args)
    {
      int opcaoEscolhida = Menu();
      while (opcaoEscolhida != 6)
      {
        switch (opcaoEscolhida)
        {
          case 1:
            
            ListarSeries();
            break;
          case 2:
            
            InserirSerie();
            break;
          case 3:
            
            AtualizaSerie();
            break;
          case 4:
           
            ExcluiSerie();
            break;
          case 5:
            
            VisualizaSerie();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoEscolhida = Menu();
      }

    }

    private static void ListarSeries()
    {
      Console.WriteLine(">>> LISTAR SERIES <<<");
      var lista = repositorio.Lista();
      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada !!!");
      }

      foreach (var serie in lista)
      {
        Console.WriteLine("#{0} : - {1}", serie.retornaId(), serie.retornaTitulo());
      }
    }

    private static void InserirSerie()
    {
      Console.WriteLine(" >>> INSERIR SÉRIE <<<");
      foreach (int i in System.Enum.GetValues(typeof(Genero))){
        Console.WriteLine("{0} - {1}", i,System.Enum.GetName(typeof(Genero),i));
      }

      Console.WriteLine("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o titulo: ");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o ano de iníco da Serie: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a Descrição da Serie: ");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
        genero:(Genero) entradaGenero, 
        titulo: entradaTitulo, 
        ano: entradaAno, 
        descricao: entradaDescricao);
      repositorio.Insere(novaSerie);
    }

    private static void AtualizaSerie()
    {
      Console.WriteLine(">>> Atuzaliza Serie <<<");
      Console.WriteLine("Informe o ID da serie: ");
      int idSerie = int.Parse(Console.ReadLine());
      
      foreach (int i in System.Enum.GetValues(typeof(Genero))){
        Console.WriteLine("{0} - {1}", i,System.Enum.GetName(typeof(Genero),i));
      }

      Console.WriteLine("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o titulo: ");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o ano de iníco da Serie: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a Descrição da Serie: ");
      string entradaDescricao = Console.ReadLine();
      
      Serie atualizaSerie = new Serie(id: repositorio.ProximoId(), 
      genero:(Genero) entradaGenero, 
      titulo: entradaTitulo, 
      ano: entradaAno, 
      descricao: entradaDescricao);
      repositorio.Atualiza(idSerie, atualizaSerie);
    }

    private static void ExcluiSerie()
    {
      Console.WriteLine(">>> EXCLUIR SERIE <<<");
      Console.WriteLine("Informe o Id da Série para exclusão: ");
      int idSerie = int.Parse(Console.ReadLine());
      repositorio.Excluir(idSerie);
    }

    private static void VisualizaSerie()
    {
      Console.WriteLine(">>>Atualiza Serie <<<");
      Console.WriteLine("Informe o Id da serie: ");
      int idSerie = int.Parse(Console.ReadLine());
      repositorio.RetornaPorId(idSerie);
    }

    private static int Menu()
    {
      Console.WriteLine(" >>> Cadastro De Séries");
      Console.WriteLine("Escolha o número da opção desejada: ");
      Console.WriteLine(" ");
      Console.WriteLine("1 - Listar as séries");
      Console.WriteLine("2 - Inserir nova Série");
      Console.WriteLine("3 - Atualizar Série");
      Console.WriteLine("4 - Excluir Série");
      Console.WriteLine("5 - Visualizar Série");
      Console.WriteLine("6 - Sair");
      int opcaoEscolhida = int.Parse(Console.ReadLine());
      return opcaoEscolhida;
    }
  }
}