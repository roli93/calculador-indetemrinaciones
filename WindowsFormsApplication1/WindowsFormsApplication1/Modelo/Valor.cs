using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Modelo
{
    public class Valor
    {
        public double ValorRepresentativo { get; set; }
        public double ErrorAbsoluto { get; set; }

        public Valor() : base() { }

        public Valor(string expresion)
        {
            parseExpresion(expresion);
        }

        public double ErrorRelativo
        {
            get
            {
                return ErrorAbsoluto / ValorRepresentativo;
            }

            set
            {
                ErrorAbsoluto = ValorRepresentativo * value;
                //TODO Mejorar esto que queda dependiente del orden.
            }
        }


        //TODO abstraer bien cosas comunes acá
        private Valor operarAbsoluta(Valor otroValor, Func<double, double, double> mainOperation)
        {
            Valor valor =  new Valor();
            valor.ValorRepresentativo = mainOperation(this.ValorRepresentativo, otroValor.ValorRepresentativo);
            valor.ErrorAbsoluto = this.ErrorAbsoluto + otroValor.ErrorAbsoluto;
            return valor;
        }

        private Valor operarRelativa(Valor otroValor, Func<double, double, double> mainOperation)
        {
            Valor valor = new Valor();
            valor.ValorRepresentativo = mainOperation(this.ValorRepresentativo, otroValor.ValorRepresentativo);
            valor.ErrorRelativo = this.ErrorRelativo + otroValor.ErrorRelativo;
            return valor;
        }

        public Valor sumarle(Valor otroValor)
        {
            return operarAbsoluta(otroValor, (a, b) => { return a + b; });
        }

        public Valor restarle(Valor otroValor)
        {
            return operarAbsoluta(otroValor, (a, b) => { return a - b; });
        }

        public Valor multiplicarPor(Valor otroValor)
        {
            return operarRelativa(otroValor, (a, b) => { return a * b; });
        }

        public Valor dividirPor(Valor otroValor)
        {
            return operarRelativa(otroValor, (a, b) => { return a / b; });
        }

        private void parseExpresion(string expresion)
        {
            string[] split = new string[] {};

            expresion.Where<char>(c=>c.Equals('±')).Single<char>();

            split = expresion.Split("±".ToCharArray(), 2);

            ValorRepresentativo = Convert.ToDouble(split[0]);
            ErrorAbsoluto = Convert.ToDouble(split[1]);

        }

        public override string ToString()
        {
            return ValorRepresentativo.ToString() + " ± " + ErrorAbsoluto.ToString();
        }

    }
}
