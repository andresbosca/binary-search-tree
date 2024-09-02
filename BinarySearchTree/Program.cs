BinarySearchTree<Musica> bst = new();

// Insere algumas músicas na árvore
bst.Insert(new Musica(20, "Song A", "Artist X", "Pop"));
bst.Insert(new Musica(5, "Song B", "Artist Y", "Rock"));
bst.Insert(new Musica(15, "Song C", "Artist X", "Pop"));
bst.Insert(new Musica(3, "Song D", "Artist Z", "Jazz"));
bst.Insert(new Musica(7, "Song E", "Artist X", "Rock"));
bst.Insert(new Musica(12, "Song F", "Artist Y", "Pop"));
bst.Insert(new Musica(17, "Song G", "Artist Z", "Jazz"));
bst.Insert(new Musica(1, "Song H", "Artist X", "Pop"));
bst.Insert(new Musica(4, "Song I", "Artist Y", "Rock"));
bst.Insert(new Musica(6, "Song J", "Artist X", "Pop"));
bst.Insert(new Musica(8, "Song K", "Artist Z", "Jazz"));
bst.Insert(new Musica(11, "Song L", "Artist X", "Rock"));
bst.Insert(new Musica(13, "Song M", "Artist Y", "Pop"));

// Exibe a árvore
Console.WriteLine("Árvore Binária de Busca de Músicas:");
bst.Print();

// Busca músicas similares a uma música de input
Musica musicaInput = new Musica(0, "Input Song", "Artist X", "Pop");
List<Musica> similares = bst.SearchSimilar(musicaInput, 10);

Console.WriteLine("\nMúsicas Similares Encontradas:");
foreach (Musica musica in similares)
{
    Console.WriteLine(musica);
}

Console.WriteLine("\nTravessia in-order:");
bst.InOrder();

Console.WriteLine("\nTravessia pre-order:");
bst.PreOrder();

Console.WriteLine("\nTravessia post-order:");
bst.PostOrder();

bst.Remove(1);
bst.Print();
bst.Remove(8);
bst.Print();
bst.Remove(12);
bst.Print();
