using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class program
    {

        static List<Conta> listContas = new List<Conta>();
    static void Main(string[] args)
        {
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						//Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}
			
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

	private static void Transferir()
	{
		Console.WriteLine("Digite o numero da conta de origem: ");
		int indeceContaOrigem = int.Parse(Console.ReadLine());

		Console.WriteLine("Digite o numero da conta de destino: ");
		int indeceContaDestino = int.Parse(Console.ReadLine());

		Console.WriteLine("Digite o valor da transferencia: ");
		double valorTransferencia = double.Parse(Console.ReadLine());

		listContas[indeceContaOrigem].Transferir(valorTransferencia, listContas[indeceContaDestino]);
	}


	private static void Depositar()
	{
		Console.WriteLine("Digite o numero da conta: ");
		int indeceConta = int.Parse(Console.ReadLine());

		Console.WriteLine("Digite o numero da conta: ");
		double valorDeposito = double.Parse(Console.ReadLine());

		listContas[indeceConta].Sacar(valorDeposito);
	}


	private static void Sacar()
	{
		Console.WriteLine("Digite o numero da conta: ");
		int indeceConta = int.Parse(Console.ReadLine());

		Console.WriteLine("Digite o numero da conta: ");
		double valorSaque = double.Parse(Console.ReadLine());

		listContas[indeceConta].Sacar(valorSaque);

	}


    private static void InserirConta()
        {
			Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome);

			listContas.Add(novaConta);
		}
		
    private static void ListarContas()
		{
			Console.WriteLine("Listar contas");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}






    private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}





    }
}
