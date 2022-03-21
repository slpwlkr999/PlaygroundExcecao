using System;

namespace PlaygroundExcecao
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Conta conta = new Conta(1, 2);                
                conta.Sacar(500);
                Console.WriteLine(conta.Saldo);
                Console.WriteLine();
                
                Console.WriteLine(conta.Saldo);
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "numero")
                {
                    Console.WriteLine("ex.Message");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Console.WriteLine("ex.StackTrace");
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine();                    
                    Console.WriteLine("Exceção Capturada dentro do Main. | ex.ParamName == numero");
                }

                if (ex.ParamName == "agencia")
                {
                    Console.WriteLine("ex.Message");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Console.WriteLine("ex.StackTrace");
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine();
                    Console.WriteLine("Exceção Capturada dentro do Main. | ex.ParamName == agencia");
                }
            }

            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine("ex.Message");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine("ex.StackTrace");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                Console.WriteLine("Exceção Capturada dentro do Main. | SaldoInsuficienteException");
                //throw new Exception("Teste", ex);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Exceção Capturada dentro do Main. | Exception");
            }

            Console.WriteLine();
            Console.WriteLine("Fim da Execução.");
            Console.ReadLine();

        }
    }
}
