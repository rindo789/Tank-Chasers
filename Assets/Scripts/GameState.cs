using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
  public GameObject pauseMenu;
  private bool gamePaused = false;
  // Start is called before the first frame update
  void Start()
  {
    pauseMenu.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonUp("Cancel"))
    {
      if (gamePaused)
      {
        ResumeGame();
      }
      else
      {
        PauseGame();
      }
    }
  }
  public void PauseGame()
  {
    pauseMenu.SetActive(true); // Show pause menu
    Time.timeScale = 0f; // Freeze game time
    gamePaused = true;
  }

  public void ResumeGame()
  {
    pauseMenu.SetActive(false); // Hide pause menu
    Time.timeScale = 1f; // Resume game time
    gamePaused = false;
  }

  public void SaveGame()
  {
    GameSession session = FindObjectOfType<GameSession>();
    Player player = FindObjectOfType<Player>();

    GameData.PlayerScore = session.GetScore();
    GameData.PlayerHealth = player.GetHealth();

    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/savegame.save";
    FileStream stream = new FileStream(path, FileMode.Create);

    object[] data = new object[3];
    data[0] = GameData.PlayerName;
    data[1] = GameData.PlayerScore;
    data[2] = GameData.PlayerHealth;

    formatter.Serialize(stream, data);
    stream.Close();

    Time.timeScale = 1f; // Resume game time
    gamePaused = false;
  }

  public void LoadGame()
  {
    string path = Application.persistentDataPath + "/savegame.save";
    if (File.Exists(path))
    {
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);

      object[] data = formatter.Deserialize(stream) as object[];
      stream.Close();

      GameData.isLoaded = true;
      GameData.PlayerName = data[0] as string;
      GameData.PlayerScore = (int)data[1];
      GameData.PlayerHealth = (int)data[2];
    }
    else
    {
      Debug.LogError("Save file not found in " + path);
    }
  }
}
