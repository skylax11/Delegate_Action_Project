using Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public UnityEvent<bool> DoDanceEvent;
    public Func<PlayerDatas> Players;
    public PlayerDatas playerDatas;

    public static MenuManager instance;

    public TextMeshProUGUI[] scores;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
    }
    private void Start()
    {
       playerDatas = new PlayerDatas();
    }
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            DoDanceEvent.Invoke(true);
        }
        else
        {
            DoDanceEvent.Invoke(false);
        }
    }
    public void AssignName(string name)
    {
        playerDatas.name = name;
    }
    public void StartGame()
    {
        print(playerDatas.name);
        SceneManager.LoadScene(1);
    }
    public void DisplayLeaderboard()
    {
        List<PlayerDatas> list = database.instance.PlayerDataList;
        list = list.OrderByDescending(x=>x.score).ToList();
        for (int i = 0; i < list.Count; i++)
        {
            scores[i].text = list[i].name + " " + list[i].score;
        }
    }
}
