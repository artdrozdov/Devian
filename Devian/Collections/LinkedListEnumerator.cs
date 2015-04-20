﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Devian.Collections
{
    class LinkedListEnumerator<T>: IEnumerator<T>
    {
        private ListNode<T> CurrentNode { get; set; }
        public LinkedListEnumerator(ListNode<T> node)
        {
            CurrentNode = node;
            Current = CurrentNode.Value;
        }

        public T Current { get; private set; }

        public void Dispose()
        {
            
        }

        object IEnumerator.Current
        {
            get { return new LinkedListEnumerator<T>(CurrentNode); }
        }

        public bool MoveNext()
        {
            if (CurrentNode.Next != null)
            {
                CurrentNode = CurrentNode.Next;
                Current = CurrentNode.Value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            while (CurrentNode.Previous != null)
            {
                CurrentNode = CurrentNode.Previous;
            }
        }
    }
}