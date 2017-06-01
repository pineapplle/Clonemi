using UnityEngine;

public class AutoFly : MonoBehaviour
{
    [SerializeField]
    private Player player;
    void Awake()
    {
        player._rigidbody2D.gravityScale = 0;
        player.PlayFly();
    }

    void FixedUpdate()
    {
        if (player.Dead)
        {
            return;
        }
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        player.Move(new Vector2(h, v));
    }
}
