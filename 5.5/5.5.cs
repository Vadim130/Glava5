using System.Threading.Tasks.Dataflow;
public class Task55
{
    public static void Main(string[] args)
    {
        var multiplyBlock = new TransformBlock<int, int>(
            item => item * 2,
            new ExecutionDataflowBlockOptions
            {
                 MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded
            });
        var subtractBlock = new TransformBlock<int, int>(item => item - 2);
        multiplyBlock.LinkTo(subtractBlock);
        for (int i = 0; i < 10; i++)
            multiplyBlock.Post(i);
        for (int i = 0; i < 10; i++)
            Console.WriteLine(subtractBlock.Receive());
    }
}