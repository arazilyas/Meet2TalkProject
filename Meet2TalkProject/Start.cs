using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meet2TalkProject
{
    public static class Start
    {
        public static void StartMachine()
        {
            int xSpaceValue, ySpaceValue, xStartValue, yStartValue;
            string carPosition;

            Console.WriteLine("Enter the space dimensions (x, y)");
            var maxPointsValue = Console.ReadLine().Trim().Split(",");
            if (maxPointsValue.Count() != 2)
            {
                Console.WriteLine("Please enter the space dimensions.");
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                StartMachine();
            }

            else
            {
                var maxPoints = maxPointsValue.Select(int.Parse).ToList();
                Console.WriteLine("Enter the car's initial position and direction.(x, y, direction)");
                var startPosition = Console.ReadLine().Trim().Split(',');

                Position position = new Position();

                if (maxPoints.Count() == 2)
                {
                    xSpaceValue = Convert.ToInt32(maxPoints[0]);
                    ySpaceValue = Convert.ToInt32(maxPoints[1]);
                    if (startPosition.Count() == 3)
                    {
                        xStartValue = int.Parse(startPosition[0]);
                        yStartValue = int.Parse(startPosition[1]);
                        carPosition = startPosition[2];
                        if (xStartValue > xSpaceValue || yStartValue > ySpaceValue)
                        {
                            Console.WriteLine("Car's position cannot be greater than space dimensions.");
                        }
                        else
                        {
                            Console.WriteLine("Enter movements and directions.");
                            var moves = Console.ReadLine().ToUpper();

                            position.X = Convert.ToInt32(startPosition[0]);
                            position.Y = Convert.ToInt32(startPosition[1]);
                            position.Direction = (Directions)Enum.Parse(typeof(Directions), startPosition[2]);

                            try
                            {
                                position.Movement(xSpaceValue, ySpaceValue, moves);
                                Console.WriteLine($"{position.X},{position.Y},{position.Direction}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid coordinate and direction (Example: 5, 10, N || E || W || S).");
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                        StartMachine();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid coordinate (Example: 5, 10).");
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                    StartMachine();
                }
                Console.WriteLine("Process completed, press any key to exit.");
                Console.WriteLine("Press any key...");
                Console.ReadLine();
                StartMachine();
            }
        }
    }
}
