using System.Threading.Tasks.Dataflow;
public class Task522
{
    public static async Task Main(string[] args)
    {
        try
        {
            var block = new TransformBlock<int, int>(item =>
            {
                if (item == 1)
                    throw new InvalidOperationException("Blech.");
                return item * 2;
            });
            block.Post(1);
            await block.Completion;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            // Здесь перехватывается исключение.
        }
    }
}