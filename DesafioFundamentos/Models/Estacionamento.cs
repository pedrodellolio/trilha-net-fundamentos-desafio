using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal precoInicial = 0;
        private readonly decimal precoPorHora = 0;
        private readonly List<string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Já existe um veículo estacionado com essa placa.");
                return;
            }

            string isPlacaValida = @"^[A-Z]{3}-\d{4}$|^[A-Z]{3}\d[A-Z]\d{2}$";
            Regex regex = new(isPlacaValida);
            if (regex.IsMatch(placa))
            {
                veiculos.Add(placa);
            }
            else
            {
                Console.WriteLine("Informe uma placa no padrão brasileiro (ABC-0000) ou do Mercosul (ABC1D23).");
            }
        }

        public void RemoverVeiculo()
        {
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                // Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado
                int horas = LerValorInteiro("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                // Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // Remover a placa digitada da lista de veículos
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                Console.WriteLine("Os veículos estacionados são:");
                veiculos.ForEach(v =>
                {
                    Console.WriteLine(v);
                });
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private static int LerValorInteiro(string mensagem)
        {
            int valor = 0;
            bool isInteiroValido = false;

            while (!isInteiroValido)
            {
                Console.WriteLine(mensagem);
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out valor))
                {
                    isInteiroValido = true;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um valor inteiro válido.");
                }
            }

            return valor;
        }
    }
}
