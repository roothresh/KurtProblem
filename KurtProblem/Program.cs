using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KurtProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
          string input; 

            //inputta sadece rakam ve , olmalı kontrol edelim ama patlatmayalım
            do
            {
                //diziyi alalım.
                Console.WriteLine($"{MyConstants.MINIMUM_VALUE_OF_NUMBERS}, {MyConstants.MAXIMUM_VALUE_OF_NUMBERS} " +
                    $"arası olacak şekilde sadece sayılar girmelisiniz. Her bir elemanı girdikten sonra ',' ile ayırınız. ");
                input = Console.ReadLine();
            } while (!Regex.IsMatch(input, @"^[0-9,]+$"));

            //girilen inputu array inte convert edelim.
            int[] theArray = input.TrimEnd(',').Split(',').Select(int.Parse).ToArray();

            Console.WriteLine("En çok tekrar eden en küçük sayı = " + FindLeastValuedButMostOccuringNumberCount(theArray));
            Console.ReadKey();
        }

        private static int FindLeastValuedButMostOccuringNumberCount(int[] theArray)
        {
            //girilen sayıların 1 ile 5 arasında olduğuna emin olalım.
            if (!theArray.All(x => x >= MyConstants.MINIMUM_VALUE_OF_NUMBERS && x <= MyConstants.MAXIMUM_VALUE_OF_NUMBERS))
                throw new ArgumentException("Diziye girilen tüm sayılar 1 ile 5 arasında olmalı");

            //şimdik sayıları bi linq ile gruplayalım yanyana gelsinler
            var groupByOfArray = theArray.GroupBy(x => x);

            //en çok tekrar eden sayılar kaç kere tekrar ediyormuş onu bulalım.
            int maxOccurences = groupByOfArray.Max(x => x.Count());

            //şimdi de bu en çok tekrar edenler arasında en küçük rakamı seçelim
            return groupByOfArray.Where(g => g.Count() == maxOccurences).Min(g => g.Key);
        }
    }
}
