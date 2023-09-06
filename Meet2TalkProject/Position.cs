using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meet2TalkProject
{
    public enum Directions
    {
        N = 1,
        E = 2,
        S = 3,
        W = 4
    }
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions? Direction { get; set; }

        public Position()
        {
            X = Y = 0;
            Direction = Directions.N;
        }

        public void Left90Rotate()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.W;
                    break;
                case Directions.W:
                    Direction = Directions.S;
                    break;
                case Directions.S:
                    Direction = Directions.E;
                    break;
                case Directions.E:
                    Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }
        public void Right90Rotate()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.E;
                    break;
                case Directions.E:
                    Direction = Directions.S;
                    break;
                case Directions.S:
                    Direction = Directions.W;
                    break;
                case Directions.W:
                    Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }
        public void MoveCar()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Y += 1;
                    break;
                case Directions.E:
                    this.X += 1;
                    break;
                case Directions.S:
                    this.Y -= 1;
                    break;
                case Directions.W:
                    this.X -= 1;

                    break;

                default:
                    break;

            }
        }
        public void Movement(int xSpaceValue, int ySpaceValue, string moves)
        {

            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        MoveCar();
                        break;
                    case 'L':
                        Left90Rotate();
                        break;
                    case 'R':
                        Right90Rotate();
                        break;

                }
                if (this.X > xSpaceValue || this.Y > ySpaceValue || this.X < 0 || this.Y < 0)
                {
                    Console.WriteLine("Car went out of space");
                    Console.ReadKey();
                    Console.WriteLine("Press any key...");
                    Start.StartMachine();
                }
            }
        }
    }


}
