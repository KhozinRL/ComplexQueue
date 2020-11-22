using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace MyQueue
{
    public class Queue<T>: IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> last;

        private class Node<T>
        {
            public Node<T> Next { get; set; }
            public T Value { get; set; }
        }

        public void Enqueue(T element)
        {
            if (element == null) return;

            Node<T> node = new Node<T> { Value = element };
            if (head == null)
            {
                head = node;
            }
            else {
                last.Next = node;
            }
            
            last = node;
        }

        public T Dequeue(){
            Node<T> result;
            if (head != null)
            {
                result = head;
                head = head.Next;
                return result.Value;
            }
            else {
                throw new Exception("Очередь пуста!");
            }
        }

        public T Peek() {
            if (head != null)
            {
                return head.Value;
            }
            else {
                throw new Exception("Очередь пуста!");
            }
        }

        public int Count() {
            Node<T> cursor = head;
            int count = 0;
            while (cursor != null) {
                ++count;
                cursor = cursor.Next;
            }
            return count;
        }

        public void Print() {
            Node<T> cursor = head;
            StringBuilder sb = new StringBuilder("Очередь: ");

            while (cursor != null) {
                sb.AppendFormat("{0}, ", cursor.Value);
                cursor = cursor.Next;
                if (cursor == null) {
                    sb.Remove(sb.Length - 2, 2);
                    sb.Append(".");
                }
            }

            Console.WriteLine(sb.ToString());
        }

        private class QueueEnumerator : IEnumerator<T>
        {
            Queue<T> _queue;
            Node<T> currentNode;
            T current;

            public QueueEnumerator(Queue<T> queue) { 
                _queue = queue;
            }

            public T Current {
                get {
                    return current;
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                if (currentNode is null)
                {
                    currentNode = _queue.head;
                }
                else if (currentNode.Next is not null)
                {
                    currentNode = currentNode.Next;
                }
                else {
                    return false;
                }

                current = currentNode.Value;
                return true;
            }

            public void Reset()
            {
                currentNode = null;
                current = default(T);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}