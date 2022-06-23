namespace WinFormsApp2
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
            Application.Run(new Login());
            if (Login.status == "running")
            {
                Application.Run(new Form1());
            }
            else if (Login.status == "running2")
            {
                Application.Run(new UserFrom());
            }
        }
    }
}