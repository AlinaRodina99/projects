using System;

namespace ConsoleGame
{
    /// <summary>
    /// Class for drawing game on console.
    /// </summary>
    public class ConsoleDraw : IDraw
    {
        /// <summary>
        /// Method for drawing the gamer on the map.
        /// </summary>
        /// <param name="coordinates">Current coordinates of the gamer.</param>
        public void WriteGamer((int, int) coordinates)
        {
            Console.SetCursorPosition(coordinates.Item2, coordinates.Item1);
            Console.Write('@');
            --Console.CursorLeft;
        }

        /// <summary>
        /// Method for drawing empty space on the map.
        /// </summary>
        /// <param name="previousCoordinates">Previous coordinates of the gamer.</param>
        public void WriteEmptySpace((int, int) previousCoordinates)
        {
            Console.SetCursorPosition(previousCoordinates.Item2, previousCoordinates.Item1);
            Console.Write('.');
            --Console.CursorLeft;
        }
    }
}
