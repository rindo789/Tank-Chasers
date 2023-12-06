using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class ScoreGen
{
  // Start is called before the first frame update
  public static List<ScoreEntry> CreateDefaultLeaderboard()
  {
    return new List<ScoreEntry>
    {
        new ScoreEntry { name = "AAA", score = 5000 },
        new ScoreEntry { name = "BBB", score = 4000 },
        new ScoreEntry { name = "CCC", score = 3000 },
        new ScoreEntry { name = "DDD", score = 2000 },
        new ScoreEntry { name = "EEE", score = 1000 },
    };
  }

  public static void SaveLeaderboardData(List<ScoreEntry> leaderboard)
  {
    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/leaderboard.save";
    FileStream stream = new FileStream(path, FileMode.Create);

    formatter.Serialize(stream, leaderboard);
    stream.Close();
  }
}
