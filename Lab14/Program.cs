using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class Graph
    {
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();
        public List<Edge> Edges { get; set; } = new List<Edge>();
    }

    class Vertex
    {
        public int Id { get; set; }
        public List<Edge> AdjacentEdges { get; set; } = new List<Edge>();
    }

    class Edge
    {
        public Vertex Vertex1 { get; set; }
        public Vertex Vertex2 { get; set; }
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public int Weight { get; set; }

        public Edge(Vertex from, Vertex to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }

    class PrimParallel
    {
        private Graph graph;
        private List<Edge> mstEdges = new List<Edge>();
        private int numProcessors = 4;  // Кількість процесорів 

        public PrimParallel(Graph graph)
        {
            this.graph = graph;
        }

        public void RunParallel()
        {
            HashSet<Vertex> inMST = new HashSet<Vertex>();
            List<Edge> mstEdges = new List<Edge>();
            PriorityQueue<Edge, int> edgeQueue = new PriorityQueue<Edge, int>();

            Vertex startVertex = graph.Vertices[0];
            inMST.Add(startVertex);

            foreach (var edge in startVertex.AdjacentEdges)
            {
                edgeQueue.Enqueue(edge, edge.Weight);
            }

            while (edgeQueue.Count > 0)
            {
                // Вибір найменшого ребра
                Edge edge = edgeQueue.Dequeue();

                // Отримуємо іншу вершину через порівняння з поточною
                Vertex nextVertex = edge.From == startVertex ? edge.To : edge.From;

                if (!inMST.Contains(nextVertex))
                {
                    // Додавання ребра до MST
                    mstEdges.Add(edge);
                    inMST.Add(nextVertex);
                    startVertex = nextVertex;

                    // Додавання всіх нових ребер від поточної вершини
                    foreach (var newEdge in nextVertex.AdjacentEdges)
                    {
                        if (!inMST.Contains(newEdge.From == nextVertex ? newEdge.To : newEdge.From))
                        {
                            edgeQueue.Enqueue(newEdge, newEdge.Weight);
                        }
                    }
                }
            }

            // Виведення результату
            Console.WriteLine("MST (Minimum Spanning Tree) edges:");
            foreach (var mstEdge in mstEdges)
            {
                Console.WriteLine($"Edge: {mstEdge.From.Id} - {mstEdge.To.Id}, Weight: {mstEdge.Weight}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Створення вершин
            Vertex v0 = new Vertex { Id = 0 };
            Vertex v1 = new Vertex { Id = 1 };
            Vertex v2 = new Vertex { Id = 2 };
            Vertex v3 = new Vertex { Id = 3 };
            Vertex v4 = new Vertex { Id = 4 };

            // Створення ребер
            Edge e0 = new Edge(v0, v1, 10);
            Edge e1 = new Edge(v0, v2, 20);
            Edge e2 = new Edge(v1, v3, 30);

            Edge e3 = new Edge(v2, v3, 10);
            Edge e4 = new Edge(v3, v4, 60);
            Edge e5 = new Edge(v1, v4, 50);

            Edge e6 = new Edge(v0, v4, 40);  
            Edge e7 = new Edge(v2, v4, 60);  
            Edge e8 = new Edge(v3, v4, 25);  

            // Додавання ребер до вершин
            v0.AdjacentEdges.Add(e0);
            v0.AdjacentEdges.Add(e1);
            v1.AdjacentEdges.Add(e0);
            v1.AdjacentEdges.Add(e2);
            v2.AdjacentEdges.Add(e1);
            v2.AdjacentEdges.Add(e3);
            v3.AdjacentEdges.Add(e2);
            v3.AdjacentEdges.Add(e4);
            v4.AdjacentEdges.Add(e3);
            v4.AdjacentEdges.Add(e5);

            v0.AdjacentEdges.Add(e6);  
            v2.AdjacentEdges.Add(e7);  
            v3.AdjacentEdges.Add(e8);  
            v4.AdjacentEdges.Add(e6);  
            v4.AdjacentEdges.Add(e7);  
            v4.AdjacentEdges.Add(e8); 

            // Створення графа
            Graph graph = new Graph();
            graph.Vertices.AddRange(new[] { v0, v1, v2, v3, v4 });
            graph.Edges.AddRange(new[] { e0, e1, e2, e3, e4, e5, e6, e7, e8 });

            // Запуск алгоритму Прима
            PrimParallel prim = new PrimParallel(graph);
            prim.RunParallel();
        }
    }
}
