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
	public partial class EndgamePage : ContentPage
	{
		public EndgamePage ()
		{
			InitializeComponent ();
		}

        int penaltyVal = 0;
        int defenseQualVal = 0;
        int defensePercent = 0;
        int reboundPercent = 0;
        int trenchPercent = 0;
        int genCyclePercent = 0;
        int sniperCyclePercent = 0;

        void OnButtonClicked(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            switch(btn.ClassId)
            {
                case "DecreasePenalties":
                    if (penaltyVal > 0)
                    {
                        penaltyVal -= 1;
                    }
                    else
                    {
                        penaltyVal = 0;
                    }
                    PenaltiesValue.Text = penaltyVal + "";
                    break;

                case "IncreasePenalties":
                    penaltyVal += 1;
                    PenaltiesValue.Text = penaltyVal + "";
                    break;
            }

            DataHub.penaltiesTaken = penaltyVal;

        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            Slider slider = (Slider)sender;

            switch (slider.ClassId)
            {
                case "DefenseQualitySlider":
                    defenseQualVal = (int)(Math.Round(DefenseQualitySlider.Value));
                    DataHub.defenseQuality = defenseQualVal;
                    DefenseQualitySlider.Value = defenseQualVal;
                    DefenseQualityValue.Text = defenseQualVal + "";
                    break;

                case "SniperPercentSlider":
                case "TrenchPercentSlider":
                case "DefensePercentSlider":
                case "GenPercentSlider":
                case "ReboundPercentSlider":

                    defensePercent = (int)(Math.Round(DefensePercentSlider.Value / 5.0) * 5.0);
                    reboundPercent = (int)(Math.Round(ReboundPercentSlider.Value / 5.0) * 5.0);
                    trenchPercent = (int)(Math.Round(TrenchPercentSlider.Value / 5.0) * 5.0);
                    genCyclePercent = (int)(Math.Round(GenPercentSlider.Value / 5.0) * 5.0);
                    sniperCyclePercent = (int)(Math.Round(SniperPercentSlider.Value / 5.0) * 5.0);
                    
                    if (!AreRoleSlidersUnder100())
                    {
                        int newVal = (int)(slider.Value) - (defensePercent + reboundPercent + trenchPercent + genCyclePercent + sniperCyclePercent - 100);

                        if (slider.ClassId== "SniperPercentSlider") { sniperCyclePercent = newVal; }
                        else if (slider.ClassId == "TrenchPercentSlider") { trenchPercent = newVal; }
                        else if (slider.ClassId == "DefensePercentSlider") { defensePercent = newVal; }
                        else if (slider.ClassId == "GenPercentSlider") { genCyclePercent = newVal; }
                        else if (slider.ClassId == "ReboundPercentSlider") { reboundPercent = newVal; }

                    }

                    DataHub.matchRolesDefense = defensePercent;
                    DataHub.matchRolesRebound = reboundPercent;
                    DataHub.matchRolesTrench = trenchPercent;
                    DataHub.matchRolesGenCycle = genCyclePercent;
                    DataHub.matchRolesSniperCycle = sniperCyclePercent;

                    DefensePercentSlider.Value = defensePercent;
                    ReboundPercentSlider.Value = reboundPercent;
                    TrenchPercentSlider.Value = trenchPercent;
                    GenPercentSlider.Value = genCyclePercent;
                    SniperPercentSlider.Value = sniperCyclePercent;

                    DefensePercentValue.Text = defensePercent + "%";
                    ReboundPercentValue.Text = reboundPercent + "%";
                    TrenchPercentValue.Text = trenchPercent + "%";
                    GenPercentValue.Text = genCyclePercent + "%";
                    SniperPercentValue.Text = sniperCyclePercent + "%";

                    break;
            }
        }

        private void OnPickerChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;

            switch (picker.ClassId)
            {
                case "ClimbPosPicker":
                    DataHub.climbPos = (string)(picker.SelectedItem);
                    break;
                case "ClimbStatusPicker":
                    DataHub.climbEffectiveness = (string)(picker.SelectedItem);
                    break;
            }
        }

        private void OnEntryChanged(object sender, EventArgs e)
        {
            Entry entry = (Entry)sender;

            try
            {
                switch (entry.ClassId)
                {
                    case "RedPoints":
                        DataHub.redPoints = Int32.Parse(entry.Text);
                        break;
                    case "RedPenalties":
                        DataHub.redPenalties = Int32.Parse(entry.Text);
                        break;
                    case "RedRP":
                        DataHub.redRankingPoints = Int32.Parse(entry.Text);
                        break;
                    case "BluePoints":
                        DataHub.bluePoints = Int32.Parse(entry.Text);
                        break;
                    case "BluePenalties":
                        DataHub.bluePenalties = Int32.Parse(entry.Text);
                        break;
                    case "BlueRP":
                        DataHub.blueRankingPoints = Int32.Parse(entry.Text);
                        break;
                }
            } catch { Exception err; }
        }

        bool AreRoleSlidersUnder100()
        {
            if (defensePercent + trenchPercent + reboundPercent + sniperCyclePercent + genCyclePercent <= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}