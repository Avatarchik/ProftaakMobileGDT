using System;
using System.Windows.Forms;

namespace RandomEventGenerator
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form = new RandomEventGenerator();
            form.Show();

            Application.Run();
        }
    }
}