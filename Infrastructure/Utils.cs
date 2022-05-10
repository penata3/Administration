namespace Administration.Infrastructure
{
    using System.Linq;
    using System.Windows.Forms;

    public static class Utils
    {
        public static bool FormIsOpen(string name)
        {
            var OpenForms = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForms.Any(q => q.Name == name);
            return isOpen;
        }
    }
}
