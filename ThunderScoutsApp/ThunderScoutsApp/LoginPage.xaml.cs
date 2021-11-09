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
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void goToScoutingPage_Clicked(object sender, EventArgs e)
        {
            if (DataHub.firstName != "" && DataHub.lastInitial != "")
            {
                await Navigation.PushAsync(new ScoutingHubPage());
            }
            else
            {
                await DisplayAlert("Submission Error", "Please fill all fields", "OK");
            }
        } 

        void OnEntryChanged(object sender, EventArgs e)
        {
            Entry entry = (Entry)sender;

            switch (entry.ClassId)
            {
                case "FirstNameEntry":
                    DataHub.firstName = FirstNameEntry.Text;
                    break;
                case "LastInitialEntry":
                    DataHub.lastInitial = LastInitialEntry.Text;
                    break;
            }
        }
	}
}