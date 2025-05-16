using LitShelf.Views;

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

            //Instanciation des différentes vue
            Viewauthor viewauthor = new Viewauthor();
            Viewbook viewbook = new Viewbook();
            Viewclient viewclient = new Viewclient();
            Viewloan viewloan = new Viewloan();
           
            ViewoneAuthor viewoneauthor = new ViewoneAuthor();
            ViewoneBook viewonebook = new ViewoneBook();
            ViewoneClient viewoneclient = new ViewoneClient();
            ViewoneLoan viewoneloan = new ViewoneLoan();

            ViewnewAuthor viewnewauthor = new ViewnewAuthor();
            ViewnewBook viewnewbook = new ViewnewBook();
            ViewnewClient viewnewclient = new ViewnewClient();
            ViewnewLoan viewnewloan = new ViewnewLoan();



            //Instanciation du model
            Model.Model model = new Model.Model();

            Controller.Controller controller = new Controller.Controller(viewbook, model, viewauthor, viewloan, viewclient, viewoneauthor, viewonebook, viewoneclient, viewoneloan,
                viewnewauthor, viewnewbook, viewnewclient, viewnewloan);

            Application.Run(viewbook);
        }
    }
}