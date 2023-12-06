using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour
{
    TMP_Text nameText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        nameText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        nameText.text = GameData.PlayerName;
    }
}
