using System.Threading.Tasks.Dataflow;
public class Task523
{
    public static async Task Main(string[] args)
    {
        try
        {
            var multiplyBlock = new TransformBlock<int, int>(item =>
            {
                if (item == 1)
                    throw new InvalidOperationException("Blech.");
                return item * 2;
            });
            var subtractBlock = new TransformBlock<int, int>(item => item - 2);
            multiplyBlock.LinkTo(subtractBlock,
            new DataflowLinkOptions { PropagateCompletion = true });
            multiplyBlock.Post(1);
            await subtractBlock.Completion;
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.Message);
            // Здесь перехватывается исключение.
        }
    }
}