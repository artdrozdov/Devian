using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devian.Collections
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            Value = value;

        }
        public ListNode(T value, ListNode<T> prev, ListNode<T> next): this(value)
        {
            Next = next;
            Previous = prev;
            if(Next != null)
                Next.Previous = this;
            if(Previous != null)
                Previous.Next = this;
        }
        public T Value { get; set; }
        public ListNode<T> Next { get; set; }
        public ListNode<T> Previous { get; set; }
    }
}
