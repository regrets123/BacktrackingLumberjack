using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public static bool winGame;

    [SerializeField]
    GameObject winUI;
    [SerializeField]
    GameObject Lumberjack;

	void Start ()
    {
        winGame = false;
	}
	
	void Update ()
    {
		if(winGame == true && !GameOver.gameOver)
        {
            Winning();
        }
	}

    void Winning()
    {
        winUI.SetActive(true);
        StartCoroutine(StartLumberJack());
    }

    IEnumerator StartLumberJack()
    {
        yield return new WaitForSeconds(25);
        Lumberjack.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
