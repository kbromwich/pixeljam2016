using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int NumPlayers = 1;

    public TextMesh[] menuItems;
    
    int selectedIndex = 0;
    int xinput = 0;
    int yinput = 0;
    bool submit = false;
    float lastxinput = 0;
    float lastyinput = 0;
    bool lastsubmit = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        yinput = 0;
        xinput = 0;
        float verticalAxis = Input.GetAxis("Vertical");
        if (lastyinput == 0 && verticalAxis != 0)
        {
            yinput = Math.Sign(verticalAxis);
        }
        float horizontalAxis = Input.GetAxis("Horizontal");
        if (lastxinput == 0 && horizontalAxis != 0)
        {
            xinput = Math.Sign(horizontalAxis);
        }

        selectedIndex = Mod(selectedIndex - yinput, menuItems.Length);
        submit = !lastsubmit && Input.GetButtonDown("Submit");

        for (int i = 0; i < menuItems.Length; i++)
        {
            menuItems[i].color = Color.black;
        }


        var selected = menuItems[selectedIndex];
        selected.color = Color.green;

        if (selected.text.StartsWith("PLAYERS"))
        {
            NumPlayers = Mod(NumPlayers - 1 + xinput, 5) + 1;
            selected.text = "PLAYERS <" + NumPlayers + ">";
        }


        if (submit)
        {
            if (selected.text.Equals("PLAY"))
            {
                SceneManager.LoadScene("Main");
            }
            else if (selected.text.Equals("EXIT"))
            {
                Application.Quit();
            }
        }

        lastxinput = horizontalAxis;
        lastyinput = verticalAxis;
        lastsubmit = submit;
    }

    public static int Mod(int x, int m)
    {
        return (x % m + m) % m;
    }
}
