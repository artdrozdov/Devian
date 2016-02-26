using System;
using System.Collections.Generic;
using System.Collections;

namespace Devian.Collections
{
    public class LinkedList<T> : ICollection<T>
    {
        private ListNode<T> _head;
        private ListNode<T> _tail;
        private int _count;

        public void Add(T item)
        {
            var node = new ListNode<T>(item);
            if (_head == null)
            {
                _head = _tail = node;
            }
            else
            {
                node.Previous = _tail;
                _tail = _tail.Next = node;
            }
            _count++;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public bool Contains(T item)
        {            
            var tmp = _head;
            while (tmp != null)
            {
                if (tmp.Value.Equals(item))
                    return true;
                tmp = tmp.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count => _count;

        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(new ListNode<T>(default(T)) { Next = _head});
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LinkedListEnumerator<T>(new ListNode<T>(default(T)) { Next = _head });
        }

        public bool Remove(T item)
        {
            var tmp = _head;
            while (tmp != null)
            {
                if (item.Equals(tmp.Value))
                {
                    if (tmp.Previous != null)
                        tmp.Previous.Next = tmp.Next;
                    else
                        _head = tmp.Next;

                    if (tmp.Next != null)
                        tmp.Next.Previous = tmp.Previous;
                    else
                        _tail = tmp.Previous;

                    _count--;
                    return true;
                }
                tmp = tmp.Next;
            }
            return false;
        }

        public T this[int i]
        {
            get
            {
                int currentIndex = 0;
                var tmp = _head;
                while (tmp != null)
                {
                    if (i == currentIndex++)
                        return tmp.Value;
                    tmp = tmp.Next;
                }
                throw new IndexOutOfRangeException();
            }

            set
            {
                int currentIndex = 0;
                var tmp = _head;
                while (tmp != null)
                {
                    if (i == currentIndex++)
                        tmp.Value = value;
                    tmp = tmp.Next;
                }
                throw new IndexOutOfRangeException();
            }
        }
    }
}
