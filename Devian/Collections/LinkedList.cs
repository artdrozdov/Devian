using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Devian.Collections
{
    public class LinkedList<T> : IEnumerable<T>, ICollection<T>
    {
        private ListNode<T> Head { get; set; }
        private ListNode<T> Tail { get; set; }
        private int _count;
        
        public LinkedList()
        {
            
        }

        public void Add(T item)
        {
            if (Head == null) {
                Head = new ListNode<T>(item);
                Tail = Head;
            }
            else
            {
                Tail = new ListNode<T>(item, Tail, null);
            }
            _count++;
        }

        public void Clear()
        {
            Head = null;
            _count = 0;
        }

        public bool Contains(T item)
        {            
                var e = GetEnumerator();
                do
                {
                    if (e.Current.Equals(item))
                    {
                        return true;
                    }
                }
                while (e.MoveNext());
                return false;   
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            bool isHead = Head.Value.Equals(item);
            bool isTail = Tail.Value.Equals(item);
            if ( isHead || isTail)
            {
                if (_count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    if (isHead)
                    {
                        Head = Head.Next;
                        Head.Previous = null;
                    }
                    else
                    {
                        Tail = Tail.Previous;
                        Tail.Next = null;
                    }                    
                }
                _count--;
                return true;
            }
            else
            {
                var node = Find(item);
                if (node != null)
                {
                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;
                    _count--;
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(Head);
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new LinkedListEnumerator<T>(Head);
        }

        private ListNode<T> Find(T item)
        {
            if (Head.Value.Equals(item))
            {
                return Head;
            }
            if (Tail.Value.Equals(item))
            {
                return Tail;
            }
            var tmp = Head;
            while (tmp.Next != null && tmp.Next != Tail)
            {
                tmp = tmp.Next;
                if (item.Equals(tmp.Value))
                {
                    return tmp;
                }
            }
            return null;
        }
    }
}
