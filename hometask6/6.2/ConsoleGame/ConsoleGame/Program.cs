namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var drawOnConsole = new ConsoleDraw();
            var game = new Game(drawOnConsole);
            var eventLoop = new EventLoop();
            var onRight = new ArrowHandler(ref game.OnRight);
            var onLeft = new ArrowHandler(ref game.OnLeft);
            var up = new ArrowHandler(ref game.Up);
            var down = new ArrowHandler(ref game.Down);
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
