namespace DesafioFundamentos.Models
{
    public class Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        private decimal precoInicial = precoInicial;
        private decimal precoPorHora = precoPorHora;
        private List<string> veiculos = [];

        public void AdicionarVeiculo()
        {
            // *IMPLEMENTADO!*
            string placa;

            do
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                placa = Console.ReadLine().ToUpper();

                if (placa.ToCharArray().Length > 7)
                {
                    Console.WriteLine("O numero de digitos da placa excede o valor maximo.");
                    continue;
                }

                else if (char.IsDigit(placa.ToCharArray()[0]) || char.IsDigit(placa.ToCharArray()[1]) || char.IsDigit(placa.ToCharArray()[2]) || char.IsDigit(placa.ToCharArray()[4]) || char.IsLetter(placa.ToCharArray()[3]) || char.IsLetter(placa.ToCharArray()[5]) || char.IsLetter(placa.ToCharArray()[6]))
                {
                    Console.WriteLine("A Formatação da placa esta incorreta.");
                    continue;
                }

                else if (veiculos.Any(x => x.Equals(placa, StringComparison.CurrentCultureIgnoreCase)))
                {
                    Console.WriteLine("O Veiculo já esta estacionado.");
                    continue;
                }

                break;
            } while (true);

            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            // *IMPLEMENTADO!*
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.Equals(placa, StringComparison.CurrentCultureIgnoreCase)))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());

                decimal valorTotal = precoInicial + precoPorHora * horas;
                veiculos.Remove(placa);

                Console.WriteLine("_________________________________________________________");
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Count != 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                // // *IMPLEMENTADO!*
                foreach (var item in veiculos)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
