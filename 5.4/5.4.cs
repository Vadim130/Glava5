using System.Threading.Tasks.Dataflow;

public class Task54
{
    public static void Main(string[] args)
    {
        var sourceBlock = new BufferBlock<int>();
        var options = new DataflowBlockOptions { BoundedCapacity = 1 };
        var targetBlockA = new BufferBlock<int>(options);
        var targetBlockB = new BufferBlock<int>(options);
        sourceBlock.LinkTo(targetBlockA);
        sourceBlock.LinkTo(targetBlockB);

    }   
}