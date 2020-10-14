using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace HeapSort2
{
    class Program
    {
        public class HeapSort
        {           
            public static int nodeKiek = 0;
            public Node[] nodes = new Node[1];
            public Node root { get; set; }
            public Node current { get; set; }
            public int count { get; set; }
            public static int kiek = 0;          
            public int[] arr = new Int32[1];

            public HeapSort() { }
            /// <summary>
            /// Konstruktorius iškart sukuriantis Binary Tree Heap
            /// </summary>
            /// <param name="node"></param>
            public HeapSort(Node[] node)
            {
                for (int i = 0; i < node.Count(); i++)
                {
                    Add(node[i]);
                }
            }
            /// <summary>
            /// Rikiavimo metodas. Kviečiama šalinimo funkcija tol
            /// kol egzistuoja Heap.
            /// </summary>
            /// <param name="givenNodes"></param>
            public void Sort(Node[] givenNodes)
            {
                int n = givenNodes.Count();
                Console.WriteLine();
                for (int i = n-1; i >= 0; i--)
                {     
                    Remove();
                    n--;
                }
                Console.WriteLine("Surikiuotas medis: ");
                for (int i = 0; i < nodes.Count(); i++)
                {
                    Add(nodes[i]);
                    
                }
                for (int i = 0; i < nodes.Count(); i++)
                {
                    Console.Write("{0} ", nodes[i].data);
                }
                Console.WriteLine();               

            }
            /// <summary>
            /// Salinimo metodas, šalina paskutinį elementą iš Heap.
            /// Toliau yra kviečiamas Heapify() metodas, kad medis
            /// persikoreguotų ir būtų šalinamas kitas elementas.
            /// </summary>
            public void Remove()
            {
                //Heapify();
                current = root;
                string bitCount = Convert.ToString(count, 2);
                if (current.left != null)
                {                  
                    for (int i = 1; i < bitCount.Length; i++)
                    {
                        if (bitCount[i] == '0')
                        {
                            current = current.left;
                        }

                        else
                        {
                            current = current.right;
                        }
                            
                    }
                    if (root.data == 0)
                    {
                        Array.Resize(ref nodes, nodeKiek + 1);
                        this.nodes[nodeKiek] = new Node(root.data);
                        nodeKiek++;
                        Swap(root, current);
                        if (current.parent.left == current)
                        {
                            current.parent.left = null;
                        }
                        else
                        {
                            current.parent.right = null;
                        }
                        count--;
                        Heapify();
                    }                       
                    else
                    {
                        if (root != null)
                        {
                            Array.Resize(ref nodes, nodeKiek + 1);
                            this.nodes[nodeKiek] = new Node(root.data);
                            nodeKiek++;

                            Swap(root, current);
                            if (current.parent.left == current)
                            {
                                current.parent.left = null;
                            }
                            else
                            {
                                current.parent.right = null;
                            }
                            count--;
                            Heapify();
                        }
                    }
                }
                else 
                {
                    Array.Resize(ref nodes, nodeKiek + 1);
                    this.nodes[nodeKiek] = new Node(root.data);
                    nodeKiek++;                   
                    current = null;
                    root = null;
                    count--;
                }
            }
            /// <summary>
            /// Medžio pertvarkymo metodas
            /// </summary>
            public void Heapify()
            {
                Node largest;
                current = root;
                while (true)
                {
                    if (current.left == null)
                        break;
                    if (current.right == null)
                        largest = current.left;
                    else
                    {
                        if (current.left.data <= current.right.data)
                            largest = current.left;
                        else
                            largest = current.right;                           
                    }
                    if (largest.data <= current.data)
                    {
                        int temp;
                        temp = current.data;
                        current.data = largest.data;
                        largest.data = temp;
                        current = largest;
                    }
                    else
                        break;
                }
            }
            /// <summary>
            /// Keitimo metodas
            /// </summary>
            /// <param name="node1"></param>
            /// <param name="node2"></param>
            public void Swap(Node node1, Node node2)
            {
                int temp = node1.data;
                node1.data = node2.data;
                node2.data = temp;
            }

            /// <summary>
            /// Elementų pridėjimo į Complete Binary Tree metodas.
            /// Pridėjimo metu iškarto root elementu yra nustatomas
            /// mažiausias elementas
            /// </summary>
            /// <param name="node"></param>
            public void Add(Node node)
            {
                if (root == null)
                {
                    root = node;
                    count++;
                }
                else
                {
                    current = root;
                    string bitCount = Convert.ToString(count + 1, 2);
                    for (int i = 1; i < bitCount.Length; i++)
                    {
                        if (bitCount[i] == '0')
                        {
                            if (current.left == null)
                            {
                                current.left = new Node(current);
                            }
                            current = current.left;
                        }
                        else
                        {
                            if (current.right == null)
                            {
                                current.right = new Node(current);
                            }
                            current = current.right;
                        }
                    }
                    current.data = node.data;
                    while (true)
                    {
                        if (current == root)
                            break;
                        if (current.data < current.parent.data)
                        {
                            //switch data
                            int temp = current.data;
                            current.data = current.parent.data;
                            current.parent.data = temp;
                            current = current.parent;
                        }
                        else
                            break;
                    }
                    count++;
                }
            }

            /// <summary>
            /// Medžio spausdinimo metodas
            /// </summary>
            public void printHeap()
            {
                print("", root, false);
            }

            /// <summary>
            /// Medžio spausdinimo metodas
            /// </summary>
            /// <param name="prefix"></param>
            /// <param name="n"></param>
            /// <param name="isLeft"></param>
            public void print(String prefix, Node n, bool isLeft)
            {
                if (n != null)
                {
                    print(prefix + "     ", n.right, false);
                    Console.WriteLine(prefix + ("|-- ") + n.data);
                    print(prefix + "     ", n.left, true);
                }

            }
        }

        public class Node
        {
            public int data { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }
            public Node parent { get; set; }

            public Node(int data, Node left, Node right, Node parent)
            {
                this.data = data;
                this.left = left;
                this.right = right;
                this.parent = parent;
            }
            public Node(int data)
            {
                this.data = data;
            }
            public Node(Node point)
            {
                parent = point;
            }

        }

        static void Main(string[] args)
        {
            int n = 20;
            int reiksmeNuo = 0;
            int reiksmeIki = 1000;
            Node[] nodes = new Node[n];
            var watch = Stopwatch.StartNew();
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            Random rand = new Random(seed);
            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node(rand.Next(reiksmeNuo, reiksmeIki));
            } 
            Console.WriteLine("Pradines reiksmes: ");
            for (int i = 0; i < nodes.Count(); i++)
            {
                Console.Write("{0} ", nodes[i].data);
            }
            HeapSort heap = new HeapSort(nodes);
            heap.Sort(nodes);
            heap.printHeap();
            watch.Stop();
            var elapsed = watch.Elapsed.TotalSeconds;
            Console.WriteLine(elapsed + " sec");
        }
    }
}
