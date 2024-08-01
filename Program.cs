namespace GraphAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // matrixGraph 구현
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
        }
    }
}
