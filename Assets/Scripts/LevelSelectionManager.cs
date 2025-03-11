using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionManager : MonoBehaviour
{
    public static int mission;

    // only 4 left
    public static string[] missionNames = { "Mission 1", "Rotation", "Spikes Attached", "Jump Cubes", "Move Flag" };

    public static string[] babyMissionNames = { "Horizontal", "Vertical", "Transparent", "Rotation" };

    // 0: New Level / 1: Tutorial Level
    public static int type = 0;
    
    // NEW Level / Tutorial Level
    public static string[] levelPrefix = {"NEW Level ", "Tutorial Level "};
    public static int currentLevel;

    public static int currentDatalevel;

    public static bool ShowLevelSelector = false;
    public static int[] mainRestartCounter= new int[50]; // Array of restart counters for each mission

}
