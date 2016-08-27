using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int NumPlayers = 2;
    public static int NumBots = 2;


    List<MenuItem> menuOptions = new List<MenuItem>();
    int selectedIndex = 0;
    int xinput = 0;
    int yinput = 0;
    bool submit = false;
    float lastxinput = 0;
    float lastyinput = 0;
    bool lastsubmit = false;

    MenuItem players;
    MenuItem bots;

    // Use this for initialization
    void Start()
    {
        var play = new MenuItem("Play");
        play.action = Play;

        players = new MenuItem("Players");
        for (int i = 1; i <= 5; i++) {
            var opt = new MenuOption(i.ToString());
            players.options.Add(opt);
        }

        bots = new MenuItem("Bots");
        for (int i = 1; i <= 5; i++)
        {
            var opt = new MenuOption(i.ToString());
            bots.options.Add(opt);
        }

        var exit = new MenuItem("Exit");
        exit.action = Exit;

        menuOptions.Add(play);
        menuOptions.Add(players);
        menuOptions.Add(bots);
        menuOptions.Add(exit);
    }

    void Update()
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

        selectedIndex = Mod(selectedIndex - yinput, menuOptions.Count);
        submit = !lastsubmit && Input.GetButtonDown("Submit");

        menuOptions[selectedIndex].Update(xinput);

        lastxinput = horizontalAxis;
        lastyinput = verticalAxis;
        lastsubmit = submit;
    }

    void Play()
    {
        print("Play!");
        NumPlayers = int.Parse(players.SelectedOption());
        NumBots = int.Parse(bots.SelectedOption());

        print("Loading scene Main");
        SceneManager.LoadScene("Main");
    }

    void Exit()
    {
        print("Exit!");
        Application.Quit();
    }

    void OnGUI()
    {
        int y = 100;

        for (int i = 0; i < menuOptions.Count; i++)
        {
            var option = menuOptions[i];
            option.Draw(y, i == selectedIndex, submit);
            y += 30;
        }
    }

    public static int Mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    class MenuItem
    {
        public string name = "Lalala";
        public Action action = null;
        public int selectedOption = 0;
        public List<MenuOption> options = new List<MenuOption>();

        public MenuItem(string name)
        {
            this.name = name;
        }

        public void Update(int xinput)
        {
            if (options.Count > 0)
            {
                selectedOption = Mod(selectedOption + xinput, options.Count);
            }
        }

        public void Draw(int y, bool selected, bool submit)
        {
            GUI.SetNextControlName(name);

            bool clicked = false;
            //if (action != null) {
                clicked = GUI.Button(new Rect(10, y, 200, 30), name);
            //}
            //else
            //{
                //GUI.Label(new Rect(10, y, 200, 30), name);
            //}

            if (clicked || selected)
            {
                GUI.FocusControl(name);
                if (submit || clicked)
                {
                    if (action != null)
                    {
                        action.Invoke();
                    }
                }
            }

            if (options.Count > 0)
            {
                options[selectedOption].Draw(y);
            }
        }

        public string SelectedOption()
        {
            return options[selectedOption].name;
        }
    }

    class MenuOption
    {
        public string name = "opt";

        public MenuOption(string name)
        {
            this.name = name;
        }

        public void Draw(int y)
        {
            GUI.Label(new Rect(250, y, 200, 30), name);
        }
    }
}
