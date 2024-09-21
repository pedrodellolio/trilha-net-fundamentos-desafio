using DesafioFundamentos.Models;

static decimal LerValorDecimal(string mensagem)
{
    decimal valor = 0;
    bool isDecimalValido = false;

    while (!isDecimalValido)
    {
        Console.WriteLine(mensagem);
        string input = Console.ReadLine();

        if (decimal.TryParse(input, out valor))
        {
            isDecimalValido = true;
        }
        else
        {
            Console.WriteLine("Por favor, insira um valor decimal válido.");
        }
    }

    return valor;
}

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");
decimal precoInicial = LerValorDecimal("Digite o preço inicial:");
decimal precoPorHora = LerValorDecimal("Agora digite o preço por hora:");

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new(precoInicial, precoPorHora);

bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
