using System;
using System.Collections.Generic;
using System.Text;

namespace ThunderScoutsApp
{
    public static class DataHub
    {

        //LOGIN VALS
        public static string firstName = "";
        public static string lastInitial = "";

        //MATCH INFO VALS
        public static int teamNum = 0;
        public static int matchNum = 0;
        public static string allianceColour = "";

        //AUTO VALS
        public static int preloadedCells = 0;
        public static string startingPos = "";
        public static string directionMoved = "";
        public static int autoTrenchCellsCollected = 0;
        public static int autoEnemyCellsCollected = 0;
        public static int autoShieldGenCellsCollected = 0;
        public static int autoBottomCellsScored = 0;
        public static int autoOuterCellsScored = 0;
        public static int autoInnerCellsScored = 0;

        //TELEOP VALS
        public static int teleopBayCellsCollected = 0;
        public static int teleopGroundCellsCollected = 0;
        public static int teleopBottomHit = 0;
        public static int teleopBottomMiss = 0;
        public static int teleopOuterHit = 0;
        public static int teleopOuterMiss = 0;
        public static int teleopInnerHit = 0;
        public static bool canDoRotationControl = false;
        public static bool canDoPositionControl = false;

        //ENDGAME VALS
        public static string climbPos = "";
        public static string climbEffectiveness = "";
        public static int penaltiesTaken = 0;

        //MATCH REVIEW VALS
        public static int defenseQuality = 0;
        public static int matchRolesDefense = 0;
        public static int matchRolesRebound = 0;
        public static int matchRolesTrench = 0;
        public static int matchRolesGenCycle = 0;
        public static int matchRolesSniperCycle = 0;

        public static int redPoints = 0;
        public static int redPenalties = 0;
        public static int redRankingPoints = 0;
        public static int bluePoints = 0;
        public static int bluePenalties = 0;
        public static int blueRankingPoints = 0;

        public static string generateMatchCode()
        {
            string report = "";

            report = report + firstName + lastInitial + "|";
            report = report + teamNum + "|" + matchNum + "|";
            if (allianceColour == "Red") { report += "r"; }
            else if (allianceColour == "Blue") { report += "b"; }

            report = report + "|" + preloadedCells + "|";
            if (startingPos == "Position 1") { report += "1"; }
            else if (startingPos == "Position 2") { report += "2"; }
            else if (startingPos == "Position 3") { report += "3"; }
            report += "|";
            if (directionMoved == "Forwards") { report += "f"; }
            else if (directionMoved == "Backwards") { report += "b"; }
            else if (directionMoved == "None") { report += "n"; }
            report = report + "|" + autoTrenchCellsCollected + "|" + autoEnemyCellsCollected +
                "|" + autoShieldGenCellsCollected + "|" + autoBottomCellsScored +
                "|" + autoOuterCellsScored + "|" + autoInnerCellsScored + "|";

            report = report + teleopBayCellsCollected + "|" + teleopGroundCellsCollected +
                "|" + teleopBottomHit + "|" + teleopBottomMiss + "|" + teleopOuterHit +
                "|" + teleopOuterMiss + "|" + teleopInnerHit + "|";
            if (canDoPositionControl) { report += "t"; }
            else { report += "f"; }
            report += "|";
            if (canDoRotationControl) { report += "t"; }
            else { report += "f"; }
            report += "|";

            if (climbPos == "None") { report += "n"; }
            else if (climbPos == "Side (Level)") { report += "l"; }
            else if (climbPos == "Side (High)") { report += "h"; }
            else if (climbPos == "Middle") { report += "m"; }
            report += "|";
            if (climbEffectiveness == "No Climb") { report += "n"; }
            else if (climbEffectiveness == "Failed Climb") { report += "f"; }
            else if (climbEffectiveness == "Climbed and Moved") { report += "m"; }
            else if (climbEffectiveness == "Climbed and Leveled") { report += "l"; }
            report += "|";
            report = report + penaltiesTaken + "|" + defenseQuality + "|" +
                matchRolesDefense + "|" + matchRolesRebound + "|" + matchRolesTrench + "|" +
                matchRolesGenCycle + "|" + matchRolesGenCycle + matchRolesGenCycle + "|";
            report = report + redPoints + "|" + redPenalties + "|" + redRankingPoints + "|" +
                bluePoints + "|" + bluePenalties + "|" + blueRankingPoints;

            return report;
        }

    }
}
