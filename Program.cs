
string mensagemDeBoasVindas = "Boas Vindas ao Screen Sound";

//List<string> bandsList = new List<string> {"Guns N Roses", "Limp Bizkt", "Metallica" };    

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 5, 8, 7 });
bandasRegistradas.Add("Beatles", new List<int>());


void ExibirMensagem()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesMenu()
{
    ExibirMensagem();
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para ver a avaliação de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opcão: ");
    string opcaoEscolhida = Console.ReadLine();

    if (String.IsNullOrEmpty(opcaoEscolhida))
    {
        Console.WriteLine("Você não digitou nada!");

    }

    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            registrarBanda();
            break;
        case 2:
            exibirBandas();
            break;
        case 3:
            avaliarBanda();
            break;
        case 4:
            exibirMedia();
            break;
        case -1:
            Console.WriteLine("Tchau Tchau ;)");
            break;
        default:
            Console.WriteLine("Opcao invalida");
            break;

    }
}
void registrarBanda()
{
    Console.Clear();
    exibirTituloDaOpcao("Registro de bandas");
    Console.WriteLine("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine();
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesMenu();
}

void exibirBandas()
{
    Console.Clear();
    exibirTituloDaOpcao("Exibindo Todas as bandas registradas");
    //for (int i = 0; i < bandsList.Count; i++)
    //{
    //Console.WriteLine($"Banda: {bandsList[i]}");
    //}
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar ao menu: ");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesMenu();
}
void exibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void avaliarBanda()
{
    Console.Clear();
    exibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite a banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine();
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"Avalie a banda: {nomeDaBanda}");
        int avaliacao = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(avaliacao);
        Console.WriteLine($"\nA avaliação (nota: {avaliacao} ) foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesMenu();


    }
    else
    {
        Console.WriteLine($"\nO nome da banda {nomeDaBanda} não foi encontrado");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }

}

void exibirMedia()
{
    Console.Clear();
    exibirTituloDaOpcao("Media das Bandas");
    Console.WriteLine("Deseja ver a média de avaliações de qual banda: ");
    string nomeDaBanda = Console.ReadLine();
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        if (notasDaBanda.Any())
        {
            Console.WriteLine($"A média da banda {nomeDaBanda} é {notasDaBanda.Average()}");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesMenu();
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não possui avaliações, se deseja avaliar digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesMenu();

        }
    }
    else
    {
        Console.WriteLine($"\nO nome da banda {nomeDaBanda} não foi encontrado");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }

}


ExibirOpcoesMenu();



