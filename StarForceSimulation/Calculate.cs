using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarForceSimulation
{
    public class Calculate : Program
    {
        //Rate are % converted into int 95% = 9500
        static int[] SuccessRate = { 9500, 9000, 8500, 8500, 8000, 7500, 7000, 6500, 6000, 5500, 5000, 4500, 4000, 3500, 3000, 3000, 3000, 3000, 3000, 3000, 3000, 3000, 300, 200, 100 };
        //Destroy Rates start at 12 going into 13
        static int[] DestroyRate = { 60,130,140,210,210,210,280,280,700,700,1940,2940,3960};
        static Random randomNum = new Random();

        //No event or safeguard Simulation
        public static void RunSimulation()
        {
            long countAttempts = 0;
            long countDestroyed = 0;
            long countSuccess = 0;
            long countFail = 0;

            for (int i = 0; i < numRepeat; i++)
            {
                for (int currentStar = BaseStars; currentStar < GoalStars;)
                {
                    //TODO: Visual stars method
                    //TODO: Add Meso count
                    int RNG = randomNum.Next(1, 10001);


                    if (RNG <= SuccessRate[currentStar]) //Success
                    {
                        countSuccess++;
                        currentStar++;
                    }
                    else if (RNG > SuccessRate[currentStar]) //Fail
                    {
                        countFail++;

                        if (currentStar > 11) //Destroy
                        {
                            if (RNG >= 10000 - DestroyRate[currentStar - 12])
                            {
                                //Destroyed items go back to 12 and counts number of times destroyed
                                currentStar = 12;
                                countDestroyed++;
                            }
                            else
                            {
                                currentStar--;
                            }
                        }
                        else if (currentStar > 10 && currentStar != 15 && currentStar != 20)
                        {
                            currentStar--;
                        }

                    }
                    countAttempts++;
                }
            }
            Console.WriteLine($"\n\tAverage outcome from {numRepeat} runs:");
            Console.WriteLine($"\t\tAttempts: {countAttempts/numRepeat}");
            Console.WriteLine($"\t\tSuccesses: {countSuccess/numRepeat}");
            Console.WriteLine($"\t\tFailures: {countFail/ numRepeat}");
            Console.WriteLine($"\t\tDestroyed items: {countDestroyed/numRepeat}");


            Navigate();
        }
    }
}
