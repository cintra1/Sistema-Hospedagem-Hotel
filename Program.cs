using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Seja bem vindo ao sistema de hospedagem!\n" +
                  "Digite a quantidade de dias que você quer ficar no Hotel:");

int diasReservados = Convert.ToInt32(Console.ReadLine());

// Instancia a classe Suite
Reserva res = new Reserva(diasReservados);

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar pessoa (Nome)");
    Console.WriteLine("2 - Adicionar Suite (Tipo Suite, Capacidade, Valor Diaria)");
    Console.WriteLine("3 - Criar reserva");
    Console.WriteLine("4 - Quantidade de Hospedes");
    Console.WriteLine("5 - Valor diária");
    Console.WriteLine("6 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            res.CadastrarHospedes(hospedes);
            break;

        case "2":
            res.CadastrarSuite();
            break;

        case "3":
            if (res.Hospedes != null && res.Hospedes.Count > 0 && res.Suite != null)
            {
                Console.WriteLine("Reserva criada com sucesso!");
                // Aqui você pode adicionar qualquer lógica adicional relacionada à criação da reserva
            }
            else
            {
                Console.WriteLine("Não é possível criar a reserva. Certifique-se de ter cadastrado pelo menos um hóspede e uma suíte.");
            }
            break;

        case "4":
            res.QuantidadeHospedes();
            break;

        case "5":
            res.ValorDiaria();
            break;

        case "6":
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
