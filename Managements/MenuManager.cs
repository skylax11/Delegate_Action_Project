using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public UnityEvent<bool> DoDanceEvent;

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
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
