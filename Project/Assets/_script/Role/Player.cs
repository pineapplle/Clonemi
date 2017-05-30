using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Current;
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
        var input = false;
        if (Input.GetKey(KeyCode.A))
        {
            Move(new Vector2(-1, 0));
            input = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(new Vector2(1, 0));
            input = true;
        }
        if (input)
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
        _animator.SetBool("fly", true);
        if (!_qipao.isPlaying)
        {
            _qipao.Play();
        }
    }

    public void PlayIdle()
    {
        _animator.SetBool("fly", false);
        _qipao.Stop();
    }

    public void Move(Vector2 vector)
    {
        if (Dead)
        {
            return;
        }
        var v = new Vector3(vector.x, vector.y, 0).normalized;
        v = Projector(v);
        transform.position += v * MoveSpeed * Time.deltaTime;
        if (v.x * transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

    }

    private Vector2 Projector(Vector2 vector)
    {
        var info = Physics2D.Raycast(transform.position, Vector2.down, 1.65f, LayerDefine.TerrainMask);
        if (info.collider != null)
        {
            return Vector3.ProjectOnPlane(vector, info.normal);
        }
        return vector;
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
        _animator.Play("idle", 0, 0);
    }

    public void Die()
    {
        _animator.SetTrigger("died");
        Dead = true;
        LevelMgr.Instance.LevelReload();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerDefine.Terrain)
        {
            OnGrond = true;
        }
    }
}
