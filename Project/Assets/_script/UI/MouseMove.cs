using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public MouseOffset[] MouseOffsets;
    private readonly Vector3 _zero = new Vector3(1920 / 2f, 1080 / 2f, 0);
    void Update()
    {
        var offset = Input.mousePosition - _zero;
        MoveOffset(offset.x, offset.y);
        print(offset);
    }

    private void MoveOffset(float x, float y)
    {
        if (MouseOffsets == null) return;
        foreach (var mouseOffset in MouseOffsets)
        {
            mouseOffset.Offset(x, y);
        }
    }
}
