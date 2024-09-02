BinarySearchTree<Musica> bst = new();

// Insere algumas músicas na árvore
bst.Insert(new Musica(10, "Song A", "Artist X", "Pop"));
bst.Insert(new Musica(5, "Song B", "Artist Y", "Rock"));
bst.Insert(new Musica(15, "Song C", "Artist X", "Pop"));
bst.Insert(new Musica(3, "Song D", "Artist Z", "Jazz"));
bst.Insert(new Musica(7, "Song E", "Artist X", "Rock"));

// Exibe a árvore
Console.WriteLine("Árvore Binária de Busca de Músicas:");

// bst.Display();

bst.Print();

// Busca músicas similares a uma música de input
Musica musicaInput = new Musica(0, "Input Song", "Artist X", "Pop");
List<Musica> similares = bst.SearchSimilar(musicaInput, 10);

Console.WriteLine("\nMúsicas Similares Encontradas:");
foreach (Musica musica in similares)
{
    Console.WriteLine(musica);
}
