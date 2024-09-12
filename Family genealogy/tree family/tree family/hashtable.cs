using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree_family
{
    class Hashtable
    {
        public class HashNode
        {
            public int Key { get; set; }
            public main_Node Value { get; set; }
            public HashNode Next { get; set; }

            public HashNode(int key, main_Node value)
            {
                Key = key;
                Value = value;
                Next = null;
            }
        }

        private readonly int size;
        private readonly List<HashNode> blucks;

        public Hashtable(int size = 500)
        {
            this.size = size;
            blucks = new List<HashNode>(new HashNode[size]);
        }

        //برای مشخص کردن مکان ذخیره سازی ( اندیس )
        private int GetHash(int key)
        {
            return key % size;
        }

        public bool allkey(int key)
        {
            int blucksIndex = GetHash(key);
            HashNode current = blucks[blucksIndex];
            while (current != null)
            {
                if (current.Key == key)
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public string Add(int SSN, main_Node value)
        {
            int blucksIndex = GetHash(SSN);
            HashNode newNode = new HashNode(SSN, value);
            if (blucks[blucksIndex] == null)
            {
                blucks[blucksIndex] = newNode;
            }
            else
            {
                HashNode current = blucks[blucksIndex];
                while (current.Next != null)
                {
                    if (current.Key == SSN)
                    {
                        return "Key already exists not add";
                    }

                    current = current.Next;
                }

                if (current.Key == SSN)
                {
                    return "Key already exists not add";
                }

                current.Next = newNode;
            }

            return "add successfully...";
        }

        public main_Node Get(int key)
        {
            int blucksIndex = GetHash(key);
            HashNode current = blucks[blucksIndex];
            while (current != null)
            {
                if (current.Key == key)
                {
                    return current.Value;
                }

                current = current.Next;
            }

            return null;
        }

        public void Remove(int key)
        {
            int blucksIndex = GetHash(key);
            HashNode current = blucks[blucksIndex];
            HashNode previous = null;

            while (current != null)
            {
                if (current.Key == key)
                {
                    if (previous == null)
                    {
                        blucks[blucksIndex] = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    return;
                }

                previous = current;
                current = current.Next;
            }

            throw new InvalidOperationException("Key not found");
        }

        public List<main_Node> GetAllNodes()
        {
            List<main_Node> allNodes = new List<main_Node>();
            foreach (var bluck in blucks)
            {
                var current = bluck;
                while (current != null)
                {
                    allNodes.Add(current.Value);
                    current = current.Next;
                }
            }

            return allNodes;
        }

        internal void Add(string type, main_Node marid)
        {
            throw new NotImplementedException();
        }
    }
}