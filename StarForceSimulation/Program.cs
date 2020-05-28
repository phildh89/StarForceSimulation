using System;
using System.Net;

namespace StarForceSimulation
{
    public class Program
    {
        public static int EquipLevel = 300;
        public static int MaxStars = 0;
        public static int BaseStars = 0;
        public static int GoalStars = 0;
        public static int numRepeat = 0;
        static void Main(string[] args)
        {
            WelcomeScreen();
            Start();
        }
        public static void Start()
        {
            BaseInfo();
            Calculate.RunSimulation();
        }
        public static void WelcomeScreen()
        {
            Console.WriteLine("\n\t-----------------------------------------");
            Console.WriteLine("\t    Maple Story Star Force Simulation");
            Console.WriteLine("\n\t      Press Any Key To Continue..");
            Console.WriteLine("\t-----------------------------------------");
            Console.ReadKey();
            Console.Clear();
        }
        public static void BaseInfo()
        {
            //Selecting equipment level
            do
            {
                try
                {
                    Console.Write("\n\tEnter the equipment level(0-275): ");
                    EquipLevel = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Write("Invalid Entry");
                }
            } while (EquipLevel < 0 || EquipLevel > 275);

            //Setting max star level
            if (EquipLevel < 96)
            {
                MaxStars = 5;
            }
            else if (EquipLevel >95 && EquipLevel <108)
            {
                MaxStars = 8;
            }
            else if (EquipLevel > 107 && EquipLevel < 118)
            {
                MaxStars = 10;
            }
            else if (EquipLevel > 117 && EquipLevel < 128)
            {
                MaxStars = 15;
            }
            else if (EquipLevel > 127 && EquipLevel < 138)
            {
                MaxStars = 20;
            }
            else if (EquipLevel > 137)
            {
                MaxStars = 25;
            }
            else
            {
                Console.WriteLine("Error");
            }

            //Selecting star base
            do
            {
                try
                {
                    Console.Write($"\n\tEnter starting Star Force (0 - {MaxStars - 1}): ");
                    BaseStars = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Write("Invalid Entry");
                }
            } while (BaseStars >= MaxStars || BaseStars < 0);

            //Selecting star goal
            do
            {
                try
                {
                    Console.Write($"\n\tEnter Final Star Force ({BaseStars + 1} - {MaxStars}): ");
                    GoalStars = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Write("Invalid Entry");
                }
            } while (GoalStars < BaseStars && GoalStars > MaxStars);

            //Number of times run
            do
            {
                try
                {
                    Console.Write($"\n\tNumber of times you want to simulation to run: ");
                    numRepeat = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Write("Invalid Entry");
                }
            } while (numRepeat < 0);

        }
        public static void Navigate()
        {
            char navigate = '0';

            do
            {
                try
                {
                    Console.Write("\n\t\tEnter 1 to redo with same stats \n\t\t\tOR \n\t\tEnter 2 to start over..");
                    navigate = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Entry");
                }
            } while (navigate != '1' && navigate != '2');

            if (navigate == '1')
            {
                Console.Clear();
                Calculate.RunSimulation();
            }
            else
            {
                Console.Clear();
                Start();
            }

        }
    }
}
