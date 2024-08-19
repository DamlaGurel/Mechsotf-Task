namespace Soru_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = "acldm1labcdhsnd";
            var z = "shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa";

            Console.WriteLine(FindOccurance(t, z));


            string FindOccurance(string substring, string mainString)
            {
                string t = substring;
                string z = mainString;
                string substringOfT;
                int lengtOfT = t.Length;
                List<string> substrings = new List<string>();

                for (int i = 0; i < lengtOfT; i++)
                {
                    for (int j = 1; j <= lengtOfT - i; j++)
                    {
                        substringOfT = t.Substring(i, j);
                        substrings.Add(substringOfT);
                    }
                }

                int maxResult = 0;

                foreach (var subs in substrings)
                {
                    int counter = 0;
                    int indexOfT = 0;
                    int lengthOfSubs = subs.Length;

                    while ((indexOfT = z.IndexOf(subs, indexOfT)) != -1)
                    {
                        counter++;
                        indexOfT += subs.Length; 
                    }

                    int result = lengthOfSubs * counter;
                    if (result > maxResult)
                    {
                        maxResult = result;
                    }
                }

                return $"Maximum Value: {maxResult}";

            }
            Console.ReadLine();
        }
    }
}
