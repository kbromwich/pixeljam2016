using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    PlayerSpawn[] playerSpawners;
    List<PlayerSpawn> UsedPlayerSpawn;

    void Awake()
    {
        playerSpawners =  FindObjectsOfType<PlayerSpawn>();
        for(int i = 0; i < MainMenu.NumPlayers; i++)
        {
            UsedPlayerSpawn[i] = playerSpawners[i];
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
