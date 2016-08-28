using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

    public GameObject ItemToSpawn;
    public int playerNum = 999;
    public GameObject SpawnedPlayer;

	// Use this for initialization
	void Awake () {
	    if (playerNum < MainMenu.NumPlayers)
        {
            string controller = "k" + (playerNum + 1); // keyboard is p1 and p2
            if (playerNum > 1)
            {
                controller = "j" + (playerNum - 1); // Controllers are p3 to p12
            }
            
            GameObject obj = Instantiate<GameObject>(ItemToSpawn);
            obj.transform.position = transform.position;
            SpawnedPlayer = obj;

            var movement = obj.GetComponent<PlayerMovementInput>();
            if (movement != null)
            {
                movement.Controller = controller;
            }
            var player = obj.GetComponent<Player>();
            if (player != null)
            {
                player.Index = playerNum;
            }
            var ragdoll = obj.GetComponent<Ragdoll>();
            if (movement != null)
            {
                ragdoll.Controller = controller;
            }
        }
	}
}
