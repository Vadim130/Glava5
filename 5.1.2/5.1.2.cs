using System.Threading.Tasks.Dataflow;

public class Task512
{
 
    public static async Task Main(string[] args)
    {
        var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
        var subtractBlock = new TransformBlock<int, int>(item => item - 2);
        var options = new DataflowLinkOptions { PropagateCompletion = true };
        multiplyBlock.LinkTo(subtractBlock, options);
        Task<int> [] tasks = new Task<int>  [10];
        for (int i = 0; i < 10; i++)
            multiplyBlock.Post(i);

        for (int i = 0; i < 10; i++)
            tasks[i] = subtractBlock.ReceiveAsync();
        // Завершение первого блока автоматически распространяется во второй блок.
        multiplyBlock.Complete();
        await subtractBlock.Completion;

        for (int i = 0; i < 10; i++)
            Console.WriteLine(await tasks[i]);
    }
}