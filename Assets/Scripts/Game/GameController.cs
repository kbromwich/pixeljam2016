using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    
    List<Player> Players;

    public string[] Names;
    public Color[] Colors;

    void Start()
    {
        Players = new List<Player>(FindObjectsOfType<Player>());
        foreach(Player player in Players)
        {
            player.name = Names[player.Index];
			player.GetComponent<MeshColourer>().SetMaterialColour(Colors[player.Index]);
        }
    }


    public void KillPlayer(Player player)
    {
        Players.Remove(player);

        if (Players.Count == 1)
        {
            print("Winner player is: " + Players[0].Index);
            EndGameUIController item = FindObjectOfType<EndGameUIController>();
            item.PlayerWon(Players[0].name);
        }
    }
}
