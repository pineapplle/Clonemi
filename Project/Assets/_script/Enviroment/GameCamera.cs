using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public static GameCamera Instance;
    public FollowCamera[] FollowCameras;
    [SerializeField]
    private bool HorizontalFollow;

    private void Awake()
    {
        Instance = this;
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    public void ResetToPlayer()
    {
        if (HorizontalFollow)
        {
            var x = Player.Current.transform.position.x;
            var level = LevelMgr.Instance.CurrentLevel;
            x = Mathf.Clamp(x, level.Lowerlimit, level.Upperlimit);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
        else
        {
            var y = Player.Current.transform.position.y;
            var level = LevelMgr.Instance.CurrentLevel;
            y = Mathf.Clamp(y, level.Lowerlimit, level.Upperlimit);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

    }

    private void FollowPlayer()
    {
        var pos = Player.Current.transform.position;
        var level = LevelMgr.Instance.CurrentLevel;
        if (HorizontalFollow)
        {
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
        else
        {
            var diff = pos.y - transform.position.y;
            if (diff > 0.001 && pos.y < level.Upperlimit)
            {
                MoveCamera(diff);
            }
            else if (pos.y > level.Lowerlimit && diff < -0.001)
            {
                MoveCamera(diff);
            }
        }
    }

    private void MoveCamera(float diff)
    {
        if (HorizontalFollow)
        {
            transform.position += new Vector3(diff, 0, 0);
            OffsetCamera(diff);
        }
        else
        {
            transform.position += new Vector3(0, diff, 0);
        }
    }

    private void OffsetCamera(float diff)
    {
        if (FollowCameras == null) return;
        foreach (var followCamera in FollowCameras)
        {
            followCamera.Move(diff);
        }
    }
}
