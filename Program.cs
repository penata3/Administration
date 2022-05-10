namespace Administration
{
    using System;
    using System.Windows.Forms;

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var formFactory = HostBuilderExtensions.CompositionRoot();
            Application.Run(formFactory.CreateLoginForm());
        }
    }
}
