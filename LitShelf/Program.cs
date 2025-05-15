namespace LitShelf
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            View view = new View();

            Model.Model model = new Model.Model();

            Controller.Controller controller = new Controller.Controller(view, model);

            Application.Run(view);
        }
    }
}