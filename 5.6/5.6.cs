using System.Threading.Tasks.Dataflow;
public class Task56
{
    static IPropagatorBlock<int, int> CreateMyCustomBlock()
    {
        var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
        var addBlock = new TransformBlock<int, int>(item => item + 2);
        var divideBlock = new TransformBlock<int, int>(item => item / 2);
        var flowCompletion = new DataflowLinkOptions { PropagateCompletion = true };
        multiplyBlock.LinkTo(addBlock, flowCompletion);
        addBlock.LinkTo(divideBlock, flowCompletion);
        return DataflowBlock.Encapsulate(multiplyBlock, divideBlock);
    }
    public static void Main(string[] args)
    {
        var block = CreateMyCustomBlock();
        for (int i = 0; i < 10; i++)
            block.Post(i);
        for (int i = 0; i < 10; i++)
            Console.WriteLine(block.Receive());
    }
}
