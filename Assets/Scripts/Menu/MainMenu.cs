using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MainMenu : MonoBehaviour
{
    List<KeyValuePair<string, Action>> menuOptions = new List<KeyValuePair<string, Action>>();
    int selectedIndex = 0;
    bool lastFrameInput = false;
    bool submit = false;

    // Use this for initialization
    void Start()
    {
        menuOptions.Add(new KeyValuePair<string, Action>("Play", Play));
        menuOptions.Add(new KeyValuePair<string, Action>("Stuff", Stuff));
        menuOptions.Add(new KeyValuePair<string, Action>("Exit", Exit));
    }

    void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");

        if (verticalAxis < 0 && !lastFrameInput)
        {
            selectedIndex += 1;
        }
        else if (verticalAxis > 0 && !lastFrameInput)
        {
            selectedIndex -= 1;
        }

        if (selectedIndex < 0)
        {
            selectedIndex = menuOptions.Count - 1;
        }
        else if (selectedIndex >= menuOptions.Count)
        {
            selectedIndex = 0;
        }

        submit = Input.GetButtonDown("Submit");
        lastFrameInput = verticalAxis != 0;
    }

    void Play()
    {
        print("Play!");
    }

    void Stuff()
    {
        print("Stuff!");
    }

    void Exit()
    {
        print("Exit!");
    }

    void OnGUI()
    {
        int y = 100;

        for (int i = 0; i < menuOptions.Count; i++)
        {
            var option = menuOptions[i];
            GUI.SetNextControlName(option.Key);
            GUI.Button(new Rect(10, y, 200, 30), option.Key);
            if (i == selectedIndex)
            {
                GUI.FocusControl(option.Key);
                if (submit)
                {
                    option.Value();
                }
            }
            y += 30;
        }
    }
}
