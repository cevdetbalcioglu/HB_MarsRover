using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BALCIOGLU_MarsRover
{
    /// <summary>
    /// IRoverInfo Interface
    /// </summary>
    public interface IRoverInfo
    {
        /// <summary>
        /// RoverMovingStart
        /// </summary>
        /// <param name="platoSizes"></param>
        /// <param name="roverMoves"></param>
        void RoverMovingStart(List<int> platoSizes);
         
    }
}
