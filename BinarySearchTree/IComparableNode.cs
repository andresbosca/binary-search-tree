// See https://aka.ms/new-console-template for more information
public interface IComparableNode
{
    public int Id { get; }
    public int CalcularSimilaridade(IComparableNode outra);
}
