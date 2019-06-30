using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SetNameSpace
{
    /// <summary>
    /// Class for functionality of the set.
    /// </summary>
    /// <typeparam name="T">Variavle for type.</typeparam>
    public class Set<T> : ISet<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Data { get; set; }

            public Node RightChild { get; set; }

            public Node LeftChild { get; set; }

            public Node(T data)
            {
                Data = data;
            }
        }

        /// <summary>
        /// Top of the binary tree.
        /// </summary>
        private Node head;

        /// <summary>
        /// Property for the count of elements in set.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Property to know if user can change set or can not.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Method to make an union with other set.
        /// </summary>
        /// <param name="other">Other set.</param>
        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other set was empty!");
            }

            foreach (var item in other)
            {
                if (!Contains(item))
                {
                    AddResult(head, item);
                }
            }
        }

        /// <summary>
        /// Method to make an intersection with other set.
        /// </summary>
        /// <param name="other">Other set.</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other set was empty!");
            }

            foreach (var item in this)
            {
                if (!other.Contains(item))
                {
                    Remove(item);
                }
            }
        }
        
        /// <summary>
        /// Method to make an exception with other set.
        /// </summary>
        /// <param name="other">Other set.</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other sey was empty!");
            }

            foreach (var item in other)
            {
                if (Contains(item))
                {
                    Remove(item);
                }
            }
        }

        /// <summary>
        /// Method to make symmetric exception with other set.
        /// </summary>
        /// <param name="other">Other set.</param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other set was empty!");
            }

            foreach (var item in other)
            {
                if (Contains(item))
                {
                    Remove(item);
                }
                else
                {
                    AddResult(head, item);
                }
            }
        }

        /// <summary>
        /// Method to know if current set is subset of other set.
        /// </summary>
        /// <param name="other">Other set.</param>
        /// <returns>Bool result.</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other set was empty!");
            }

            return SetIsSubsetOfAnotherSet(this, other);
        }

        /// <summary>
        /// Method to know if current ser is superset of other set.
        /// </summary>
        /// <param name="other">Other set.</param>
        /// <returns>Bool result.</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other set was empty!");
            }

            return SetIsSubsetOfAnotherSet(other, this);
        }

        /// <summary>
        /// Method to know if current set is proper superset of other set.
        /// </summary>
        /// <param name="other">Other set.</param>
        /// <returns>Bool result.</returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other set was empty!");
            }

            return SetIsProperSubsetOfAnotherSet(other, this);
        }

        /// <summary>
        /// Method to know if current set is proper subset of other set.
        /// </summary>
        /// <param name="other">Other set.</param>
        /// <returns>Bool result.</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other set was empty!");
            }

            return SetIsProperSubsetOfAnotherSet(this, other);
        }

        /// <summary>
        /// Method to know if this set and other set have one common item at least. 
        /// </summary>
        /// <param name="other">Other set.</param>
        /// <returns>Bool result.</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other set was empty!");
            }

            foreach (var item in this)
            {
                if (other.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method to know if sets are equal.
        /// </summary>
        /// <param name="other">Other set.</param>
        /// <returns>Bool result.</returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other set was empty!");
            }

            foreach (var item in this)
            {
                if (!other.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Private method which is used in IsSubsetOf method.
        /// </summary>
        /// <param name="set">This set.</param>
        /// <param name="otherSet">Other set</param>
        /// <returns>Bool result.</returns>
        private bool SetIsSubsetOfAnotherSet(IEnumerable<T> set, IEnumerable<T> otherSet)
        {
            if (set.Count() == 0)
            {
                return true;
            }

            foreach (var item in set)
            {
                if (!otherSet.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Private method which is used in IsProperSubsetOf method.
        /// </summary>
        /// <param name="set">This set.</param>
        /// <param name="otherSet">Other set.</param>
        /// <returns>Bool result.</returns>
        private bool SetIsProperSubsetOfAnotherSet(IEnumerable<T> set, IEnumerable<T> otherSet)
        {
            if (set.Count() == 0 || otherSet.Count() == 0)
            {
                return true;
            }

            return (((Set<T>)set).IsSubsetOf(otherSet) && set.Count() < otherSet.Count());
        }

        /// <summary>
        /// Method to add element to the set.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        void ICollection<T>.Add(T data) => AddTo(data);

        /// <summary>
        /// Method to clear set.
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        /// <summary>
        /// Method to know if element is in the set.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        /// <returns>Bool result.</returns>
        public bool Contains(T data)
        {
            Node parent;
            return FindCurrent(data, out parent) != null;
        }

        /// <summary>
        /// Method to copy this set to array.
        /// </summary>
        /// <param name="array">Current array.</param>
        /// <param name="arrayIndex">From this index method copies set to array.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || array == null)
            {
                throw new ArgumentNullException("Index is negative!");
            }

            foreach (var item in this)
            {
                if (arrayIndex <= array.Length - 1)
                {
                    array[arrayIndex] = item;
                    ++arrayIndex;
                }
            }
        }

        /// <summary>
        /// Method to remove element.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        /// <returns></returns>
        public bool Remove(T data)
        {
            Node current = FindCurrent(data, out Node parent);
            if (current == null)
            {
                return false;
            }

            if (current.RightChild == null)
            {
                if (parent == null)
                {
                    head = current.LeftChild;
                }
                else
                {
                    int result = parent.Data.CompareTo(current.Data);
                    if (result > 0)
                    {
                        parent.LeftChild = current.LeftChild;
                    }
                    else if (result < 0)
                    {
                        parent.RightChild = current.LeftChild;
                    }
                }
            }
            else if (current.RightChild.LeftChild == null)
            {
                current.RightChild.LeftChild = current.LeftChild;
                if (parent == null)
                {
                    head = current.RightChild;
                }
                else
                {
                    int result = parent.Data.CompareTo(current.Data);
                    if (result > 0)
                    {
                        parent.LeftChild = current.RightChild;
                    }
                    else if (result < 0)
                    {
                        parent.RightChild = current.RightChild;
                    }
                }
            }
            else
            {
                var leftMost = current.RightChild.LeftChild;
                var leftMostParent = current.RightChild;
                while (leftMost != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.LeftChild;
                }
                leftMost.LeftChild = leftMost.RightChild;
                leftMost.LeftChild = current.LeftChild;
                leftMost.RightChild = current.RightChild;
                if (parent == null)
                {
                    head = leftMost;
                }
                else
                {
                    int result = parent.Data.CompareTo(current.Data);
                    if (result > 0)
                    {
                        parent.LeftChild = leftMost;
                    }
                    else if (result < 0)
                    {
                        parent.RightChild = leftMost;
                    }
                }
            }
            --Count;
            return true;
        }

        /// <summary>
        /// Private method that is used in GetEnumerator.
        /// </summary>
        /// <returns>Current element of the set.</returns>
        private IEnumerator<T> InOrder()
        {
            if (head != null)
            {
                var stack = new Stack<Node>();
                var current = head;
                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.LeftChild != null)
                        {
                            stack.Push(current);
                            current = current.LeftChild;
                        }
                    }

                    yield return current.Data;

                    if (current.RightChild != null)
                    {
                        current = current.RightChild;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        /// <summary>
        /// Method to list elements in the set.
        /// </summary>
        /// <returns>Private method to list.</returns>
        public IEnumerator<T> GetEnumerator() => InOrder();

        /// <summary>
        /// Method to get enumerator of the set.
        /// </summary>
        /// <returns>Enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Private method to add element to the set.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        private void AddTo(T data)
        {
            if (head == null)
            {
                head = new Node(data);
            }
            else
            {
                AddResult(head, data);
            }
        }

        /// <summary>
        /// Private method to know if element was added to the set.
        /// </summary>
        /// <param name="node">the element that starts the traversal.</param>
        /// <param name="data">Value of the element.</param>
        /// <returns>Bool result.</returns>
        private bool AddResult(Node node, T data)
        {
            if (node == null)
            {
                head = new Node(data);
                ++Count;
                return true;
            }

            if (data.CompareTo(node.Data) < 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node(data);
                    ++Count;
                    return true;
                }
                else
                {
                    AddResult(node.LeftChild, data);
                }
            }
            else if (data.CompareTo(node.Data) > 0)
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node(data);
                    ++Count;
                    return true;
                }
                else
                {
                    AddResult(node.RightChild, data);
                }
            }
            return false;
        }

        /// <summary>
        /// Private method that is used in Contains method.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        /// <param name="parent">Parent of the element.</param>
        /// <returns>Current element with its parent.</returns>
        private Node FindCurrent(T data, out Node parent)
        {
            var current = head;
            parent = null;
            while (current != null)
            {
                int result = current.Data.CompareTo(data);
                if (result > 0)
                {
                    parent = current;
                    current = current.LeftChild;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.RightChild;
                }
                else
                {
                    break;
                }
            }
            return current;
        }

        /// <summary>
        /// Method to know if element was added to the set.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        /// <returns>Bool result.</returns>
        public bool Add(T data) => AddResult(head, data);
    }
}
