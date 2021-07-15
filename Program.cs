using System;

namespace fabio.series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaousuario = ObterOpcaoUsuario();
           while (opcaousuario.ToUpper() != "X")
           {
               switch (opcaousuario)
               {
                    case "1":
                        listaseries();
                        break;
                    case "2":
                        inserirserie();
                        break;
                    case "3":
                        atualizarserie();
                        break;
                    case "4":
                        excluirserie();
                        break;
                    case "5":
                        visualizarserie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();            
               }
               opcaousuario = ObterOpcaoUsuario();
           }
            Console.WriteLine(" Obrigado por Utilizar Nossos Serviços!");
            Console.WriteLine(" Volte Sempre!");
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void excluirserie()
		{
			Console.Write(" Digite o id da Série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void visualizarserie()
		{
			Console.Write(" Digite o id da Série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void atualizarserie()
		{
			Console.Write(" Digite o id da Série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
			Console.Write(" Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();

			Console.Write(" Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();
            Console.WriteLine();

			Console.Write(" Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();

			Console.Write(" Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();
            Console.WriteLine();

			serie atualizaSerie = new serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
            Console.WriteLine();
		}

        private static void listaseries()
        {
            Console.WriteLine(" Listar Series");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine(" Nenhuma Serie Cadastrada!");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void inserirserie()
		{
			Console.WriteLine("  Inserir nova série:");
            Console.WriteLine();

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
            Console.WriteLine();
			Console.Write(" Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();

			Console.Write(" Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();
            Console.WriteLine();

			Console.Write(" Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();

			Console.Write(" Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();
            Console.WriteLine();

			serie novaSerie = new serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" - FABIO SERIES A SEU DISPOR! - ");
            Console.WriteLine(" - - - - - - - - - - - - - - - -");
            Console.WriteLine();
            Console.WriteLine(" Informe a Opção Desejada: ");
            Console.WriteLine(" 1 - Listar Séries");
            Console.WriteLine(" 2 - Inserir Nova Séries");
            Console.WriteLine(" 3 - Atualizar Séries");
            Console.WriteLine(" 4 - Excluir Séries");
            Console.WriteLine(" 5 - Visualizar Séries");
            Console.WriteLine(" C - Limpar Tela");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaousuario;
        }
    }
}
