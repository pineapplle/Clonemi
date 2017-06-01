using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float Offsetpercent;

    public void Move(float cameraStep)
    {
        transform.position -= new Vector3(Offsetpercent * 0.01f * cameraStep, 0, 0);
    }
}
