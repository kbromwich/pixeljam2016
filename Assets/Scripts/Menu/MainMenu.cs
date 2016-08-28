using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public const int MaxPlayers = 12;
    public static int NumPlayers = 2;

    public TextMesh[] menuItems;
    public TextMesh playerNumText;
    
    public AudioSource menuItemChange;
    public AudioSource menuItemSelect;
    
    int selectedIndex = 0;
    int xinput = 0;
    int yinput = 0;
    bool submit = false;
    float lastxinput = 0;
    float lastyinput = 0;
    bool lastsubmit = false;

    // Use this for initialization
    void Start () {
        playerNumText.text = "<" + NumPlayers + ">";
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

        UpdateSelectedMenuItem();
        UpdateSliderItem();
        UpdateSubmit();

        lastxinput = horizontalAxis;
        lastyinput = verticalAxis;
        lastsubmit = submit;
    }

    void UpdateSelectedMenuItem()
    {
        selectedIndex = Mod(selectedIndex - yinput, menuItems.Length);
        submit = !lastsubmit && Input.GetButtonDown("Submit");

        for (int i = 0; i < menuItems.Length; i++)
        {
            menuItems[i].color = Color.white;
        }

        if (yinput != 0)
        {
            menuItemChange.Play();
        }

        var selected = menuItems[selectedIndex];
        selected.color = Color.green;
    }

    void UpdateSliderItem()
    {
        var selected = menuItems[selectedIndex];
        if (selected.text.StartsWith("PLAYERS"))
        {
            NumPlayers = Mod(NumPlayers - 1 + xinput, MaxPlayers) + 1;
            playerNumText.text = "<" + NumPlayers + ">";
            if (xinput != 0)
            {
                menuItemChange.Play();
            }
        }
    }

    void UpdateSubmit()
    {
        var selected = menuItems[selectedIndex];
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
    }


    public static int Mod(int x, int m)
    {
        return (x % m + m) % m;
    }
}
