using System.Collections.Generic;

namespace Hackerrank
{
    public static class CircularLinkedList
    {
        public static LinkedListNode<int> NextOrFirst(this LinkedListNode<int> current)
        {
            if (current.Next == null)
                return current.List.First;
            return current.Next;
        }

        public static LinkedListNode<int> PreviousOrLast(this LinkedListNode<int> current)
        {
            if (current.Previous == null)
                return current.List.Last;
            return current.Previous;
        }
    }
}