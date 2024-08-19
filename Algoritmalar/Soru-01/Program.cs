namespace Soru_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
    You have a text that some of the words in reverse order.
    The text also contains some words in the correct order, and they are wrapped in parenthesis.
    Write a function fixes all of the words and,
    remove the parenthesis that is used for marking the correct words.

    Your function should return the same text defined in the constant correctAnswer, please keep in mind
    that shortest way possible will get you extra points.
    */
            var inputText = "nhoJ (Griffith) nodnoL saw (an) (American) ,tsilevon ,tsilanruoj (and) laicos .tsivitca ((A) reenoip (of) laicremmoc noitcif (and) naciremA ,senizagam (he) saw eno (of) (the) tsrif (American) srohtua (to) emoceb (an) lanoitanretni ytirbelec (and) nrae a egral enutrof (from) ).gnitirw";
            var correctAnswer = "John Griffith London was an American novelist, journalist, and social activist. (A pioneer of commercial fiction and American magazines, he was one of the first American authors to become an international celebrity and earn a large fortune from writing.)";

            Console.WriteLine(ReverseText(inputText) == correctAnswer ? "Correct !!!" : "Wrong answer...!");

            string ReverseText(string input)
            {

                string[] text = inputText.Split(' ');
                List<string> outputText = new List<string>();

                foreach (string word in text)
                {
                    if (word.StartsWith("(") || word.StartsWith("(("))
                    {
                        if (word.StartsWith("(") && word.EndsWith(")"))
                        {
                            string cleanedWord = word.Substring(1).Replace(")", "").Replace(")", "");
                            outputText.Add(cleanedWord);
                        }

                    }
                    else
                    {
                        char[] charArray = word.ToCharArray();
                        Array.Reverse(charArray);
                        outputText.Add(new string(charArray));
                    }
                }

                string result = string.Join(" ", outputText);
                return result;
            }

            Console.ReadLine();
        }
    }
}
