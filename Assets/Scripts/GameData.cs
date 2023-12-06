using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class GameData
{
  public static string PlayerName { get; set; } = "DEFA";
  public static int PlayerScore { get; set; }
  public static int PlayerHealth { get; set; }
}
