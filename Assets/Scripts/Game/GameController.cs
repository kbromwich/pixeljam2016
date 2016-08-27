using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    
    List<Player> Players;

    void Start()
    {
        Players = new List<Player>(FindObjectsOfType<Player>());
    }


    public void KillPlayer(Player player)
    {
        Players.Remove(player);

        if (Players.Count <= 1)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
