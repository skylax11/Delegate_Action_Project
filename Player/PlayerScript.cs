using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour 
{
    [SerializeField] GameManagement gameManagement;

    public static PlayerScript instance;

    public delegate void ShapeScoreFunctions(int score);  // same with --> public Action<int> ShapeScoreFunctions 

    public event ShapeScoreFunctions ShapeScore;
    public Action ShapeActions;
    

    IShapes shape;
    public int PlayerScore;
    public int remainingHealth = 3;

    private float time = 3f;

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
    private void Update()
    {
        if (time >= 0.1f)
        {
            time -= Time.deltaTime;
        }
        else if(time < 0.1f)
        {
            GameOver();
        }
    }
    public void OnClickEvent()
    {
        if (remainingHealth > 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            print(hit.collider);
            if (hit.collider != null && hit.transform.TryGetComponent(out IShapes shape))
            {
                time = 3f;
                this.shape = shape;

                if (hit.transform.GetComponent<SpriteRenderer>().material.color == Color.red)
                {
                    GameOver();
                }
                ShapeScore += this.shape.AddPoints;
                ShapeActions += this.shape.ChangeVisibility;       // adding functions through delegate
                ShapeActions += this.shape.SetSizeOfElement;

                ShapeScore.Invoke(this.shape.point);
                gameManagement.AddAction(ShapeActions);    // sending local Action to GameManagement to add other methods and Invoke them.

                ShapeScore = null;
                ShapeActions = null;     // removing them to prevent encountering any bugs (if we dont, functions will be called multiple times)
                gameManagement.UpdateScore(PlayerScore);  // updating score
            }
            else
            {
                remainingHealth--;
                if (remainingHealth == 0 || time < 0.1f)
                {
                    GameOver();
                }
            }
        }
    }
    public void GameOver()
    {
        MenuManager.instance.playerDatas.score = PlayerScore;
        database.instance.Save(MenuManager.instance.playerDatas);
        gameManagement.GameOver(PlayerScore);
    }
}
