using System.Globalization;

namespace Questao1
{
    class ContaBancaria
    {
        //numero, titular, depositoInicial
        public int Numero { get; set; }
        public string Titular { get; set; }
        public double DepositoInicial { get; set; }

        private double taxaSaque = 3.50;


        public ContaBancaria(int numero, string titular, double depositoInicial = 0)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.DepositoInicial = depositoInicial;
        }

        public void Saque(double quantia)
        {
            this.DepositoInicial -= (quantia + taxaSaque);
        }

        public void Deposito(double quantia)
        {
            this.DepositoInicial += quantia;
        }
    }
}
