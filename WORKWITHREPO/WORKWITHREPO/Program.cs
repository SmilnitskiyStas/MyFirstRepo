// Create program for work with array

namespace WORKWITHREPO
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Write the desired length of the array?");
            int lenghtArray = int.Parse(Console.ReadLine());

            int[] intArray = new int[lenghtArray];

            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = new Random().Next(1, 27);
            }

            (int[] evenArray, int[] oddArray) = ArrayPackaging(intArray);

            (char[] charEvenArray, int evenCount) = ReplaceArray(evenArray);

            (char[] charOddArray, int oddCount) = ReplaceArray(oddArray);

            if (evenCount > oddCount)
            {
                Console.WriteLine($"\nEven array has {evenCount}");
            }
            else if (evenCount == oddCount)
            {
                Console.WriteLine($"\nEven arry has {evenCount} and odd array has {oddCount}");
            }
            else
            {
                Console.WriteLine($"\nOdd array has {oddCount}");
            }

            Console.WriteLine("\nEven array: ");

            for (int i = 0; i < charEvenArray.Length; i++)
            {
                Console.Write($"{charEvenArray[i]} ");
            }

            Console.WriteLine("\n\nOdd array: ");
            for (int i = 0; i < charOddArray.Length; i++)
            {
                Console.Write($"{charOddArray[i]} ");
            }
        }

        private static (int[], int[]) ArrayPackaging(int[] intArray)
        {
            int[] evenArrar = new int[intArray.Length];
            int evenNumber = 0;

            int[] oddArray = new int[intArray.Length];
            int oddNumber = 0;

            int evenCount = 0, oddCount = 0;

            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] % 2 != 0)
                {
                    oddArray[oddCount] = intArray[i];

                    oddCount++;
                    oddNumber++;
                }
                else
                {
                    evenArrar[evenCount] = intArray[i];

                    evenCount++;
                    evenNumber++;
                }
            }

            Array.Resize(ref evenArrar, evenNumber);
            Array.Resize(ref oddArray, oddNumber);

            return (evenArrar, oddArray);
        }

        private static (char[], int) ReplaceArray(int[] intArray)
        {
            int count = 0;

            string englishAlpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();

            string englishUpperAlpha = "AEIDHJ";

            char[] intToChar = new char[intArray.Length];

            for (int i = 0; i < intArray.Length; i++)
            {
                for (int j = 0; j < englishAlpha.Length; j++)
                {
                    if (intArray[i] == j + 1)
                    {
                        intToChar[i] = englishAlpha[j];
                    }
                }
            }

            for (int i = 0; i < intToChar.Length; i++)
            {
                for (int j = 0; j < englishUpperAlpha.Length; j++)
                {
                    if (englishUpperAlpha[j].ToString().ToLower() == intToChar[i].ToString().ToLower())
                    {
                        intToChar[i] = char.Parse(intToChar[i].ToString().Replace(intToChar[i], englishUpperAlpha[j]));

                        count++;
                    }
                }
            }

            return (intToChar, count);
        }
    }
}