using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int p1HP;
    public int p2HP;

    public GameObject gameOverScreen;

    public void HitPlayer1()
    {
        p1HP = 0;
        Debug.Log("Player 1 hit!");
        P1Wins();
    }
    public void HitPlayer2()
    {
        p2HP = 0;
        Debug.Log("Player 2 hit!");
        P2Wins();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void P1Wins()
    {
        gameOverScreen.SetActive(true);
    }
    public void P2Wins()
    {
        gameOverScreen.SetActive(true);
    }
}
