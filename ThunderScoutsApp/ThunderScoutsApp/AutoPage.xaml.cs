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
	public partial class AutoPage : ContentPage
    {

        public AutoPage ()
        {

            InitializeComponent();

        }

        public int bottomVal = 0;
        public int outerVal = 0;
        public int innerVal = 0;

        void OnButtonClicked(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            switch (btn.ClassId)
            {
                case "DecreaseBottom":
                    if (bottomVal > 0)
                    {
                        bottomVal -= 1;
                    }
                    else
                    {
                        bottomVal = 0;
                    }

                    BottomScoredValue.Text = bottomVal + "";
                    break;

                case "IncreaseBottom":
                    bottomVal += 1;

                    BottomScoredValue.Text = bottomVal + "";
                    break;

                case "DecreaseOuter":
                    if (outerVal > 0)
                    {
                        outerVal -= 1;
                    }
                    else
                    {
                        outerVal = 0;
                    }

                    OuterScoredValue.Text = outerVal + "";
                    break;

                case "IncreaseOuter":
                    outerVal += 1;

                    OuterScoredValue.Text = outerVal + "";
                    break;

                case "DecreaseInner":
                    if (innerVal > 0)
                    {
                        innerVal -= 1;
                    }
                    else
                    {
                        innerVal = 0;
                    }

                    InnerScoredValue.Text = innerVal + "";
                    break;

                case "IncreaseInner":
                    innerVal += 1;

                    InnerScoredValue.Text = innerVal + "";
                    break;
            }

            DataHub.autoBottomCellsScored = bottomVal;
            DataHub.autoOuterCellsScored = outerVal;
            DataHub.autoInnerCellsScored = innerVal;

        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {

            Slider slider = (Slider)sender;

            switch (slider.ClassId)
            {
                case "PreloadCellSlider":

                    double stepNum = 1.0;

                    var value = PreloadCellSlider.Value;
                    int step = (int)(Math.Round(value / stepNum));

                    PreloadCellSlider.Value = step;
                    PreloadSliderValue.Text = "" + step;

                    DataHub.preloadedCells = step;

                    break;

                case "TrenchCellSlider":

                    stepNum = 1.0;

                    value = TrenchCellSlider.Value;
                    step = (int)(Math.Round(value / stepNum));

                    TrenchCellSlider.Value = step;
                    TrenchSliderValue.Text = "" + step;

                    DataHub.autoTrenchCellsCollected = step;

                    break;

                case "EnemyTrenchCellSlider":

                    stepNum = 1.0;

                    value = EnemyTrenchCellSlider.Value;
                    step = (int)(Math.Round(value / stepNum));

                    EnemyTrenchCellSlider.Value = step;
                    EnemyTrenchSliderValue.Text = "" + step;

                    DataHub.autoEnemyCellsCollected = step;

                    break;

                case "ShieldGenCellSlider":

                    stepNum = 1.0;

                    value = ShieldGenCellSlider.Value;
                    step = (int)(Math.Round(value / stepNum));

                    ShieldGenCellSlider.Value = step;
                    ShieldGenSliderValue.Text = "" + step;

                    DataHub.autoShieldGenCellsCollected = step;

                    break;
            }
            
        }

        void OnPickerValueChanged(object sender, EventArgs e)
        {

            Picker picker = (Picker)sender;

            switch (picker.ClassId)
            {
                case "StartingPosPicker":
                    DataHub.startingPos = (string)(picker.SelectedItem);
                    break;
                case "DirMovedPicker":
                    DataHub.directionMoved = (string)(picker.SelectedItem);
                    break;
            }

        }
	}
}