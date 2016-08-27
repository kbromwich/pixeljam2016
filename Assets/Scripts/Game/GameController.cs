using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    PlayerSpawn[] playerSpawners;
    List<PlayerSpawn> UsedPlayerSpawn;

    void Start()
    {
        UsedPlayerSpawn = new List<PlayerSpawn>();
        playerSpawners =  FindObjectsOfType<PlayerSpawn>();
        for(int i = 0; i < MainMenu.NumPlayers && i < playerSpawners.Length; i++)
        {
            UsedPlayerSpawn.Add(playerSpawners[i]);
        }
    }


    void KillPlayer(GameObject Player)
    {
        PlayerSpawn SpawnerToRemove = null;

        foreach (PlayerSpawn spawner in UsedPlayerSpawn)
        {
            if(spawner.SpawnedPlayer == Player)
            {
                SpawnerToRemove = spawner;
            }
        }

        UsedPlayerSpawn.Remove(SpawnerToRemove);

        if(UsedPlayerSpawn.Count <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
