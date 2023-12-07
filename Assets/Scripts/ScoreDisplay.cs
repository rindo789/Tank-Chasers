using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    TMP_Text scoreText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        gameSession = FindObjectOfType<GameSession>();
        if (GameData.isLoaded) {
          if (!GameData.alreadyLoaded) {
            gameSession.SetScore(GameData.PlayerScore);
            GameData.alreadyLoaded = true;
          }
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
