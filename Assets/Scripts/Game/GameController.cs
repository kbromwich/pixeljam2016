using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public CameraControl cameraControl;

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

        UpdateCameraTargets();
    }

    private void UpdateCameraTargets()
    {
        Transform[] targets = new Transform[Players.Count];
        for (int i = 0; i < Players.Count; i++)
        {
            targets[i] = Players[i].transform;
        }
        cameraControl.m_Targets = targets;
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

        UpdateCameraTargets();
    }
}
