using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BALCIOGLU_MarsRover.Constant;

namespace BALCIOGLU_MarsRover
{
    /// <summary>
    /// RoverInfo
    /// </summary>
    public class RoverInfo : IRoverInfo
    {
        /// <summary>
        /// Rover Moving Start
        /// </summary>
        /// <param name="platoSizes"></param>
        /// <param name="roverMoves"></param>
        public void RoverMovingStart(List<int> platoSizes)
        {
            foreach (var move in this.RoverMoves)
            {
                switch (move)
                {
                    case 'L':
                        this.LeftReturn();
                        break;
                    case 'M':
                        this.GoForward();
                        break;
                    case 'R':
                        this.RightReturn();
                        break;
                    default:
                        this.ErrorMessage += $"{move} Geçersiz karakterdir. ";
                        break;
                }

                if (this.X < 0 || this.X > platoSizes[0] || this.Y < 0 || this.Y > platoSizes[1])
                {
                    this.ErrorMessage += $"{this.RoverName} plato sınırlarının dışına çıktı!! - ({platoSizes[0]} , {platoSizes[1]})";
                    this.Success = false;
                    return;
                }
            }
            this.RoverMovesOut += $"{this.RoverName} Son Kordinatları : {this.X} {this.Y} {this.Direction.ToString()}";
        }

        /// <summary>
        /// Left Return -> Sola Dön 
        /// </summary>
        private void LeftReturn()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Go Forward -> Ileri Git
        /// </summary>
        private void GoForward()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Y += 1;
                    break;
                case Directions.S:
                    this.Y -= 1;
                    break;
                case Directions.W:
                    this.X -= 1;
                    break;
                case Directions.E:
                    this.X += 1;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Right Return --> Sağ Dön
        /// </summary>
        private void RightReturn()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Rover Info
        /// </summary>
        public RoverInfo()
        {
            X = Y = 0;
            Direction = Directions.N;
            Success = true;
            ErrorMessage = "";
        }

        /// <summary>
        /// Rover Id
        /// </summary>
        public int RoverId { get; set; }

        /// <summary>
        /// Rover Name
        /// </summary>
        public string RoverName { get { return $"{RoverId}. Gezici"; } }

        /// <summary>
        /// Rover Kordinat X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Rover Kordinat Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Rover Moves
        /// </summary>
        public string RoverMoves { get; set; }

        /// <summary>
        /// Rover Direction
        /// </summary>
        public Directions Direction { get; set; }

        /// <summary>
        /// Rover Moves Out
        /// </summary>
        public string RoverMovesOut { get; set; }

        /// <summary>
        /// Success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Rover Moves Out
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
