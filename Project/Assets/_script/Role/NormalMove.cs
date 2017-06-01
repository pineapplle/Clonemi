using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMove : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private bool OnGrond;
    private Vector3 GroundNormal;


    void FixedUpdate()
    {
        if (player.Dead)
        {
            return;
        }
        CheckGround();
        var h = Input.GetAxis("Horizontal");
        //var v = Input.GetAxis("Vertical");
        player.Move(new Vector2(h, 0));

        if (Mathf.Abs(h) > float.Epsilon)
        {
            player.PlayFly();
        }
        else
        {
            player.PlayIdle();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OnGrond && !player.Dead)
            {
                player.Jump();
            }
        }
    }

    private void CheckGround()
    {
        var info = Physics2D.Raycast(transform.position, Vector2.down, 1.66f, LayerDefine.EvrMask);
        if (info.collider != null)
        {
            OnGrond = true;
            GroundNormal = info.normal;
        }
        else
        {
            OnGrond = false;
            GroundNormal = Vector3.up;
        }
    }
}
