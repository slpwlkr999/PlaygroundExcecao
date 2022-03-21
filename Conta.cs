using System;

namespace PlaygroundExcecao
{
    public class Conta
    {
        public static int ContaCriada { get; private set; }
        public static int TentativasDeSaque { get; private set; }
        public static int TentativasDeTransferencia { get; private set; }

        public Cliente titular { get; set; }
        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
        }
        public int Numero { get; private set; }
        public int Agencia { get; private set; }

        public Conta(int numero, int agencia)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("Erro de Argumento. | Conta.cs", nameof(numero));
            }

            if (agencia <= 0)
            {
                throw new ArgumentException("Erro de Argumento. | Conta.cs.", nameof(agencia));
            }

            Numero = numero;
            Agencia = agencia;
            ContaCriada++;
            Console.WriteLine("Número: " + numero);
            Console.WriteLine("Agência: " + agencia);
            Console.WriteLine("Número de Contas Criadas até agora: " + ContaCriada);
        }

        public void Sacar(double valor)
        {
            try
            {
                if (valor > Saldo)
                {
                    throw new SaldoInsuficienteException(valor, Saldo);
                }

                if (valor <= 0)
                {
                    throw new SaldoInsuficienteException(valor, Saldo);
                }

                _saldo -= valor;
            }
            catch (SaldoInsuficienteException ex)
            {
                TentativasDeSaque++;
                throw new Exception("Operação não realizada. Tipo: Saque.", ex);
            }

        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir (double valor, Conta destino)
        {
            if(valor < 0)
            {
                throw new SaldoInsuficienteException();
            }            

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                TentativasDeTransferencia++;
                throw new Exception("Operação não realizada. Tipo: Transferência", ex);
            }

            destino.Depositar(valor);
        }
    }
}
