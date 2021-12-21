using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnexinetTechnicalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string option = "";

            while (true)
            {
                Console.Clear();

                Console.WriteLine("1. Leap years\n");
                Console.WriteLine("2. Arrays common elements\n");
                Console.WriteLine("3. Anagram\n");
                Console.WriteLine("4. Swap two numbers (missing)\n");
                Console.WriteLine("5. Parenthesis (missing)\n");
                Console.WriteLine("6. Transpose matrix\n");
                Console.WriteLine("7. Add numbers (missing)\n");
                Console.WriteLine("8. Exit\n");

                option = Console.ReadLine();

                Console.Clear();
                switch (option)
                {
                    case "1":
                        PrintNextLeapYears();
                        break;
                    case "2":
                        GetCommonElements();
                        break;
                    case "3":
                        AreAnagrams();
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        TransposeMatrix();
                        break;
                    case "7":
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        #region Leap year
        private static void PrintNextLeapYears()
        {
            var result = GetNextLeapYears(DateTime.Today.Year);

            var years = string.Join(",", result);

            Console.WriteLine($"Next leap years: {years}");
        }

        /// <summary>
        /// Retrives the next 20 leap years
        /// </summary>
        /// <param name="start"></param>
        /// <returns>int array with the next 20 leap years</returns>
        private static List<int> GetNextLeapYears(int start)
        {
            // Add one to the given year because we want the next 20 leap years, so if the given year is a leap year we have to exclude it
            int nextLeapYear = start + 1;
            List<int> leapYears = new List<int>();

            while (!IsLeapYear(nextLeapYear))
            {
                nextLeapYear++;
            }

            // Now that we have the next leap year, just need to add 4
            for (int i = 0; i < 20; i++)
            {
                leapYears.Add(nextLeapYear);
                nextLeapYear += 4;
            }
            return leapYears;
        }

        /// <summary>
        /// Determine if the year is a leap year 
        /// </summary>
        /// <param name="year"></param>
        /// <returns>True if is a leap year</returns>
        private static bool IsLeapYear(int year)
        {
            // If the year is not evenly divisible by 4 is not a leap year
            if (year % 4 == 0)
            {
                if (year % 100 != 0)
                {
                    return true;
                }
                if (year % 400 == 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        #endregion

        #region Anagram
        public static void AreAnagrams()
        {

            Console.WriteLine("Enter first string: ");
            string str1 = Console.ReadLine().Trim();
            Console.WriteLine("Enter second string: ");
            string str2 = Console.ReadLine().Trim();

            // Not sure if anagrams should exclude empty spaces, for example "ave" and "e   va", are those anagrams?
            if (str1.Length != str2.Length)
            {
                Console.WriteLine("Both strings are not anagrams.");
            }
            else
            {
                // Prepare strings for comparison
                str1 = GetCleanString(str1);
                str2 = GetCleanString(str2);
                if (str1 == str2)
                {
                    Console.WriteLine("Both strings are anagrams.");
                }
                else
                {
                    Console.WriteLine("Both strings are not anagrams.");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">String value</param>
        /// <returns>An empty space free, upper case, sorted string</returns>
        private static string GetCleanString(string value)
        {
            // Remove spaces, convert to upper case char array
            var stringArray = value.Replace(" ", string.Empty).ToUpper().ToCharArray();
            // Sort char array
            Array.Sort<char>(stringArray);
            // Convert char array into a single string
            string retobj = string.Join("", stringArray);
            return retobj;
        }

        #endregion

        #region Array common elements
        /// <summary>
        /// Prints all common elements in the given arrays
        /// </summary>
        public static void GetCommonElements()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] b = { 3, 2, 9, 3, 7, 11, 15, 13, 23, 27, 32, 35, 36, 37 };
            int[] c = { 1, 3, 5, 7, 11, 13, 15, 17, 19, 21, 23, 27, 35, 37 };
            int[] d = { 9, 17, 32, 7, 2, 3, 1, 45, 46, 47, 55, 60, 6, 17 };

            // "Intersect" returns all common elements in two arrays
            var abcd = a.Intersect(b).Intersect(c).Intersect(d);

            // Convert the array into a comma separated string
            var result = string.Join(",", abcd);
            Console.WriteLine($"Arrays common elements: {result}");
        }
        #endregion

        #region Transpose matrix

        /// <summary>
        /// Ask for a mxn matrix, then transpose it
        /// </summary>
        public static void TransposeMatrix()
        {
            // An square matrix is not mandatory
            int dim0 = 2;
            int dim1 = 3;
            string[,] matrix = new string[dim0, dim1];

            // Ask for matrix elements
            for (int i = 0; i < dim0; i++)
            {
                for (int j = 0; j < dim1; j++)
                {
                    Console.Write($"Matrix[{i}, {j}]: ");
                    matrix[i, j] = Console.ReadLine();
                    Console.Write(" ");
                }
                Console.Write("\n");
            }

            // Print source matrix
            Console.WriteLine("Source matrix: ");

            for (int i = 0; i < dim0; i++)
            {
                for (int j = 0; j < dim1; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.Write("\n");
            }

            var transposedMatrix = GetTransposedMatrix(matrix);

            // Print transposed matrix
            Console.WriteLine("\nTransposed matrix: ");

            for (int j = 0; j < dim1; j++)
            {
                for (int i = 0; i < dim0; i++)
                {
                    Console.Write(transposedMatrix[j, i]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }

        /// <summary>
        /// Transpose the given nxm matrix
        /// </summary>
        /// <param name="matrix">Source matrix</param>
        /// <returns>Transposed mxn matrix</returns>
        private static string[,] GetTransposedMatrix(string[,] matrix)
        {
            // Get source matrix dimensions, then initialize transposed matrix
            int dim0 = matrix.GetLength(0);
            int dim1 = matrix.GetLength(1);
            string[,] retobj = new string[dim1, dim0];

            for (int i = 0; i < dim0; i++)
            {
                for (int j = 0; j < dim1; j++)
                {
                    retobj[j, i] = matrix[i, j];
                }
            }

            return retobj;
        }
        #endregion
    }
}
