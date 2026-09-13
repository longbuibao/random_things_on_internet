using System;
using System.Text;

namespace RandomThingsOnInternet
{
    public class Program
    {
        static void VowelToConsonant()
        {
            const int iterations = 1_000_000;

            const double vToV = 0.06 / 0.43; // xs co dieu kien: đang đứng trên một nguyên âm, khả năng kí tự kế tiếp cũng là nguyên âm?
            const double cToV = 0.67;

            long vCount = 1;
            long cCount = 0;
            long vvCount = 0;

            bool currentIsVowel = true;

            for (int i = 1; i < iterations; i++)
            {
                double threshold = currentIsVowel ? vToV : cToV;
                bool nextIsVowel = Random.Shared.NextDouble() < threshold;

                if (currentIsVowel && nextIsVowel)
                {
                    vvCount++;
                }

                if (nextIsVowel)
                {
                    vCount++;
                }
                else
                {
                    cCount++;
                }

                currentIsVowel = nextIsVowel;
            }

            long total = vCount + cCount;
            long pairs = total - 1;

            Console.WriteLine($"Vowels : {vCount,15:N0}  ({(double)vCount / total:P2})");
            Console.WriteLine($"Consonants    : {cCount,15:N0}  ({(double)cCount / total:P2})");
            Console.WriteLine($"Vowel Vowel pair    : {vvCount,15:N0}  ({(double)vvCount / pairs:P2})");
        }

        
        static void Main(string[] args)
        {
            VowelToConsonant();
        }
    }
}