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
        public static float closestNum;
        static void Main(string[] args)
        {
            //Search algorithms: BST, Linear Search
            //Sort algorthims: Tree Sort (based on BST), Merge Sort, Insertion Sort, Quick Sort


            //start of menu system
            Console.WriteLine("Select Array To Work On: ");
            Console.WriteLine("1: Low-256");
            Console.WriteLine("2: Mean-256");
            Console.WriteLine("3: High-256");
            Console.WriteLine("4: Low-2048");
            Console.WriteLine("5: Mean-2048");
            Console.WriteLine("6: High-2048");
            Console.WriteLine("7: Low-4096");
            Console.WriteLine("8: Mean-4096");
            Console.WriteLine("9: High-4096");

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
                            float[] low256Arr = new float[256];
                            read(low256Arr, "Low_256.txt");
                            currentArr = low256Arr;
                            placeValue = 10;
                            currentArrName = "Low-256";
                            sort(currentArr, placeValue, currentArrName);
                            break;
                        case 2:
                            Console.WriteLine("Mean-256 Selected");
                            validSelection = true;
                            float[] mean256Arr = new float[256];
                            read(mean256Arr, "Mean_256.txt");
                            currentArr = mean256Arr;
                            placeValue = 10;
                            currentArrName = "Mean-256";
                            sort(currentArr, placeValue, currentArrName);
                            break;
                        case 3:
                            Console.WriteLine("High-256 Selected");
                            validSelection = true;
                            float[] high256Arr = new float[256];
                            read(high256Arr, "High_256.txt");
                            currentArr = high256Arr;
                            placeValue = 10;
                            currentArrName = "High-256";
                            sort(currentArr, placeValue, currentArrName);
                            break;
                        case 4:
                            Console.WriteLine("Low-2048 Selected");
                            validSelection = true;
                            float[] low2048Arr = new float[2048];
                            read(low2048Arr, "Low_2048.txt");
                            currentArr = low2048Arr;
                            placeValue = 50;
                            currentArrName = "Low-2048";
                            sort(currentArr, placeValue, currentArrName);
                            break;
                        case 5:
                            Console.WriteLine("Mean-2048 Selected");
                            validSelection = true;
                            float[] mean2048Arr = new float[2048];
                            read(mean2048Arr, "Mean_2048.txt");
                            currentArr = mean2048Arr;
                            placeValue = 50;
                            currentArrName = "Mean-2048";
                            sort(currentArr, placeValue, currentArrName);
                            break;
                        case 6:
                            Console.WriteLine("High-2048 Selected");
                            validSelection = true;
                            float[] high2048Arr = new float[2048];
                            read(high2048Arr, "High_2048.txt");
                            currentArr = high2048Arr;
                            placeValue = 50;
                            currentArrName = "High-2048";
                            sort(currentArr, placeValue, currentArrName);
                            break;
                        case 7:
                            Console.WriteLine("Low-4096 Selected");
                            validSelection = true;
                            float[] low4096Arr = new float[4096];
                            read(low4096Arr, "Low_4096.txt");
                            currentArr = low4096Arr;
                            placeValue = 80;
                            currentArrName = "Low-4096";
                            sort(currentArr, placeValue, currentArrName);
                            break;
                        case 8:
                            Console.WriteLine("Mean-4096 Selected");
                            validSelection = true;
                            float[] mean4096Arr = new float[4096];
                            read(mean4096Arr, "Mean_4096.txt");
                            currentArr = mean4096Arr;
                            placeValue = 80;
                            currentArrName = "Mean-4096";
                            sort(currentArr, placeValue, currentArrName);
                            break;
                        case 9:
                            Console.WriteLine("High-4096 Selected");
                            validSelection = true;
                            float[] high4096Arr = new float[4096];
                            read(high4096Arr, "High_4096.txt");
                            currentArr = high4096Arr;
                            placeValue = 80;
                            currentArrName = "High-4096";
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

            //read in data
            void read(float[] arr, string path)
            {
                StreamReader reader = new StreamReader(path);
                Console.WriteLine("Reading Files...");
                //Get information from files
                string line = reader.ReadLine();
                int counter = 0;
                while (line != null)
                {
                    float num;
                    bool valid = float.TryParse(line, out num);
                    if (valid)
                    {
                        arr[counter] = num;
                        counter++;
                    }
                    line = reader.ReadLine();
                }
            }


            //sort array with different methods
            void sort(float[] currArr, int spacing, string name)
            {
                //start sorting
                Console.WriteLine("START OF SORTING: " + name);
                Console.WriteLine("----------------------");
                //insertion sorts
                Console.WriteLine("Insertion Sort, press any key to start");
                Console.ReadKey(true);
                float[] sortedAscCurrentArr = new float[currArr.Length];
                Array.Copy(currArr, sortedAscCurrentArr, currArr.Length);
                sortedAscCurrentArr = insertionSortAsc(sortedAscCurrentArr);
                Console.WriteLine("\n\nAscending Order\n");
                printArr(sortedAscCurrentArr, spacing);
                float[] sortedDescCurrentArr = new float[currArr.Length];
                Array.Copy(currArr, sortedDescCurrentArr, currArr.Length);
                sortedDescCurrentArr = insertionSortDesc(sortedDescCurrentArr);
                Console.WriteLine("\n\nDescending Order\n");
                printArr(sortedDescCurrentArr, spacing);
                Console.WriteLine("\nInsertion sort finished");
                Console.WriteLine("----------------------");
                //merge sorts
                Console.WriteLine("Merge Sort, press any key to start");
                Console.ReadKey(true);
                Console.WriteLine("\n\nAscending Order\n");
                Array.Copy(currArr, sortedAscCurrentArr, currArr.Length);
                sortedAscCurrentArr = mergeSortAsc(sortedAscCurrentArr);
                printArr(sortedAscCurrentArr, spacing);
                Console.WriteLine("\n\nDescending Order\n");
                Array.Copy(currArr, sortedDescCurrentArr, currArr.Length);
                sortedDescCurrentArr = mergeSortDesc(sortedDescCurrentArr);
                printArr(sortedDescCurrentArr, spacing);
                Console.WriteLine("\nMerge sort finished");
                Console.WriteLine("----------------------");
                //quick sorts
                Console.WriteLine("Quick Sort, press any key to continue");
                Console.ReadKey(true);
                Console.WriteLine("\n\nAscending Order\n");
                Array.Copy(currArr, sortedAscCurrentArr, currArr.Length);
                sortedAscCurrentArr = quickSortAsc(sortedAscCurrentArr, 0, sortedAscCurrentArr.Length - 1);
                printArr(sortedAscCurrentArr, spacing);
                Console.WriteLine("\n\nDescending Order\n");
                Array.Copy(currArr, sortedDescCurrentArr, currArr.Length);
                sortedDescCurrentArr = quickSortDesc(sortedDescCurrentArr, 0, sortedDescCurrentArr.Length - 1);
                printArr(sortedDescCurrentArr, spacing);
                Console.WriteLine("\nQuick sort finished");
                Console.WriteLine("----------------------");
                //binary search tree sorts
                Console.WriteLine("Tree Sort (based on binary search tree), press any key to continue");
                Console.ReadKey(true);
                Console.WriteLine("putting array into a tree");
                BST arrTree = new BST();
                foreach(float f in currArr)
                {
                    arrTree.Insert(f);
                }
                Console.WriteLine("\n\nAscending Order\n");
                arrTree.PrintTreeAsc(10);
                Console.WriteLine("\n\nDescending Order\n");
                arrTree.PrintTreeDesc(10);
                Console.WriteLine("\nTree sort finished");
                Console.WriteLine("----------------------");
                Console.WriteLine("All sorts finished");
                Console.WriteLine("\n\n\nPlease enter value to search for: ");
                float target = 0;
                bool validInput = false;
                while (!validInput)
                {
                    validInput = float.TryParse(Console.ReadLine(), out target);
                    if (!validInput)
                    {
                        Console.WriteLine("Invalid Input, Please try again: ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Linear Search\n");
                linearSearch(target, sortedAscCurrentArr);
                Console.WriteLine("\n\nTree search");
                arrTree.treeSearch(target);
            }

            Console.WriteLine("\nEnd");
            Console.ReadKey(true);
            

            //linear search
            void linearSearch(float target, float[] arr){
                bool found = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    if(arr[i] == target)
                    {
                        Console.WriteLine("Target: " + target + " is at position: " + i);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Value not found, looking for closest...");
                    int counter = 0;
                    while (counter < arr.Length-1 && arr[counter] < target)
                    {
                        counter++;
                    }
                    if(target - arr[counter-1] < arr[counter] - target)
                    {
                        Console.WriteLine("Closest number at: " + arr[counter-1]);
                    }
                    else
                    {
                        Console.WriteLine("Closest number at: " + arr[counter]);
                    }
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
            float[] quickSortAsc(float[] arr, int low, int high)
            {
                if (low< high)
                {
                    int pi = pivotAsc(arr, low, high);
                    quickSortAsc(arr, low, pi - 1);
                    quickSortAsc(arr, pi + 1, high);
                }
                return arr;
            }

            int pivotAsc (float[] arr, int low, int high)
            {
                float pivotNum = arr[high];

                int i = low - 1;
                for (int j = low; j < high; j++)
                {
                    if (arr[j] < pivotNum)
                    {
                        i++;

                        float temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
                float temp1 = arr[i + 1];
                arr[i + 1] = arr[high];
                arr[high] = temp1;

                return i + 1;
            }

            float[] quickSortDesc(float[] arr, int low, int high)
            {
                if (low < high)
                {
                    int pi = pivotDesc(arr, low, high);
                    quickSortDesc(arr, low, pi - 1);
                    quickSortDesc(arr, pi + 1, high);
                }
                return arr;
            }

            int pivotDesc(float[] arr, int low, int high)
            {
                float pivotNum = arr[high];

                int i = low - 1;
                for (int j = low; j < high; j++)
                {
                    if (arr[j] > pivotNum)
                    {
                        i++;

                        float temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
                float temp1 = arr[i + 1];
                arr[i + 1] = arr[high];
                arr[high] = temp1;

                return i + 1;
            }


        }

        //function to print out every nth value of an array
        public static void printArr(float[] arr, int value)
        {
            int count = 1;
            foreach (float f in arr)
            {
                if (count % value == 0)
                {
                    Console.WriteLine(count + ": " + f);
                }
                count++;
            }
        }


        //function to print out every nth value of a list
        public static void printArr(List<float> arr, int value)
        {
            int count = 1;
            foreach (float f in arr)
            {
                if (count % value == 0)
                {
                    Console.WriteLine(count + ": " + f);
                }
                count++;
            }
        }
    }


    //Binary search tree class and functions
    class BST
    {
        public Node Root;
        public BST()
        {
        }

        public void treeSearch(float target)
        {
            bool found;
            found = search(Root, target);
            if (!found)
            {
                Console.WriteLine("value not found, finding closest");
                Program.closestNum = Math.Abs(target - Root.value);
                Console.WriteLine("Closest value in binary tree: " + closestSearch(Root, target, Program.closestNum));
            }
        }

        bool search(Node n, float target)
        {
            int counter = 0;
            bool found = false;
            if (n != null)
            {
                if (n.value == target)
                {
                    Console.WriteLine("Target at posistion: " + counter);
                    found = true;
                    return found;
                }
                else
                {
                    found = search(n.Left, target);
                    if (found)
                    {
                        return found;
                    }
                    else
                    {
                        found = search(n.Right, target);
                        if (found)
                        {
                            return found;
                        }
                    }
                }
            }
            return found;

        }

        float closestSearch(Node n, float target, float closest)
        {
            
            if (n != null)
            {
                closestSearch(n.Left, target, Program.closestNum);
                if (Math.Abs(target - n.value) < Math.Abs(target - Program.closestNum))
                {
                    Program.closestNum = n.value;

                }
                
                closestSearch(n.Right, target, Program.closestNum);
            }
            
            return Program.closestNum;

        }
        public void PrintTreeAsc()
        {
            List<float> numAsc = new List<float>();
            PrintInOrder(Root, numAsc);
            Program.printArr(numAsc, 1);
        }

        public void PrintTreeAsc(int spacer)
        {
            List<float> numAsc = new List<float>();
            PrintInOrder(Root, numAsc);
            Program.printArr(numAsc, spacer);
        }

        private void PrintInOrder(Node n, List<float>numAsc)
        {
            if (n != null)
            {
                PrintInOrder(n.Left, numAsc);
                numAsc.Add(n.value);
                PrintInOrder(n.Right, numAsc);
            }
        }

        public void PrintTreeDesc()
        {
            List<float> numDesc = new List<float>();
            PrintInOrderDesc(Root, numDesc);
            Program.printArr(numDesc, 1);
        }

        public void PrintTreeDesc(int spacer)
        {
            List<float> numDesc = new List<float>();
            PrintInOrderDesc(Root, numDesc);
            Program.printArr(numDesc, spacer);
        }


        private void PrintInOrderDesc(Node n, List<float> numDesc)
        {
            if (n != null)
            {
                PrintInOrderDesc(n.Right, numDesc);
                numDesc.Add(n.value);
                PrintInOrderDesc(n.Left, numDesc);
            }
        }


        public void Insert(float value)
        {
            InsertFunc(ref Root, value);
        }

        private void InsertFunc(ref Node curr, float value)
        {
            if (curr == null)
            {
                curr = new Node(value);
            }
            else
            {
                if (value < curr.value)
                {
                    InsertFunc(ref curr.Left, value);
                }
                else if (value > curr.value)
                {
                    InsertFunc(ref curr.Right, value);
                }
            }
        }


        
    }

    class Node
    {
        public float value;
        public Node Left;
        public Node Right;


        public Node()
        {

        }
        public Node(float passedValue)
        {
            value = passedValue;
        }
    }
}
