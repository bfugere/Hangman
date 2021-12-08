using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameController : MonoBehaviour
{
    [SerializeField] Text timeField;
    [SerializeField] Text wordToFindField;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    [SerializeField] GameObject replayButton;
    [SerializeField] GameObject[] hangman;

    float time;
    string[] words = File.ReadAllLines(@"Assets/Words/Words.txt");
    string chosenWord;
    string hiddenWord;
    int failedGuesses;
    bool gameOver = false;

    void Start()
    {
        chosenWord = words[Random.Range(0, words.Length)];
        Debug.Log(chosenWord);

        for (int i = 0; i < chosenWord.Length; i++)
        {
            char letter = chosenWord[i];
            if (char.IsWhiteSpace(letter))
                hiddenWord += " ";
            else
                hiddenWord += "_";
        }

        wordToFindField.text = hiddenWord;
    }

    void Update()
    {
        if (gameOver == false)
            Timer();
    }

    void Timer()
    {
        time += Time.deltaTime;

        float minutes = Mathf.FloorToInt(time / 60f);
        float seconds = Mathf.FloorToInt(time % 60f);

        timeField.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnGUI()
    {
        Event e = Event.current;

        if (e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1)
        {
            string pressedLetter = e.keyCode.ToString();

            if (chosenWord.Contains(pressedLetter))
            {
                int i = chosenWord.IndexOf(pressedLetter);
                while (i != -1)
                {
                    hiddenWord = hiddenWord.Substring(0, i) + pressedLetter + hiddenWord.Substring(i + 1);
                    chosenWord = chosenWord.Substring(0, i) +      "_"      + chosenWord.Substring(i + 1);

                    i = chosenWord.IndexOf(pressedLetter);
                }

                wordToFindField.text = hiddenWord;
            }
            else
            {
                if (failedGuesses < hangman.Length)
                {
                    hangman[failedGuesses].SetActive(true);
                    failedGuesses++;
                }
            }

            if (failedGuesses == hangman.Length)
            {
                loseText.SetActive(true);
                replayButton.SetActive(true);
                gameOver = true;
            }

            if (!hiddenWord.Contains("_") && !gameOver)
            {
                winText.SetActive(true);
                replayButton.SetActive(true);
                gameOver = true;
            }
        }
    }
}
