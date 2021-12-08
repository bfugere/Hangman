using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text timeField;
    [SerializeField] Text wordToFindField;

    float time;
    string[] testWords = { "DOG", "BIRD", "MOUSE", "BIG DOG"};
    string chosenWord;
    string hiddenWord;

    void Start()
    {
        chosenWord = testWords[Random.Range(0, testWords.Length)];

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
            Debug.Log(pressedLetter + " was pressed.");

            if (chosenWord.Contains(pressedLetter))
            {
                
            }
            else
            {

            }
        }
    }
}
