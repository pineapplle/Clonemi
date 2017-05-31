using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float OffsetScale;

    public void Move(float cameraStep)
    {
        transform.position -= new Vector3(OffsetScale * cameraStep, 0, 0);
    }
}
