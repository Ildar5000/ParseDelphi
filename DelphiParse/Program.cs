namespace DelphiParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ReadSingleFile readSingleFile = new ReadSingleFile();
            readSingleFile.ReadFile(@"D:\download\DelphiArcadeGames-master\Starter\AlienInvasionStarter\uGame.pas");
        }
    }
}
