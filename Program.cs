using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<ContaBancaria> contas = new HashSet<ContaBancaria>();

        // Criar algumas contas para teste
        ContaBancaria conta1 = new ContaBancaria("Carol", 1500.0);
        ContaBancaria conta2 = new ContaBancaria("Amigo", 2000.0);

        // Adicionar contas ao HashSet
        contas.Add(conta1);
        contas.Add(conta2);

        // Realizar operações
        conta1.Depositar(500.0);
        conta2.Sacar(300.0);

        // Exibir informações de todas as contas
        ExibirContas(contas);
    }

    static void ExibirContas(HashSet<ContaBancaria> contas)
    {
        foreach (ContaBancaria conta in contas)
        {
            Console.WriteLine(conta);
        }
    }
}

class ContaBancaria
{
    private static int proximoNumero = 1000;

    public int Numero { get; }
    public string Titular { get; }
    public double Saldo { get; private set; }

    public ContaBancaria(string titular, double saldo)
    {
        this.Numero = GerarNumeroConta();
        this.Titular = titular;
        this.Saldo = saldo;
    }

    private int GerarNumeroConta()
    {
        return proximoNumero++;
    }

    public void Depositar(double valor)
    {
        Saldo += valor;
        Console.WriteLine($"Depósito realizado com sucesso. Novo saldo: {Saldo}");
    }

    public void Sacar(double valor)
    {
        if (valor <= Saldo)
        {
            Saldo -= valor;
            Console.WriteLine($"Saque realizado com sucesso. Novo saldo: {Saldo}");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente para saque.");
        }
    }

    public override string ToString()
    {
        return $"ContaBancaria{{numero={Numero}, titular='{Titular}', saldo={Saldo}}}";
    }
}
