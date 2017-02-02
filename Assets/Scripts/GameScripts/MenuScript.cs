using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*By Björn Andersson*/
public class MenuScript : MonoBehaviour
{
    public GameObject quitMenu;

    public void SharpenImage(Image image)
    {
        if (image.color.a < 1)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        }
        else if (image.color.a  > 0.4)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.3921569f);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitMenu()
    {
        quitMenu.active = !quitMenu.active;
    }

    public void OpenGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ConfirmQuit()
    {
        quitMenu.SetActive(!quitMenu.active);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
