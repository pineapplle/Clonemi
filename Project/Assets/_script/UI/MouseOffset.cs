using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOffset : MonoBehaviour
{
    public float OffsetScale = 1;
    public void Offset(float x, float y)
    {
        var offset = new Vector3(x, y, 0);
        transform.localPosition = offset * OffsetScale / 100;
    }
}
