using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

    public GameObject ItemToSpawn;
    public int playerNum = 999;

	// Use this for initialization
	void Start () {
	    if (playerNum < MainMenu.NumPlayers)
        {
            string controller = "k";
            if (playerNum > 0)
            {
                controller = "j" + 1;
            }
            
            GameObject obj = Instantiate<GameObject>(ItemToSpawn);
            obj.transform.position = transform.position;

            var movement = obj.GetComponent<PlayerMovementInput>();
            if (movement != null)
            {
                movement.Controller = controller;
            }
            var ragdoll = obj.GetComponent<Ragdoll>();
            if (movement != null)
            {
                ragdoll.Controller = controller;
            }
        }
	}
}
