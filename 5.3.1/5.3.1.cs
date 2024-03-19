using System.Threading.Tasks.Dataflow;
public class Task523
{
    public static void Main(string[] args)
    {
        var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
        var subtractBlock = new TransformBlock<int, int>(item => item - 2);
        IDisposable link = multiplyBlock.LinkTo(subtractBlock);
        multiplyBlock.Post(1);
        multiplyBlock.Post(2);
        // Удаление связей между блоками.
        // Данные, отправленные выше, могут быть уже переданы
        // или не переданы по связи. В реальном коде стоит рассмотреть
        // возможность блока using вместо простого вызова Dispose.
        link.Dispose();
            

    }  
}