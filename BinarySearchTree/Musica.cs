// See https://aka.ms/new-console-template for more information
public class Musica : IComparableNode
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public string Genero { get; set; }

    public Musica(int id, string titulo, string artista, string genero)
    {
        Id = id;
        Titulo = titulo;
        Artista = artista;
        Genero = genero;
    }

    public override string ToString()
    {
        return Id.ToString();
    }

    public int CalcularSimilaridade(IComparableNode outra)
    {
        if (outra is not Musica outraMusica)
        {
            return 0;
        }

        int similaridade = 0;

        if (Genero.Equals(outraMusica.Genero, StringComparison.OrdinalIgnoreCase))
        {
            similaridade += 5; // Similaridade maior se o gênero for igual
        }

        if (Artista.Equals(outraMusica.Artista, StringComparison.OrdinalIgnoreCase))
        {
            similaridade += 3; // Similaridade se o artista for igual
        }

        return similaridade;
    }
}
