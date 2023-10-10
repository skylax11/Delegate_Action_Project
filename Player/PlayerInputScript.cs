using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    public void OnClick(InputValue value)
    {
        print(value.Get<Vector2>());
        if(!(value.Get<Vector2>() == Vector2.zero))
        PlayerScript.instance.OnClickEvent();
    }
}
