using System.Threading.Tasks.Dataflow;

public class Task511
{
    public static void Main(string[] args)
    {
        var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
        var subtractBlock = new TransformBlock<int, int>(item => item - 2);
        // После связывания значения, выходящие из multiplyBlock,
        // будут входить в subtractBlock.
        multiplyBlock.LinkTo(subtractBlock);
        for (int i = 0; i < 10; i++)   
            multiplyBlock.Post(i);
        for (int i = 0; i < 10; i++)
            Console.WriteLine(subtractBlock.Receive());
    }
}