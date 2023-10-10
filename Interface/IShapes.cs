using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShapes
{
    public int point { get; set; }
    public void AddPoints(int point);
    public void ChangeVisibility();
    public void SetSizeOfElement();
    public void DanceAnimation(bool state);
   
}
