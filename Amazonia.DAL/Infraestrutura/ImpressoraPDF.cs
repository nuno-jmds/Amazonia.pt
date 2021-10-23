namespace Amazonia.DAL.Infraestrutura
{
    public class ImpressoraPDF : IImpressora
    {
        public void Imprimir()
        {
            System.Console.WriteLine("Usando Impressora PDF");
        }
    }
}