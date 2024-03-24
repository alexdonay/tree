using tree;

internal class Program
{
    private static void Main(string[] args)
    {
        Tree<int> tree = new Tree<int>();

        tree.AppenManyNodo(2,4,6,8,1,3,5);
        Console.WriteLine(tree.PreOrderTraversal());
        tree.DeleteNodoByValue(3);
        Console.WriteLine(tree.InOrderTransversal());
        Console.WriteLine(tree.PostOrderTraversal());
        Console.WriteLine(tree.Weight());
        Console.WriteLine(tree.GetNivel(1));
    }
}