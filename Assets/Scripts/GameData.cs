using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GameData
{
  public static string PlayerName { get; set; } = "DEF";
  public static int PlayerScore { get; set; }
  public static int PlayerHealth { get; set; }
  public static bool isLoaded { get; set; } = false;
}
