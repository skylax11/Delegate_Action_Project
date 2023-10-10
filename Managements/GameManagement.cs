using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScore;
    public GameObject LostGame;
    void Start()
    {
        SetVisibleRandom();
    }
    public void SetVisibleRandom()
    {
        int random = UnityEngine.Random.Range(0, gameObjects.Length);

        gameObjects[random].SetActive(true);
    }
    public void AddAction(Action theAction)
    {
        theAction += SetVisibleRandom;
        theAction.Invoke();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOver(int score)
    {
        endScore.text = score.ToString();
        LostGame.SetActive(true);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = "New Score:"+ "  " + score.ToString();
    }
}
