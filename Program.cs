using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        public static void MovingRobot(int upperRightX, int upperRightY)
        {
            try
            {
                string currentLocation = Console.ReadLine().ToUpper();
                int currentX = Convert.ToInt32(currentLocation.Split(' ')[0]);
                int currentY = Convert.ToInt32(currentLocation.Split(' ')[1]);
                char directionChar = Convert.ToChar(currentLocation.Split(' ')[2]);

                Directions direction = (Directions)System.Enum.Parse(typeof(Directions), directionChar.ToString());


                string movementDirections = Console.ReadLine().ToUpper();
                char[] movementDirectionsArr = movementDirections.ToCharArray();

                foreach (char item in movementDirectionsArr)
                {
                    switch (item)
                    {
                        case 'M':
                            if (direction == Directions.N && currentY < upperRightY)
                            {
                                currentY++;
                            }
                            else if (direction == Directions.S && currentY != 0)
                            {
                                currentY--;
                            }
                            else if (direction == Directions.E && currentX < upperRightX)
                            {
                                currentX++;
                            }
                            else if (direction == Directions.W && currentX != 0)
                            {
                                currentX--;
                            }
                            break;
                        case 'L':
                            direction--;
                            if (Convert.ToInt32(direction) < 0)
                            {
                                direction = Directions.W;
                            }
                            break;
                        case 'R':
                            direction++;
                            if (Convert.ToInt32(direction) > 3)
                            {
                                direction = Directions.N;
                            }
                            break;
                        default:
                            break;
                    }
                }

                Console.WriteLine(currentX.ToString() + " " + currentY.ToString() + " " + direction.ToString());
                MovingRobot(upperRightX, upperRightY);
            }
            catch (Exception)
            {
                Console.WriteLine("Warning: You entered an invalid value!");
                Main(null);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                string upperRight = Console.ReadLine().ToUpper();

                int upperRightX = Convert.ToInt32(upperRight.Split(' ')[0]);
                int upperRightY = Convert.ToInt32(upperRight.Split(' ')[1]);

                MovingRobot(upperRightX, upperRightY);
            }
            catch (Exception)
            {
                Console.WriteLine("Warning: You entered an invalid value!");
                Main(null);
            }
            
            Console.ReadKey();
        }

        public enum Directions
        {
            N = 0,
            E = 1,
            S = 2,
            W = 3
        }
    }
}
