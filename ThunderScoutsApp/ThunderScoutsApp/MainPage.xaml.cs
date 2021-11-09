using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ThunderScoutsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnEntryChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;

            try
            {
                switch (entry.ClassId)
                {

                    case "TeamNumberEntry":
                        DataHub.teamNum = Int32.Parse(TeamNumberEntry.Text);
                        break;
                    case "MatchNumberEntry":
                        DataHub.matchNum = Int32.Parse(MatchNumberEntry.Text);
                        break;

                }
            }
            catch { Exception err; }
        }

        void OnPickerValueChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;

            switch (picker.ClassId)
            {
                case "AllianceColourPicker":
                    DataHub.allianceColour = (string)(picker.SelectedItem);
                    break;
            }
        }
    }
}
