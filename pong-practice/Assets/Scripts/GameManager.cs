using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    bool gameOngoing = false;
    bool matchOngoing = false;
    public float playerScore = 0;
    public float opponentScore = 0;

    public UnityEvent startGame;
    public UnityEvent finishGame;
    public UnityEvent playerWin;
    public UnityEvent opponentWin;

    [SerializeField] PongBall ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ball == null)
        {
            ball = FindObjectOfType<PongBall>();
        }
        
    }

    private void OnEnable()
    {
        opponentWin.AddListener(OpponentWin);
        playerWin.AddListener(PlayerWin);
    }

    private void OnDisable()
    {
        opponentWin.RemoveAllListeners();
        playerWin.RemoveAllListeners();
        startGame.RemoveAllListeners();
        finishGame.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !matchOngoing && !gameOngoing)
        {
            StartNewGame();
        }
    }

    void StartNewGame()
    {
        playerScore = 0;
        opponentScore = 0;
        gameOngoing = true;

        startGame.Invoke(); 

        StartMatch();
    }

    void StartMatch()
    {
        matchOngoing = true;

        Debug.Log("Match Started");

        float yPos = Random.Range(-4.8f, 4.8f);
        ball.transform.position = new Vector3(0f, yPos);
        ball.gameObject.SetActive(true);
    }

    void FinishMatch()
    {
        matchOngoing = false;
        ball.gameObject.SetActive(false);

        if (playerScore == 11 || opponentScore == 11)
        {
            FinishGame();
        } 
        else
        {
            StartCoroutine(StartNextMatch());
        }
    }

    IEnumerator StartNextMatch()
    {
        yield return new WaitForSeconds(1f);
        StartMatch();
    }

    void FinishGame()
    {
        gameOngoing = false;
        finishGame.Invoke();
    }

    void PlayerWin()
    {
        playerScore += 1;
        Debug.Log("You win this match!");
        FinishMatch();
    }

    void OpponentWin()
    {
        opponentScore += 1;
        Debug.Log("The opponent this match...");
        FinishMatch();
    }
}
