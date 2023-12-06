using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreLoader : MonoBehaviour
{
  GameSession gameSession;

  void Start()
  {
    gameSession = FindObjectOfType<GameSession>();
    List<ScoreEntry> loadedScores = LoadLeaderboardData();
    Debug.Log(loadedScores[1].score);
    CheckRank(loadedScores, gameSession.GetScore(), GameData.PlayerName);
    ShowLeaderboard(loadedScores);
    SavePlayerScore(loadedScores);
  }

  // Update is called once per frame
  void Update()
  {

  }

  public List<ScoreEntry> LoadLeaderboardData()
  {
    string path = Application.persistentDataPath + "/leaderboard.save";
    if (File.Exists(path))
    {
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);

      List<ScoreEntry> leaderboard = formatter.Deserialize(stream) as List<ScoreEntry>;
      stream.Close();
      return leaderboard;
    }
    else
    {
      Debug.LogError("Leaderboard file not found in " + path);
      ScoreGen.SaveLeaderboardData(ScoreGen.CreateDefaultLeaderboard());
      return ScoreGen.CreateDefaultLeaderboard();
    }
  }

  public void CheckRank(List<ScoreEntry> loadedScores, int playerScore, string playerName)
  {
    foreach (var item in loadedScores)
    {
      if (item.score < playerScore)
      {
        item.name = playerName;
        item.score = playerScore;
        Debug.Log("Hrac bol lepši so skore " + playerScore);
        return;
      }
      else
      {
        Debug.Log("Hrac nebol lepši so skore " + playerScore);
      }
    }
  }

  public void ShowLeaderboard(List<ScoreEntry> loadedScores)
  {
    GameObject leaderboard = GameObject.Find("Leaderboard");
    for (int i = 0; i < 5; i++)
    {
      Transform playerRow = leaderboard.transform.GetChild(i);
      TMP_Text playerName = playerRow.GetChild(0).GetComponent<TMP_Text>(); //name on the leaderboard
      TMP_Text playerScore = playerRow.GetChild(1).GetComponent<TMP_Text>(); //score on the leaderboard

      playerName.text = loadedScores[i].name;
      playerScore.text = loadedScores[i].score.ToString();
    }
  }

  public void SavePlayerScore(List<ScoreEntry> loadedScores)
  {

    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/leaderboard.save";
    FileStream stream = new FileStream(path, FileMode.Create);

    formatter.Serialize(stream, loadedScores);
    stream.Close();
  }


}
