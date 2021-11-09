using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThunderScoutsApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportsPage : ContentPage
	{
		public ReportsPage()
		{
			InitializeComponent ();
		}

        void OnButtonPressed(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.ClassId)
            {
                case "GenerateReportsButton":
                    Console.WriteLine(DataHub.generateMatchCode());
                    break;
            }
        }
	}
}