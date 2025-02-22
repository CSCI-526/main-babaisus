using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionManager : MonoBehaviour
{
    public static int mission;
    public static string[] missionNames = { "Horizontal", "Vertical", "Transparent", "Rotation", "Spikes Attached", "Jump Cubes", "Move Flag" };
    public static string type = "NEW Level ";
    public static int currentLevel;

    public static bool ShowLevelSelector = false;

}
