using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace func_rocket
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//var form = new GameForm(LevelsTask.CreateLevels(Size spaceSize));
            var form = new GameForm(LevelsTask.CreateLevels());
            Application.Run(form);
		}
	}
}
 