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
    int gameTries = 5;
    string secretWord = "";
    string[] nasa = { "Absolute Humidity", "Absorption","Acid Rain","Afforestation","Albedo","Algorithm" };

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
        Terminal.WriteLine("Choose your target (difficulty)...");
        Terminal.WriteLine("Press 1 for nasa");
    }

    void OnUserInput(string input)
    {
        if(gameTries > 0)
        {
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
            }
            else if (gameState == State.Category)
            {
                if (input.Length > 0)
                {
                    secretWord = CreateAnagram(nasa[UnityEngine.Random.Range(0, nasa.Length)]);
                    string codedSecretWord = CreateAnagram(secretWord);
                    StartGame(codedSecretWord);
                }
            }
            else if (gameState == State.Game)
            {
                if (nasa (secretWord))
                {
                    Terminal.WriteLine("You hacked into the mainframe");
                    Terminal.WriteLine("Welcome to Nasa");
                    Terminal.WriteLine(@"
 _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
                       
                       
");
                    isWinner = true;
                }
                else
                {
                    Terminal.WriteLine("Not quite it, Try Again");
                    gameTries--;
                }
            } else if (gameState == State.Game && isWinner)
            {
                Terminal.WriteLine("You've have retrieved a ");
            }
        } else
        {
            Terminal.WriteLine("Oh no, the cops caught you!");
            Terminal.WriteLine("Type breakout to start again.");
        }
    }
}