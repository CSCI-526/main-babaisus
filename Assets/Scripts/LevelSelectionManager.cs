using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionManager : MonoBehaviour
{
    public static int mission;

    // only 4 left
    public static string[] missionNames = { "Mission A", "Mission B", "Mission C", "Mission D", "Mission E", "Mission F", "Mission G" };

    public static string[] babyMissionNames = { "Horizontal", "Vertical", "Transparent", "Rotation" };
    public static string[] expertNames = { "Mission Z", "Mission Y" };

    // 0: New Level / 1: Tutorial Level / 2: Expert
    public static int type = 0;
    
    // NEW Level / Tutorial Level
    public static string[] levelPrefix = {"NEW Level ", "New Tutorial Level ", "Expert Level "};
    public static int currentLevel;

    public static int currentDatalevel;

    public static bool ShowLevelSelector = false;
    public static int[] mainRestartCounter= new int[50]; // Array of restart counters for each mission

    // tutorial useless in Mar 13 version
    public static int[] tutorialLevelIndex = {1, 3, 5, 7, 9};
    public static int[] mainLevelIndex = {1, 4, 7, 10, 13, 16, 19, 22, 25};
    public static int[] expertLevelIndex = {1, 4, 7, 10, 13};

    //analytics MAIN lists
    public static List<int> noStarsList= new List<int>();
    public static List<string> gameOutcomeList = new List<string>();
    public static List<string> ballTrajectoryList = new List<string>();
    public static List<string> platTrajectoryList = new List<string>();
    public static bool isHintTaken = false;

    public static int[] getLevelIndexes() {
        if(type == 0) {
            return mainLevelIndex;
        } else if(type == 1) {
            return tutorialLevelIndex;
        } else {
            return expertLevelIndex;
        }
    }
}
