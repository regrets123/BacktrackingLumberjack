using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    float time;
    [SerializeField]
    GameObject gameOverUI;

    public static bool gameOver;


    void Start()
    {
        gameOver = false;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0 && !WinGame.winGame)
        {
            Death();
        }
    }

    void Death()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        StartCoroutine(CursorShow());
    }

    IEnumerator CursorShow()
    {
        yield return new WaitForSeconds(10);
        Cursor.lockState = CursorLockMode.None;
    }


    public void Menu()
    {

    }
    public void PlayAgain()
    {

    }
}
