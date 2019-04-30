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
            float[] aLowArr = new float[256];
            float[] aMeanArr = new float[256];
            float[] aHighArr = new float[256];

            

            //Get information from files
            string aLine = aLow.ReadLine();
            int counter = 0;
            while (aLine != null)
            {
                float num;
                bool valid = float.TryParse(aLine, out num);
                if (valid)
                {
                    aLowArr[counter] = num;
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
                    aMeanArr[counter] = num;
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
                    aHighArr[counter] = num;
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
                            break;
                        case 2:
                            Console.WriteLine("Mean-256 Selected");
                            validSelection = true;
                            break;
                        case 3:
                            Console.WriteLine("High-256 Selected");
                            validSelection = true;
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


            //foreach (float f in aLowArr)
            //{
            //    Console.WriteLine("a: " + f);
            //}

            //foreach (float f in aMeanArr)
            //{
            //    Console.WriteLine("b: " + f);
            //}

            //foreach (float f in aHighArr)
            //{
            //    Console.WriteLine("c: " + f);
            //}

            Console.WriteLine("End");
            Console.ReadLine();

            float[] insertionSort(float[] arr)
            {
                float[] sortedArr = new float[arr.Length];
                for(int i = 0; i < arr.Length; i++)
                {

                }
                return sortedArr;
            }
        }
    }
}
