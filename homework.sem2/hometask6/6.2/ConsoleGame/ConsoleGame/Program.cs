namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var drawOnConsole = new ConsoleDraw();
            var game = new Game(drawOnConsole);
            var eventLoop = new EventLoop();
            eventLoop.rightHandler += game.OnRight;
            eventLoop.leftHandler += game.OnLeft;
            eventLoop.upHandler += game.OnUp;
            eventLoop.downHandler += game.OnDown;
            game.ReadFromFile("map.txt");
            game.DrawMap();
            eventLoop.Run();
        }
    }
}
