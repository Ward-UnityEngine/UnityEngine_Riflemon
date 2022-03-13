using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginConditions
{
    private Vector2 beginPosition;
    private Vector2 beginDirection;
    private bool isInside;

    public BeginConditions(Vector2 beginPosition, Vector2 beginDirection,bool isInside)
    {
        this.beginPosition = beginPosition;
        this.isInside = isInside;
    }

    public Vector2 getBeginposition()
    {
        return beginPosition;
    }

    public Vector2 getBeginDirection()
    {
        return beginDirection;
    }

    public bool getIsInside()
    {
        return isInside;
    }
}
