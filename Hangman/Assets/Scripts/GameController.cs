using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text timeField;
    [SerializeField] Text wordToFindField;

    float time;
    string[] testWords = { "DOG", "BIRD", "MOUSE" };
    string chosenWord;
    string hiddenWord;

    void Start()
    {
        chosenWord = testWords[Random.Range(0, testWords.Length)];
        Debug.Log(chosenWord);
    }

    void Update()
    {
        time += Time.deltaTime;

        float minutes = Mathf.FloorToInt(time / 60f);
        float seconds = Mathf.FloorToInt(time % 60f);

        timeField.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
