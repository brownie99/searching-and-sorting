using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace CMP1124___Assignment_2__16653221
{
    class Program
    {
        static void Main(string[] args)
        {
            //Search algorithms: BST, Linear Search
            //Sort algorthims: Tree Sort (based on BST), Merge Sort, Insertion Sort, Quick Sort


            //Readers for getting information from files
            StreamReader aLow = new StreamReader("Low_256.txt");
            StreamReader aMean = new StreamReader("Mean_256.txt");
            StreamReader aHigh = new StreamReader("High_256.txt");


            //Information arrays
            float[] low256Arr = new float[256];
            float[] mean256Arr = new float[256];
            float[] high256Arr = new float[256];

            

            //Get information from files
            string aLine = aLow.ReadLine();
            int counter = 0;
            while (aLine != null)
            {
                float num;
                bool valid = float.TryParse(aLine, out num);
                if (valid)
                {
                    low256Arr[counter] = num;
                    Console.WriteLine(counter);
                    Console.WriteLine(num);
                    counter++;
                }
                aLine = aLow.ReadLine();
            }

            string bLine = aMean.ReadLine();
            counter = 0;
            while (bLine != null)
            {
                float num;
                bool valid = float.TryParse(bLine, out num);
                if (valid)
                {
                    mean256Arr[counter] = num;
                    Console.WriteLine(counter);
                    Console.WriteLine(num);
                    counter++;
                }
                bLine = aMean.ReadLine();
            }

            string cLine = aHigh.ReadLine();
            counter = 0;
            while (cLine != null)
            {
                float num;
                bool valid = float.TryParse(cLine, out num);
                if (valid)
                {
                    high256Arr[counter] = num;
                    Console.WriteLine(counter);
                    Console.WriteLine(num);
                    counter++;
                }
                cLine = aHigh.ReadLine();
            }




            //start of menu system
            Console.WriteLine("Select Array To Work On: ");
            Console.WriteLine("1: Low-256");
            Console.WriteLine("2: Mean-256");
            Console.WriteLine("3: High-256");

            float[] currentArr;
            int placeValue;
            string currentArrName;

            bool validSelection = false;
            bool validInt = false;
            while (!validSelection)
            {
                int selection; 
                validInt = Int32.TryParse(Console.ReadLine(), out selection);
                if (validInt)
                {
                    switch (selection)
                    {
                        case 1:
                            Console.WriteLine("Low-256 Selected");
                            validSelection = true;
                            currentArr = low256Arr;
                            placeValue = 10;
                            currentArrName = "Low-256";
                            sort(currentArr, placeValue, currentArrName);
                            break;
                        case 2:
                            Console.WriteLine("Mean-256 Selected");
                            validSelection = true;
                            currentArr = mean256Arr;
                            placeValue = 10;
                            currentArrName = "Mean-256";
                            sort(currentArr, placeValue, currentArrName);
                            break;
                        case 3:
                            Console.WriteLine("High-256 Selected");
                            validSelection = true;
                            currentArr = high256Arr;
                            placeValue = 10;
                            currentArrName = "High-256";
                            sort(currentArr, placeValue, currentArrName);
                            break;
                        default:
                            Console.WriteLine("Error, Invalid Selection");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Error, Invalid Selection");
                }
            }
            
            

            void sort(float[] currArr, int spacing, string name)
            {
                Console.WriteLine("START OF SORTING: " + name);
                Console.WriteLine("----------------------");
                Console.WriteLine("Insertion Sort, press any key to start");
                Console.ReadKey(true);
                float[] sortedAscCurrentArr = insertionSortAsc(currArr);
                Console.WriteLine("\n\nAscending Order\n");
                printArr(sortedAscCurrentArr, spacing);
                float[] sortedDescALowArr = insertionSortDesc(currArr);
                Console.WriteLine("\n\nDescending Order\n");
                printArr(sortedDescALowArr, spacing);
                Console.WriteLine("\nInsertion sort finished");
                Console.WriteLine("----------------------");
                Console.WriteLine("Merge Sort, press any key to start");
                Console.ReadKey(true);
                sortedAscCurrentArr = mergeSortAsc(currArr);
                printArr(sortedAscCurrentArr, spacing);
                Console.WriteLine("\n");
                sortedDescALowArr = mergeSortDesc(currArr);
                printArr(sortedDescALowArr, spacing);
            }

            Console.WriteLine("\nEnd");
            Console.ReadKey(true);
            

            //function to print out every nth value of an array
            void printArr(float[] arr, int value)
            {
                int count = 1;
                foreach(float f in arr)
                {
                    if (count % value == 0)
                    {
                        Console.WriteLine(count + ": " + f);
                    }
                    count++;
                }
            }

            //insertion sorts ascending and descending
            float[] insertionSortAsc(float[] arr)
            {
                float[] sortedArr = new float[arr.Length];
                for(int i = 0; i < arr.Length; i++)
                {
                    float currF = arr[i];
                    int j = i - 1;
                    while(j >= 0 && currF < sortedArr[j])
                    {
                        sortedArr[j + 1] = sortedArr[j];
                        j--;
                    }
                    sortedArr[j + 1] = currF;
                }
                return sortedArr;
            }

            float[] insertionSortDesc(float[] arr)
            {
                float[] sortedArr = new float[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    float currF = arr[i];
                    int j = i - 1;
                    while (j >= 0 && currF > sortedArr[j])
                    {
                        sortedArr[j + 1] = sortedArr[j];
                        j--;
                    }
                    sortedArr[j + 1] = currF;
                }
                return sortedArr;
            }


            //merge sorts ascending and descending

            float[] mergeSortAsc(float[] arr)
            {
                float[] sortedArr = new float[arr.Length];
                float[] left;
                float[] right;
                
                if(arr.Length <= 1)
                {
                    return arr;
                }

                int midPoint = arr.Length / 2;
                left = new float[midPoint];

                if (arr.Length%2 == 0)
                {
                    right = new float[midPoint];
                }
                else
                {
                    right = new float[midPoint + 1];
                }

                for(int i = 0; i < midPoint; i++)
                {
                    left[i] = arr[i];
                }

                int x = 0;
                for (int i = midPoint; i < arr.Length; i++)
                {
                    right[x] = arr[i];
                    x++;
                }

                left = mergeSortAsc(left);
                right = mergeSortAsc(right);
                sortedArr = mergeAsc(left, right);
                return sortedArr;
            }

            float[] mergeAsc(float[] left, float[] right)
            {
                int sortedLength = left.Length + right.Length;
                float[] sortedArrs = new float[sortedLength];
                int indexLeft = 0;
                int indexRight = 0;
                int indexSorted = 0;

                while(indexLeft < left.Length || indexRight < right.Length)
                {
                    if (indexLeft < left.Length && indexRight < right.Length)
                    {
                        if(left[indexLeft] <= right[indexRight])
                        {
                            sortedArrs[indexSorted] = left[indexLeft];
                            indexLeft++;
                            indexSorted++;
                        }
                        else
                        {
                            sortedArrs[indexSorted] = right[indexRight];
                            indexSorted++;
                            indexRight++;
                        }
                    }
                    else if(indexLeft < left.Length)
                    {
                        sortedArrs[indexSorted] = left[indexLeft];
                        indexLeft++;
                        indexSorted++;
                    }
                    else if(indexRight < right.Length)
                    {
                        sortedArrs[indexSorted] = right[indexRight];
                        indexRight++;
                        indexSorted++;
                    }
                }
                return sortedArrs;
            }

            float[] mergeSortDesc(float[] arr)
            {
                float[] sortedArr = new float[arr.Length];
                float[] left;
                float[] right;

                if (arr.Length <= 1)
                {
                    return arr;
                }

                int midPoint = arr.Length / 2;
                left = new float[midPoint];

                if (arr.Length % 2 == 0)
                {
                    right = new float[midPoint];
                }
                else
                {
                    right = new float[midPoint + 1];
                }

                for (int i = 0; i < midPoint; i++)
                {
                    left[i] = arr[i];
                }

                int x = 0;
                for (int i = midPoint; i < arr.Length; i++)
                {
                    right[x] = arr[i];
                    x++;
                }

                left = mergeSortDesc(left);
                right = mergeSortDesc(right);
                sortedArr = mergeDesc(left, right);
                return sortedArr;
            }

            float[] mergeDesc(float[] left, float[] right)
            {
                int sortedLength = left.Length + right.Length;
                float[] sortedArrs = new float[sortedLength];
                int indexLeft = 0;
                int indexRight = 0;
                int indexSorted = 0;

                while (indexLeft < left.Length || indexRight < right.Length)
                {
                    if (indexLeft < left.Length && indexRight < right.Length)
                    {
                        if (left[indexLeft] >= right[indexRight])
                        {
                            sortedArrs[indexSorted] = left[indexLeft];
                            indexLeft++;
                            indexSorted++;
                        }
                        else
                        {
                            sortedArrs[indexSorted] = right[indexRight];
                            indexSorted++;
                            indexRight++;
                        }
                    }
                    else if (indexLeft < left.Length)
                    {
                        sortedArrs[indexSorted] = left[indexLeft];
                        indexLeft++;
                        indexSorted++;
                    }
                    else if (indexRight < right.Length)
                    {
                        sortedArrs[indexSorted] = right[indexRight];
                        indexRight++;
                        indexSorted++;
                    }
                    
                    
                }
                return sortedArrs;
            }


            //quick sorts ascending and descending
            float[] quickSortAsc(float[] arr)
            {
                float[] sortedArr = new float[arr.Length];

                return sortedArr;
            }

            float[] quickSortDesc(float[] arr)
            {
                float[] sortedArr = new float[arr.Length];

                return sortedArr;
            }
        }
    }
}
