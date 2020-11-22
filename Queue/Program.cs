using System;
using ComplexNumber;

namespace MyQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Complex> queue = new Queue<Complex>();
            queue.Enqueue(new Complex(10, 12));
            queue.Enqueue(new Complex(4, 5));
            queue.Enqueue(new Complex(0, 5));
            queue.Enqueue(new Complex(4, 0));

            Console.WriteLine();
            queue.Print();
            Console.WriteLine("Длина очереди: {0}", queue.Count());

            foreach (Complex _ in queue) {
                Console.WriteLine();
                Console.WriteLine("Вытащили элемент: {0}", queue.Dequeue());
                queue.Print();
                Console.WriteLine("Длина очереди: {0}", queue.Count());
            }

            queue.Enqueue(new Complex(43, 23));
            queue.Enqueue(new Complex(4, 3));

            foreach (Complex _ in queue)
            {
                Console.WriteLine();
                Console.WriteLine("Посмотрели элемент: {0}", queue.Peek());
                queue.Print();
                Console.WriteLine("Длина очереди: {0}", queue.Count());
            }

        }
    }
}
