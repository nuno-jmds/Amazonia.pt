namespace Amazonia.DAL.Entidades
{

    class AudioLivro : Livro
    {
        public string FormatoFicheiro { get; set; }

        public int DuracaoLivro { get; set; }
    }
}