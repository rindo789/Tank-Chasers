using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
  [SerializeField] float delayInSeconds = 2f;
  GameObject WriteNameScreen;
  GameObject Options;

  public void LoadStartMenu()
  {
    SceneManager.LoadScene(0);
  }

  public void LoadWriteNameScreen()
  {
    WriteNameScreen.SetActive(true);
    Options.SetActive(false);
  }
  public void LoadGame()
  {
    SceneManager.LoadScene("Game");
    FindObjectOfType<GameSession>().ResetGame();
  }

  public void LoadGameOver()
  {
    StartCoroutine(WaitAndLoad());
  }
  IEnumerator WaitAndLoad()
  {
    yield return new WaitForSeconds(delayInSeconds);
    SceneManager.LoadScene("GameOver");
  }

  public void QuitGame()
  {
    Application.Quit();
  }
  // Start is called before the first frame update
  void Start()
  {
    WriteNameScreen = GameObject.Find("WriteNameScreen");
    Options = GameObject.Find("Options");
    if (WriteNameScreen != null && Options != null)
    {
      WriteNameScreen.SetActive(false);
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
