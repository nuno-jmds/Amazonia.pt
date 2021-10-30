namespace Amazonia.DAL.Infraestrutura
{
    public class ImpressoraPdf : IImpressora
    {
        public void Imprimir()
        {
            System.Console.WriteLine("Usando Impressora PDF");
        }
    }
}