namespace DirectLifeTest
{
    internal class Program
    {
        private const string FilePath = "";

        private static void Main(string[] args)
        {
            foreach (string line in File.ReadAllLines(FilePath))
            {
                Console.WriteLine(line);
            }
        }
    }
}
