using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGameUIController : MonoBehaviour {

    public Text text;
    public GameObject ActivateToShow;

	public void PlayerWon(string PlayerName)
    {
        ActivateToShow.SetActive(true);
        text.text = PlayerName + " is the winner!";
    }
    
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
