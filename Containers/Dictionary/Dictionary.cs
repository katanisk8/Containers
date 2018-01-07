using System;
using System.Collections;
using System.Collections.Generic;

namespace Containers.Dictionary
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private IDictionaryElement<TKey, TValue> Root { get; set; } = null;
        public uint Count { get; private set; }
        public bool IsEmpty { get { return Root == null; } }

        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(TKey key, TValue value)
        {
            IDictionaryElement<TKey, TValue> newNode = CreateElemetn(key, value);

            Add(newNode);
        }

        public void Add(IDictionaryElement<TKey, TValue> newNode)
        {
            if (IsEmpty)
            {
                Root = newNode;
            }
            else
            {
                var node = Root;
                while (node != null)
                {
                    if (newNode.HashCode < node.HashCode)
                    {
                        if (node.LChild == null)
                        {
                            newNode.Parent = node;
                            node.LChild = newNode;
                            CheckLeftBalance(newNode);
                            break;
                        }
                        else
                        {
                            node = node.LChild;
                        }
                    }
                    else if (newNode.HashCode > node.HashCode)
                    {
                        if (node.RChild == null)
                        {
                            newNode.Parent = node;
                            node.RChild = newNode;
                            CheckRightBalance(newNode);
                            break;
                        }
                        else
                        {
                            node = node.RChild;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("lol");
                    }
                }
            }

            IncrementCounter();
        }

        private void CheckLeftBalance(IDictionaryElement<TKey, TValue> newNode)
        {
            //LL Rotation
            //LR Rotation
            //throw new NotImplementedException();
        }

        private void CheckRightBalance(IDictionaryElement<TKey, TValue> newNode)
        {
            //RR Rotation
            //RL Rotation
            //throw new NotImplementedException();
        }

        private void IncrementCounter()
        {
            ++Count;
        }

        private void DecrementCounter()
        {
            --Count;
        }

        private IDictionaryElement<TKey, TValue> CreateElemetn(TKey key, TValue value)
        {
            return new DictionaryElement<TKey, TValue>(key, value);
        }

        public TValue GetValue(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public void Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsValue(TValue value)
        {
            throw new NotImplementedException();
        }

        public void Remove(IDictionaryElement<TKey, TValue> value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        bool IContainer<IDictionaryElement<TKey, TValue>>.IsEmpty()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IDictionaryElement<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
