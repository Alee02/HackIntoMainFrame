using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    int level;
    State gameState;
    string username;
    int category;
    int gameTimer;
    Boolean isWinner = false;

    enum State
    {
        Login,
        Menu,
        Category,
        Game,
        Won,
        Lost
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

    string CreateAnagram(string word)
    {
        if (word.Length > 0)
        {
            char[] charArray = word.ToLower().ToCharArray();
            for (int t = 0; t < charArray.Length; t++)
            {
                char temp = charArray[t];
                int r = UnityEngine.Random.Range(t, charArray.Length);
                charArray[t] = charArray[r];
                charArray[r] = temp;
            }
            return string.Join("", charArray);
        }
        else
        {
            throw new ArgumentException("Word needs to have a lenght of more than 1");
        }
    }

    void StartGame(string secretWord)
    {
        gameState = State.Game;
        Terminal.ClearScreen();
        Terminal.WriteLine("Top Secret Documents");
        Terminal.WriteLine("Codeword: " + secretWord);
        Terminal.WriteLine("Enter password to download");
    }

    void ShowCategoryScreen()
    {
        gameState = State.Category;
        Terminal.ClearScreen();
        Terminal.WriteLine("Choose your target...");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
    }

    void OnUserInput(string input)
    {
        print(gameState);
        if (gameState == State.Login)
        {
            // Login Screen
            if (input.Length > 0)
            {
                print("User input");
                print("We in login state and setting stuff");
                username = input;
                showMainMenu(username);
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
                    ShowCategoryScreen();
                }
            }
        } else if (gameState == State.Category)
        {
            if (input.Length > 0)
            {
                string secretWord = CreateAnagram("mainframe");
                StartGame(secretWord);
            }
        }
        else if (gameState == State.Game){
           if(input == "mainframe")
            {
                Terminal.WriteLine("You hacked into the mainframe");
                isWinner = true;
                gameState = State.Won;
            } else
            {
                Terminal.WriteLine("Oh no, the cops caught you!");
                gameState = State.Lost;
                
            }
        }
        else if (gameState == State.Won)
        {
            gameState = State.Menu;
        } else if (gameState == State.Lost)
        {
            string secretWord = CreateAnagram("Astrnaut");
            Terminal.WriteLine("You can't type from a jail cell");
            StartGame(secretWord);
        }
    }
}