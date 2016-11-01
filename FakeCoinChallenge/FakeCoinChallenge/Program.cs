using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace FakeCoinsChallenge
{
    /*Challenge found on reddit for identifying fake coins given certain inputs
     * 1) Inputs will have a two strings of coins separated by a space and then
     * a value telling which way a scale tips for that measurement of coins.
     *   1a) The value will be either right, left, or equals.
     *   1b) Coins names will be one character long.
     *   1c) The first coin group will be the left side of the scale, the 
     *   second coin group will be the right side of the scale.
     * 2) There should only be one fake coin.
     * 3) Program has to output which coin is the lightest (AKA the fake.)
     */

    class findFakes
    {
        static void Main(string[] args)
        {
            string line = "";
            Char[] delimiter = new Char[1];
            delimiter[0] = ' ';
            StreamReader sr;

            string[] partitions;
            List<string> lightestCoins = new List<string>();
            List<string> heaviestCoins = new List<string>();

            bool breakflag = false;

            //Getting user input and opening file.
            string inputter = Console.ReadLine();
            string path = @"D:\Workspace\Challenges\FakeCoinChallenge\FakeCoinChallenge\";
            sr = new StreamReader(path+inputter);
            while (sr.Peek() >= 0)
            {
                //Reading a line in and splitting it.
                line = sr.ReadLine();
                partitions = line.Split(delimiter);

                Debug.WriteLine(partitions[0] + " " + partitions[1] + " " + partitions[2]);

                //Start of logic chunk to determine what to do with each input.
                if (partitions[2].Equals("right"))
                {
                    for (int i = 0; i < partitions[0].Length; i++)
                    {
                        if (!lightestCoins.Contains(partitions[0].Substring(i, 1)))
                        {
                            lightestCoins.Add(partitions[0].Substring(i, 1));
                        }
                        if (lightestCoins.Contains(partitions[0].Substring(i, 1)) && heaviestCoins.Contains(partitions[0].Substring(i, 1)))
                        {
                            breakflag = true;
                            break;
                        }
                    }
                    for (int i = 0; i < partitions[1].Length; i++)
                    {
                        if (!heaviestCoins.Contains(partitions[1].Substring(i, 1)))
                        {
                            heaviestCoins.Add(partitions[1].Substring(i, 1));
                        }
                        if (lightestCoins.Contains(partitions[1].Substring(i, 1)) && heaviestCoins.Contains(partitions[1].Substring(i, 1)))
                        {
                            breakflag = true;
                            break;
                        }
                    }
                }
                if (partitions[2].Equals("left"))
                {
                    for (int i = 0; i < partitions[0].Length; i++)
                    {
                        if (!heaviestCoins.Contains(partitions[0].Substring(i, 1)))
                        {
                            heaviestCoins.Add(partitions[0].Substring(i, 1));
                        }
                        if (lightestCoins.Contains(partitions[0].Substring(i, 1)) && heaviestCoins.Contains(partitions[0].Substring(i, 1)))
                        {
                            breakflag = true;
                            break;
                        }
                    }
                    for (int i = 0; i < partitions[1].Length; i++)
                    {
                        if (!lightestCoins.Contains(partitions[1].Substring(i, 1)))
                        {
                            lightestCoins.Add(partitions[1].Substring(i, 1));
                        }
                        if (lightestCoins.Contains(partitions[1].Substring(i, 1)) && heaviestCoins.Contains(partitions[1].Substring(i, 1)))
                        {
                            breakflag = true;
                            break;
                        }
                    }
                }
                if (partitions[2].Equals("equals"))
                {
                    for (int i = 0; i < partitions[0].Length; i++)
                    {
                        
                        if (!heaviestCoins.Contains(partitions[0].Substring(i, 1)))
                        {
                            heaviestCoins.Add(partitions[0].Substring(i, 1));
                        }
                        if (lightestCoins.Contains(partitions[0].Substring(i, 1)) && heaviestCoins.Contains(partitions[0].Substring(i, 1)))
                        {
                            breakflag = true;
                            break;
                        }
                        if (lightestCoins.Contains(partitions[0].Substring(i, 1)))
                        {
                            lightestCoins.Remove(partitions[0].Substring(i, 1));
                        }
                    }
                    if (breakflag) { break; }
                    for (int i = 0; i < partitions[1].Length; i++)
                    {
                        if (!heaviestCoins.Contains(partitions[1].Substring(i, 1)))
                        {
                            heaviestCoins.Add(partitions[1].Substring(i, 1));
                        }
                        if (lightestCoins.Contains(partitions[1].Substring(i, 1)) && heaviestCoins.Contains(partitions[1].Substring(i, 1)))
                        {
                            breakflag = true;
                            break;
                        }
                        if (lightestCoins.Contains(partitions[1].Substring(i, 1)))
                        {
                            lightestCoins.Remove(partitions[1].Substring(i, 1));
                        }
                    }
                    if (breakflag) { break; }
                }
                //End of logic chunk that will cascade out if inputs are illogical.
                if (breakflag) { break; }

            }
            if (breakflag) { Debug.WriteLine("Data is inconsistent, there may be more than one fake coin."); }
            else if(lightestCoins.Count == 1)
            {
                Debug.WriteLine(lightestCoins[0] + " is the fake coin.");
            }
            else
            {
                Debug.WriteLine("Either no fake coins were detected or data was invalid.");
            }
        }

    }
}
