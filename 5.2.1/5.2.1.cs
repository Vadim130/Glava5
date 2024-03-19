using System.Threading.Tasks.Dataflow;
public class Task521
{
    public static void Main(string[] args)
    {

        var block = new TransformBlock<int, int>(item =>
        {
            if (item == 1)
                throw new InvalidOperationException("Blech.");
            return item * 2;
        });
        block.Post(1);
        block.Post(2);
    }
 }       