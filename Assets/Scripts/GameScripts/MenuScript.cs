using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*By Björn Andersson*/
public class MenuScript : MonoBehaviour
{
    public GameObject quitMenu;

    public void SharpenImage(Image image)         //Ändrar färg på knappar när musen hovras över dem och ändrar tillbaka när musen flyttas bort
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

    public void MainMenu()      //Laddar huvudmenyn
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void OpenGame()        //Startar spelet
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ConfirmQuit()     //Ber dig bekräfta om du verkligen vill avsluta spelet
    {
        quitMenu.SetActive(!quitMenu.active);
    }

    public void QuitGame()  //Stänger av spelet
    {
        Application.Quit();
    }
}
