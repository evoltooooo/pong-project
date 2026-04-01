using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PongGameUI : MonoBehaviour
{
    GameManager manager;
    [SerializeField] TextMeshProUGUI playerscorelabel;
    [SerializeField] TextMeshProUGUI opponentscorelabel;
    [SerializeField] TextMeshProUGUI instructionLabel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        if (manager == null)
        {
            manager = FindObjectOfType<GameManager>();
        }

        manager.playerWin.AddListener(UpdatePlayerScore);
        manager.opponentWin.AddListener(UpdateOpponentScore);
        manager.startGame.AddListener(StartGameUIOperation);
        manager.finishGame.AddListener(GameFinishedUIOperation);

    }

    private void OnDisable()
    {
        manager.playerWin.RemoveListener(UpdatePlayerScore);
        manager.opponentWin.RemoveListener(UpdateOpponentScore);
        manager.startGame.RemoveListener(StartGameUIOperation);
        manager.finishGame.RemoveListener(GameFinishedUIOperation);
    }

    void StartGameUIOperation()
    {
        instructionLabel.gameObject.SetActive(false);
        playerscorelabel.SetText(manager.playerScore.ToString());
        opponentscorelabel.SetText(manager.opponentScore.ToString());
    }

    void GameFinishedUIOperation()
    {
        if (manager.playerScore == 11)
        {
            instructionLabel.SetText("You win!\nPress Space to restart the game.");
        }
        else
        {
            instructionLabel.SetText("You lose...\nPress Space to restart the game.");
        }
        instructionLabel.gameObject.SetActive(true);
    }

    void UpdatePlayerScore()
    {
        StartCoroutine(WaitForEventBeforeUpdatingPlayerScore());
    }

    IEnumerator WaitForEventBeforeUpdatingPlayerScore()
    {
        yield return new WaitForSeconds(0.2f);
        playerscorelabel.SetText(manager.playerScore.ToString());
    }

    void UpdateOpponentScore()
    {
        StartCoroutine(WaitForEventBeforeUpdatingOpponentScore());
    }

    IEnumerator WaitForEventBeforeUpdatingOpponentScore()
    {
        yield return new WaitForSeconds(0.2f);
        opponentscorelabel.SetText(manager.opponentScore.ToString());
    }
}
