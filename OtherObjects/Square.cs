using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour , IShapes
{
    [SerializeField] int _point;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public int point
    {
        get { return _point; }
        set { _point = value; }
    }
    public void ChangeVisibility()
    {
        PlayerScript.instance.PlayerScore += point;

    }
    public void AddPoints(int point)
    {
        gameObject.SetActive(false);

    }
    public void SetSizeOfElement()
    {
        gameObject.transform.localScale = new Vector3(Random.Range(0.5f, 3f), Random.Range(0.5f, 3f), Random.Range(0.5f, 3f));
        gameObject.transform.localPosition = new Vector3(Random.Range(-9, 9f), Random.Range(-4, 4f), Random.Range(-9, 9f));
    }
    public IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
    public void DanceAnimation(bool state)
    {
        animator.SetBool("dance", state);
    }
}
