
namespace DirectLifeTest
{
    internal class Program
    {
        // returns true if string 'a' would be in a lower index than string 'b' if sorted alphabeticaly
        private static bool greaterThan(string a, string b)
        {
            return string.Compare(a, b) >= 0;
        }
        // returns the strings value as descriped in the brief (doesnt do the multiply by position)
        private static int getValue(string a)
        {
            int total = 0;
            // casts to lower to garuntee the to value calculation works consistantly
            a = a.ToLower();

            foreach (char c in a)
            {
                // deducts 96 because 'a' holds the value of 97 in the ascii table and we want it to have the value of 1
                // given all lowercase letters are listed in order sequentialy this will convert all letters to its location in the alphabet
                total += c - 96;
            }
            return total;
        }
        private static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            int num_itter = 100;

            watch.Start();

            for (int itter = 0; itter < num_itter; itter++)
            {// unless this line is altered it is asumed that the "names.txt" is located in the same directory as the ".exe"
                string FilePath = $".\\names.txt";

                // maps the word to the ammount of times it was seen
                // SortedDictionary<string, int> sorted = [];
                string[] allNames;

                using (var file = new StreamReader(FilePath)) // this will open the file for reading and closes it at the end of the "using" block
                {
                    string text = file.ReadToEnd();
                    if (text.Length <= 0)
                    {
                        // exits if no text found
                        return;
                    }
                    allNames = text.Split("\",\""); // removes the dilimeters and all but the first and last "

                    int size = allNames.Length;
                    int lastIndex = size - 1; // just for my conviniance

                    // replaces ernouiouse "
                    allNames[0] = allNames[0].TrimStart('"'); // doesnt do replace because unless the word contains charaters out side of the english alphabet there will be no other occurances
                    allNames[lastIndex] = allNames[lastIndex].TrimEnd('"');

                    //foreach (string a in allNames)
                    //{
                    //    if (!sorted.TryAdd(a, 1))
                    //    {
                    //        ++sorted[a];
                    //    }
                    //}
                }
                Array.Sort(allNames);

                int total = 0;
                int idx = 0;
                // foreach (var word in sorted)
                // {
                //     total += getValue(word.Key) * word.Value * ++idx;
                // }
                foreach (var word in allNames)
                {
                    total += getValue(word) * ++idx;
                }

                // Console.WriteLine($"The total value of the file is: {total}");
            }



            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds / num_itter} ms");
        }
    }
}
