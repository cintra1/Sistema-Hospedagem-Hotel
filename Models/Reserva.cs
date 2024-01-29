namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            Hospedes = new List<Pessoa>();
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
            {
                Console.WriteLine("É necessário cadastrar uma suíte antes de adicionar hóspedes.");
                return;
            }

            Console.WriteLine("Digite o nome do Hospede:");
            string nome = "";
            nome = Console.ReadLine();

            Pessoa novoHospede = new Pessoa(nome);

            if (Suite.Capacidade > Hospedes.Count)
            {
                Hospedes.Add(novoHospede);
                Console.WriteLine($"Hóspede {nome} cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("A capacidade é menor que o número de hóspedes recebido, mude de Suite.");
            }
        }

        public void CadastrarSuite()
        {
            Console.WriteLine("Digite Tipo Suite, Capacidade, Valor Diaria (Com um espaço cada um):");
            string entrada = Console.ReadLine();
            string[] valores = entrada.Split(' ');

            if (valores.Length == 3)
            {
                string tipo = valores[0];

                if (int.TryParse(valores[1], out int capac) &&
                    decimal.TryParse(valores[2], out decimal diaria))
                {
                    Suite = new Suite(tipo, capac, diaria);
                }
                else
                {
                    Console.WriteLine("Erro ao converter valores para inteiros.");
                }
            }
            else
            {
                Console.WriteLine("Forneça exatamente três valores separados por espaços.");
            }
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count();
        }

        public void QuantidadeHospedes()
        {
            int quant = ObterQuantidadeHospedes();
            Console.WriteLine($"Quantidade de hospedes: {quant}");
            for(int i = 0; i < Hospedes.Count(); i++){
                Console.WriteLine($" N° {i + 1}: {Hospedes[i].Nome}");
            }
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = (DiasReservados * Suite.ValorDiaria);

            if (DiasReservados >= 10)
            {
                valor = valor * 0.9M;
            }

            return valor;
        }
        public void ValorDiaria()
        {
            decimal valor = CalcularValorDiaria();
            Console.WriteLine($"Preço diária: {valor}");
        }
    }
}