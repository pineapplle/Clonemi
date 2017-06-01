using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Current;
    public bool AutoFly;
    [SerializeField]
    private float MoveSpeed = 4;
    [SerializeField]
    private float JumpRange = 500;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private ParticleSystem _qipao;

    private bool OnGrond;
    private Vector3 GroundNormal;
    private bool Dead;

    private void Awake()
    {
        Current = this;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (Dead)
        {
            return;
        }
        CheckGround();
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        _animator.SetFloat("moveSpeed", Mathf.Abs(h));
        if (AutoFly)
        {
            Move(h, v);
        }
        else
        {
            Move(h, 0);
        }
        if (Mathf.Abs(h) > float.Epsilon || Mathf.Abs(v) > float.Epsilon)
        {
            PlayFly();
        }
        else
        {
            PlayIdle();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void PlayFly()
    {
        if (!_qipao.isPlaying)
        {
            _qipao.Play();
        }
    }

    public void PlayIdle()
    {
        _qipao.Stop();
    }

    public void Move(float x, float y)
    {
        if (Dead)
        {
            return;
        }
        var v = new Vector3(x, y, 0).normalized;
        v = Vector3.ProjectOnPlane(v, GroundNormal);
        transform.position += v * MoveSpeed * Time.deltaTime;
        if (v.x * transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void CheckGround()
    {
        var info = Physics2D.Raycast(transform.position, Vector2.down, 1.66f, LayerDefine.TerrainMask);
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

    public void Jump()
    {
        if (OnGrond && !Dead)
        {
            _rigidbody2D.AddForce(Vector3.up * JumpRange);
            OnGrond = false;
        }
    }

    public void Reborn()
    {
        Dead = false;
        _animator.Play("Blend Tree", 0, 0);
    }

    public void Die()
    {
        _animator.SetTrigger("died");
        Dead = true;
        LevelMgr.Instance.LevelReload();
    }
}
