using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    State gameState;
    string username;

    enum State
    {
        Login,
        Menu,
        Category,
        Game,
        Idle
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = State.Login;
        loginScreen();
    }

    void startGame()
    {
        Terminal.WriteLine("Game started");
        if (level == 1)
        {
            startLevel1();
        }
        else
        {
            Terminal.WriteLine("You didn't pick level 1");
        }

    }

    void startLevel1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Level 1 Started");
    }

    void loginScreen()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("-------------------Login---------------");
        Terminal.WriteLine("               Enter Username");
    }

    void showMainMenu(string greeting)
    {
        gameState = State.Menu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + greeting);
        Terminal.WriteLine("Welcome to Hack into mainframe");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Variables");
        Terminal.WriteLine("Press 2 for Main Frame");
    }

    void StartGame()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + level);
    }

    void showCategoryScreen()
    {
        gameState = State.Category;
        Terminal.ClearScreen();
        Terminal.WriteLine("Choose your target...");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
    }

    void OnUserInput(string input)
    {
        print("Enter was pressed");
        print(gameState);
        if (gameState == State.Login)
        {
            // Login Screen
            print("Login screen");
            if (input.Length > 0)
            {
                print("User input");
                print("We in login state and setting stuff");
                username = input;
                showMainMenu(username);
            }
            else
            {
                print("User input none");
            }
        }
        else if (gameState == State.Menu)
        {
            if (input.Length > 0)
            {
                var x = 0;
                if (int.TryParse(input, out x))
                {
                    level = x;
                    showCategoryScreen();
                }
            }
        } else if (gameState == State.Category)
        {
            if (input.Length > 0)
            {
                StartGame();
            } else
            {

            }
        }
        else
        {
            print("Idk what happend");
        }
    }
}
