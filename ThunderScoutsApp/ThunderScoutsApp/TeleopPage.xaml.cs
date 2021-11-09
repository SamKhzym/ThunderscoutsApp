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
	public partial class TeleopPage : ContentPage
	{
		public TeleopPage ()
		{
			InitializeComponent ();
		}

        int bayCollectedVal = 0;
        int groundCollectedVal = 0;
        int bottomHitVal = 0;
        int bottomMissVal = 0;
        int outerHitVal = 0;
        int outerMissVal = 0;
        int innerHitVal = 0;

        void OnButtonClicked(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            switch (btn.ClassId)
            {
                case "DecreaseCollectedBay":
                    if (bayCollectedVal > 0)
                    {
                        bayCollectedVal -= 1;
                    }
                    else
                    {
                        bayCollectedVal = 0;
                    }

                    CollectedCellsBayValue.Text = bayCollectedVal + "";
                    break;

                case "IncreaseCollectedBay":
                    bayCollectedVal += 1;

                    CollectedCellsBayValue.Text = bayCollectedVal + "";
                    break;

                case "DecreaseCollectedGround":
                    if (groundCollectedVal > 0)
                    {
                        groundCollectedVal -= 1;
                    }
                    else
                    {
                        groundCollectedVal = 0;
                    }

                    CollectedCellsGroundValue.Text = groundCollectedVal + "";
                    break;

                case "IncreaseCollectedGround":
                    groundCollectedVal += 1;

                    CollectedCellsGroundValue.Text = groundCollectedVal + "";
                    break;

                case "DecreaseBottomHit":
                    if (bottomHitVal > 0)
                    {
                        bottomHitVal -= 1;
                    }
                    else
                    {
                        bottomHitVal = 0;
                    }

                    BottomHitValue.Text = bottomHitVal + "";
                    break;

                case "IncreaseBottomHit":
                    bottomHitVal += 1;

                    BottomHitValue.Text = bottomHitVal + "";
                    break;

                case "DecreaseBottomMiss":
                    if (bottomMissVal > 0)
                    {
                        bottomMissVal -= 1;
                    }
                    else
                    {
                        bottomMissVal = 0;
                    }

                    BottomMissValue.Text = bottomMissVal + "";
                    break;

                case "IncreaseBottomMiss":
                    bottomMissVal += 1;

                    BottomMissValue.Text = bottomMissVal + "";
                    break;

                case "DecreaseOuterHit":
                    if (outerHitVal > 0)
                    {
                        outerHitVal -= 1;
                    }
                    else
                    {
                        outerHitVal = 0;
                    }

                    OuterHitValue.Text = outerHitVal + "";
                    break;

                case "IncreaseOuterHit":
                    outerHitVal += 1;

                    OuterHitValue.Text = outerHitVal + "";
                    break;

                case "DecreaseOuterMiss":
                    if (outerMissVal > 0)
                    {
                        outerMissVal -= 1;
                    }
                    else
                    {
                        outerMissVal = 0;
                    }

                    OuterMissValue.Text = outerMissVal + "";
                    break;

                case "IncreaseOuterMiss":
                    outerMissVal += 1;

                    OuterMissValue.Text = outerMissVal + "";
                    break;



                case "DecreaseInnerHit":
                    if (innerHitVal > 0)
                    {
                        innerHitVal -= 1;
                    }
                    else
                    {
                        innerHitVal = 0;
                    }

                    InnerHitValue.Text = innerHitVal + "";
                    break;

                case "IncreaseInnerHit":
                    innerHitVal += 1;

                    InnerHitValue.Text = innerHitVal + "";
                    break;
            }

            DataHub.teleopBayCellsCollected = bayCollectedVal;
            DataHub.teleopGroundCellsCollected = groundCollectedVal;
            DataHub.teleopBottomHit = bottomHitVal;
            DataHub.teleopBottomMiss = bottomMissVal;
            DataHub.teleopOuterHit = outerHitVal;
            DataHub.teleopOuterMiss = outerMissVal;
            DataHub.teleopInnerHit = innerHitVal;
        }

        void OnSwitchTriggered(object sender, EventArgs e)
        {
            Switch switcher = (Switch)sender;

            switch (switcher.ClassId)
            {
                case "RotationSwitch":
                    DataHub.canDoRotationControl = switcher.IsToggled;
                    break;
                case "PositionSwitch":
                    DataHub.canDoPositionControl = switcher.IsToggled;
                    break;
            }
        }

    }
}