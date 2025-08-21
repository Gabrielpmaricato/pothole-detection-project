namespace TrepidaApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoggerFactory.Configure();
            var app = MauiApp.CreateBuilder().Build();
            app.Run(args);
        }
    }
}