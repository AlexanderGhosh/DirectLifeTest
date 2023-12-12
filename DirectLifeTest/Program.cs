
namespace DirectLifeTest
{
    internal class Program
    {
        // ANSWER: 871198282

        // Assumptions
        //  the file path is as stated in the local variable FilePath (not passed by args (i know how to do it but i find it cumbersome for testing))
        //  all names are enclosed by " and have comma separated
        //  There are no erroneous characters in any of the words (no chars not in the alphabet)
        //  each character is found in the ASCII table (it fits in a byte)
        //  all data is on the same line (no end of line indicators)
        //  no end of file indicator added manually
        //  the output is not to be returned but rather dumped to the console



        // Things i though of

        // Bubble sort
        //  my initial plan was to use bubble sort and calculated a running total with each swap 
        //  i felt that this method suffer as 'n' increased and therefor dismissed it

        // Something with the numbers 
        //  i had thought that there may be a relation between the alphabetical value and its alphabetical position
        //  however this would not work in the case of 'abcd' against 'dcba' both would have the same value and therefore there position could
        //  not be ascertained without either changing the value function (which would then need to be compensated for) or using 'meta'data which kinda
        //  defeats the purpose of just using the values

        // Reading char's one by one
        //  I felt this would not be very fast as it is likely the case that the move/copy operation that 'ReadToEnd()' will do is faster then reading one by one
        //  also in order to sort the array (to my knowledge) you need the full array or to at least loop thorough the previously sorted data

        // I have settled on this method because it has outperformed my home brew algos by double (see git commits) it likely has a greater special complexity then any of my methods as well

        private static void Main()
        {
            // unless this line is altered it is assumed that the "names.txt" is located in the same directory as the ".exe"
            string FilePath = $".\\names.txt";

            string[] allNames;

            using (var file = new StreamReader(FilePath)) // this will open the file for reading and closes it at the end of the "using" block
            {
                string text = file.ReadToEnd();
                if (text.Length <= 0)
                {
                    // exits if no text found
                    return;
                }
                allNames = text.Split(","); // splits at the delimiter  (doesn't address " because the get value func will just ignore it)
            }
            Array.Sort(allNames);

            int total = 0;
            int idx = 0;
            foreach (var word in allNames)
            {
                total += GetValue(word) * ++idx;
            }

            Console.WriteLine($"The total value of the file is: {total}");
        }


        /// <summary>
        /// returns the strings value as described in the brief (doesn't do the multiply by position)
        /// </summary>
        /// <param name="a">the string to return the value for</param>
        /// <returns>the alphabetical value of 'a'</returns>
        private static int GetValue(string a)
        {
            int total = 0;
            // casts to lower to guarantee the to value calculation works consistently
            a = a.ToLower();

            foreach (char c in a)
            {
                if (c == '"') continue;
                // deducts 96 because 'a' holds the value of 97 in the ascii table and we want it to have the value of 1
                // given all lowercase letters are listed in order sequentially this will convert all letters to its location in the alphabet
                total += c - 96;
            }
            return total;
        }

    }
}
