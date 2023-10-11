using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] Color[] color;
    [SerializeField] PlayerScript playerScript;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI endScore;
    public GameObject LostGame;

    void Start()
    {
        SetVisibleRandom();
    }
    private void Update()
    {
        timeText.text = "Time :" + ((int)playerScript.time+1).ToString();
    }
    public void SetVisibleRandom()
    {
        int GameObjectRandom = UnityEngine.Random.Range(0, gameObjects.Length);
        int ColorRandom = UnityEngine.Random.Range(0, color.Length);
        gameObjects[GameObjectRandom].GetComponent<SpriteRenderer>().color = color[ColorRandom];
        gameObjects[GameObjectRandom].SetActive(true);
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
