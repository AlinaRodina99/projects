namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var drawOnConsole = new ConsoleDraw();
            var game = new Game(drawOnConsole);
            var eventLoop = new EventLoop();
            var onRight = new ArrowHandler(game.OnRight);
            var onLeft = new ArrowHandler(game.OnLeft);
            var up = new ArrowHandler(game.Up);
            var down = new ArrowHandler(game.Down);
            eventLoop.RegisterRightHandler(onRight);
            eventLoop.RegisterLeftHandler(onLeft);
            eventLoop.RegisterUpHandler(up);
            eventLoop.RegisterDownHandler(down);
            game.ReadFromFile("map.txt");
            game.DrawMap();
            eventLoop.Run();
        }
    }
}
