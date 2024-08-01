namespace GraphAssignment
{
    internal class Program
    {
        public abstract class Graph
        {
            public int VertexCount { get; protected set; }

            public Graph(int vertex)
            {
                VertexCount = vertex;
            }
            public abstract void Connect(int from, int to);
            public abstract void DisConnect(int from, int to);
            public abstract bool IsConnected(int from, int to);
        }
        public class ListGraph : Graph
        {
            private List<int>[] graph;
            public ListGraph(int vertex) : base(vertex)
            {
                graph = new List<int>[vertex];
                for (int i = 0; i < vertex; i++)
                {
                    graph[i] = new List<int>();
                }
            }
            public override void Connect(int from, int to)
            {
                graph[from].Add(to);
            }
            public override void DisConnect(int from, int to)
            {
                graph[from].Remove(to);
            }
            public override bool IsConnected(int from, int to)
            {
                return graph[from].Contains(to);
            }
        }
        static void Main(string[] args)
        {

            #region Graph1AMG
            // matrixGraph 구현
            Console.WriteLine("Adjacency Matrix Graph\n인접행렬 그래프");
            bool[,] matrixGraph = new bool[8, 8]
            {   //  0      1      2       3     4      5      6      7
                {  true,  true, false, false,  true, false, false, false },
                {  true,  true,  true,  true, false, false, false, false },
                { false,  true,  true, false,  true, false,  true, false },
                { false,  true, false,  true, false, false, false,  true },
                {  true, false,  true, false,  true, false,  true, false },
                { false, false, false, false, false,  true,  true, false },
                { false, false,  true, false,  true,  true,  true, false },
                { false, false, false,  true, false, false, false,  true }
            };
            // 각 노드마다 이어져 있는노드 표시
            for (int from = 0; from < 8; from++)
            {
                Console.WriteLine($"{from}정점: ");
                for (int to = 0; to < 8; to++)
                {
                    if (matrixGraph[from, to] == true)
                    {
                        Console.WriteLine($"\t{to} 정점");
                    }
                }
            }
            Console.WriteLine();
            #endregion

            #region Graph2ALG
            // 인접리스트 클래스를 이용해서 구현하기
            Console.WriteLine("Adjacency List Graph\n인접리스트 그래프");
            Graph listGraph = new ListGraph(8);

            // Node 0
            listGraph.Connect(0, 2);    
            listGraph.Connect(0, 3);
            listGraph.Connect(0, 4);
            // Node 1
            listGraph.Connect(1, 6);
            // Node 2
            listGraph.Connect(2, 0);
            listGraph.Connect(2, 4);
            // Node 3
            listGraph.Connect(3, 0);
            listGraph.Connect(3, 5);
            listGraph.Connect(3, 7);
            // Node 4
            listGraph.Connect(4, 2);
            listGraph.Connect(4, 0);
            // Node 5
            listGraph.Connect(5, 3);
            listGraph.Connect(5, 7);
            // Node 6
            listGraph.Connect(6, 1);
            listGraph.Connect(6, 7);
            // Node 7
            listGraph.Connect(7, 6);
            listGraph.Connect(7, 5);
            listGraph.Connect(7, 3);

            // printing node connection
            for (int from = 0; from < 8; from++)
            {
                Console.WriteLine($"{from}정점: ");
                for (int to = 0; to < 8; to++)
                {
                    if (listGraph.IsConnected(from, to))
                    {
                        Console.WriteLine($"\t{to} 정점");
                    }
                }
            }
            #endregion
        }
    }
}
