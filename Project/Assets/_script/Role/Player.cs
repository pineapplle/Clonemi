using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Current;
    public bool AutoFly;
    public bool Dead;
    public Rigidbody2D _rigidbody2D;
    public float MoveSpeed = 4;
    public float JumpRange = 500;

    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private ParticleSystem _qipao;


    private void Awake()
    {
        Current = this;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    public void PlayFly()
    {
        if (_qipao != null && !_qipao.isPlaying)
        {
            _qipao.Play();
        }
    }

    public void PlayIdle()
    {
        if (_qipao != null)
        {
            _qipao.Stop();
        }
    }

    public void Move(Vector2 vector)
    {
        if (Dead)
        {
            return;
        }
        _animator.SetFloat("moveSpeed", Mathf.Abs(vector.magnitude));
        Vector3 v = vector;
        transform.position += v * MoveSpeed * Time.deltaTime;
        if (v.x * transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector3.up * JumpRange);
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
