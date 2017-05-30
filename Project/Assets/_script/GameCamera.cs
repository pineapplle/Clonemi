using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public FollowCamera[] FollowCameras;
    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        var pos = Player.Current.transform.position;
        var level = LevelMgr.Instance.CurrentLevel;
        var diff = pos.x - transform.position.x;
        if (diff > 0.001 && pos.x < level.Upperlimit)
        {
            MoveCamera(diff);
        }
        else if (pos.x > level.Lowerlimit && diff < -0.001)
        {
            MoveCamera(diff);
        }
    }

    private void MoveCamera(float diff)
    {
        transform.position += new Vector3(diff, 0, 0);
        OffsetCamera(diff);
    }

    private void OffsetCamera(float diff)
    {
        if(FollowCameras == null)return;
        foreach (var followCamera in FollowCameras)
        {
            followCamera.Move(diff);
        }
    }
}
