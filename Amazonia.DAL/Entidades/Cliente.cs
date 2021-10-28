using System;
using System.Linq;

namespace Amazonia.DAL.Entidades
{
    public class Cliente : Entidade
    {
        public Morada Morada { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroContribuinte { get; set; }
        public int Idade => DateTime.Now.Year - DataNascimento.Year;

        public string NumeroIdentificacaoFiscal { get; set; }

        public bool NifEstaValido()
        {
            if(this.NumeroIdentificacaoFiscal.Length!=9)
                return false;

            if (NumeroIdentificacaoFiscal.ToCharArray().Distinct().ToList().Count == 1)
                return false;

            var produtoSomatorio = 0;
            var fatorMultiplicacao= 2;
            for (int i = NumeroIdentificacaoFiscal.Length - 2; i >= 0; i--)
            {
                var elemento = (int)Char.GetNumericValue(NumeroIdentificacaoFiscal[i]);
                var produto = elemento * fatorMultiplicacao;
                produtoSomatorio += produto;
                fatorMultiplicacao++;
                

            }
            var restoDivisaoPor11 = produtoSomatorio % 11;
            if ((restoDivisaoPor11==0||restoDivisaoPor11==1)&& (int)Char.GetNumericValue(NumeroIdentificacaoFiscal[8]) == 0)
            {
                return true;
            }
            else 
            {
                int ultimo= (int)Char.GetNumericValue(NumeroIdentificacaoFiscal[8]);
                return ((11 - restoDivisaoPor11) == (ultimo));
            }
            

            
        }



        public override string ToString()
        {
            return $"Nome: {Nome} => Idade: {Idade} => Identificador: {Identificador}";
        }

    }
}