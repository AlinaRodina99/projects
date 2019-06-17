using System.IO;
using System.Collections.Generic;
using System;

namespace ConsoleGame
{
    /// <summary>
    /// Class for all moves in the game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Variable for the map.
        /// </summary>
        private List<char[]> map;

        /// <summary>
        /// Variable for the current class that implements IDraw.
        /// </summary>
        private IDraw draw;

        /// <summary>
        /// Variable for the current coordinates of the gamer.
        /// </summary>
        public static (int, int) currentCoords;

        /// <summary>
        /// Variable for the previous coordinates of the gamer.
        /// </summary>
        private (int, int) previousCoords;

        /// <summary>
        /// Property for the current coordinates of the gamer.
        /// </summary>
        public (int, int) CurrentCoords => currentCoords;

        /// <summary>
        /// Constructor that initializes current class for drawing game.
        /// </summary>
        /// <param name="draw">Current class.</param>
        public Game(IDraw draw)
        {
            this.draw = draw;
        }

        /// <summary>
        /// Method for reading map of the game from the path.
        /// </summary>
        /// <param name="path">String name of the path with map.</param>
        public void ReadFromFile(string path)
        {
            try
            {
                map = new List<char[]>();
                using (var stream = new StreamReader(path))
                {
                    while (!stream.EndOfStream)
                    {
                        map.Add(stream.ReadLine().ToCharArray());
                    }
                }
            }
            catch(FileNotFoundException exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }

        /// <summary>
        /// Method for drawing the map.
        /// </summary>
        public void DrawMap()
        {
            Console.Clear();
            for (int i = 0; i < map.Count; ++i)
            {
                Console.WriteLine(string.Join("", map[i]));
            }
            currentCoords = PutGamerOnMap();
            Console.SetCursorPosition(currentCoords.Item2, currentCoords.Item1);
            Console.Write('@');
            --Console.CursorLeft;
        }

        /// <summary>
        /// Method for putting gamer on the map.
        /// </summary>
        /// <returns>яInitial coordiantes of the gamer.</returns>
        public (int, int) PutGamerOnMap()
        {
            for (int i = 0; i < map.Count; ++i)
            {
                for (int j = 0; j < map[i].Length; ++j)
                {
                    if (map[i][j] != '#')
                    {
                        currentCoords = (i, j);
                        return (i, j);
                    }
                }
            }
            Console.WriteLine("There is no place on this map!");
            return (-1, -1);
        }

        /// <summary>
        /// Method fot moving to the right.
        /// </summary>
        public void OnRight()
        {
            previousCoords = currentCoords;
            draw.WriteEmptySpace(previousCoords);
            if (currentCoords.Item2 + 1 < map[currentCoords.Item1].Length && map[currentCoords.Item1][currentCoords.Item2 + 1] != '#')
            {
                ++currentCoords.Item2;
            }
            draw.WriteGamer(currentCoords);
        }

        /// <summary>
        /// Method for moving to the left.
        /// </summary>
        public void OnLeft()
        {
            previousCoords = currentCoords;
            draw.WriteEmptySpace(previousCoords);
            if (currentCoords.Item2 - 1 > 0 && map[currentCoords.Item1][currentCoords.Item2 - 1] != '#')
            {
                --currentCoords.Item2;
            }
            draw.WriteGamer(currentCoords);
        }

        /// <summary>
        /// Method for moving up.
        /// </summary>
        public void OnUp()
        {
            previousCoords = currentCoords;
            draw.WriteEmptySpace(previousCoords);
            if (currentCoords.Item1 - 1 >= 0 && map[currentCoords.Item1 - 1][currentCoords.Item2] != '#')
            {
                --currentCoords.Item1;
            }
            draw.WriteGamer(currentCoords);
        }

        /// <summary>
        /// Method for moving down.
        /// </summary>
        public void OnDown()
        {
            previousCoords = currentCoords;
            draw.WriteEmptySpace(previousCoords);
            if (currentCoords.Item1 + 1 < map.Count && map[currentCoords.Item1 + 1][currentCoords.Item2] != '#')
            {
                ++currentCoords.Item1;
            }
            draw.WriteGamer(currentCoords);
        }
    }
}
