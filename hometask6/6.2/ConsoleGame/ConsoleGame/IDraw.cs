namespace ConsoleGame
{
    /// <summary>
    /// Interface for two classes for drawing game in different ways.
    /// </summary>
    public interface IDraw
    {
        /// <summary>
        /// Method for drawing the gamer on the map.
        /// </summary>
        /// <param name="coordinates">Current coordinates of the gamer.</param>
        void WriteGamer((int, int) coordinates);

        /// <summary>
        /// Method fot drawing empty space on the map.
        /// </summary>
        /// <param name="previousCoordinates">Previous coordinates of the gamer.</param>
        void WriteEmptySpace((int, int) previousCoordinates);
    }
}
