public class Dimensoes
{
    ///Dimensões em centimetros
    public float Largura { get; set; }

    public float Altura { get; set; }

    public float Profundidade { get; set; }
    ///Peso em gramas
    public float Peso { get; set; }

    public float Volume => Largura * Altura * Profundidade;

    public float ObterVolume()
    {
        return Largura * Altura * Profundidade;
    }
}
