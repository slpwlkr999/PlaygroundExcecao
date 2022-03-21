using System;

namespace PlaygroundExcecao
{
    public class SaldoInsuficienteException : Exception
    {
        public double Saldo { get; }
        public double ValorSaldo { get; }

        public SaldoInsuficienteException()
        {

        }

        public SaldoInsuficienteException(string mensagem)
            : base(mensagem)
        {

        }

        public SaldoInsuficienteException(double saldo, double valorSaldo)
            : this("Impossível excecutar o saque de: " + saldo + ". O valor existente é de: " + valorSaldo)
        {
            Saldo = saldo;
            ValorSaldo = valorSaldo;
        }

    }
}
