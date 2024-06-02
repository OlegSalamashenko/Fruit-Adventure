using System;
using UnityEngine;

public class CharacterMoving : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector3 _groundCheckOffset;
    [SerializeField] private Vector3 _wallCheckDirection;

    [SerializeField] private LayerMask groundMask;

     public AudioClip[] footsteps;
     public AudioClip SourceHit; 
     public AudioClip SourceJump;
     public AudioClip SourceWall;
     public AudioClip SourceFinish;
     private AudioSource audioSourceLevel; 

     private Vector3 _input;
     private bool _isMoving;
     private bool _isGrounded ;
     private bool _OnWall;

     private Rigidbody2D _rigidbody;
     private CharacterAnimation _animation;
     [SerializeField] private SpriteRenderer _characterSprite;



     void Start()
     {
        audioSourceLevel = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animation = GetComponent<CharacterAnimation>();
     }

     void Update()
     {
         Move();
         CheckGround();
         CheckWall();
            if (Input.GetKeyDown(KeyCode.Space))
         {
           Jump();          
         }
        _animation.isMoving = _isMoving;
        _animation.OnWall = _OnWall;
        _animation.isFlying = IsFlying();
     }

     private void Move()
     {
         _input = new Vector2(Input.GetAxis("Horizontal"),0);

       
        transform.position += _input * _speed * Time.deltaTime;

         _isMoving = _input.x !=0 ? true : false;

         if (_isMoving)
         {
            _wallCheckDirection.x = _input.x > 0 ? 0.58f : -0.58f;
            _characterSprite.flipX = _input.x > 0 ? false : true;
         }
         

     }
     private void Jump() 
     {
         if (_isGrounded)
         {
             SoundJump();
             _rigidbody.AddForce(transform.up * _jumpForce);
             _animation.Jump();
         }
        else
        {
            if (_OnWall)
            {
                SoundWallJump();
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.AddForce(transform.up * _jumpForce / 100 - _wallCheckDirection * _jumpForce / 140, ForceMode2D.Impulse);
                _characterSprite.flipX = _wallCheckDirection.x > 0 ? true : false;
                _input = _wallCheckDirection * -1;
                _wallCheckDirection *= -1;
                _animation.Jump();
            }
        }




     }

     private void CheckGround() 
     {
         float rayLength = 0.3f;
         Vector3 rayStartPosition = transform.position + _groundCheckOffset;
         RaycastHit2D hit = Physics2D.Raycast(rayStartPosition,rayStartPosition + Vector3.down,rayLength, groundMask);


         if (hit.collider != null)
         {
             _isGrounded = hit.collider.CompareTag("Ground") ? true : false;
         }
         else
         {
             _isGrounded =false;
         }
     }
    private void CheckWall()
    {
        float rayLenght = 0.1f;
        Vector3 rayStartPosition = transform.position + _wallCheckDirection;
        RaycastHit2D wallhit = Physics2D.Raycast(rayStartPosition,rayStartPosition + _wallCheckDirection, rayLenght, groundMask);

        if(wallhit.collider != null && wallhit.collider.CompareTag("Ground"))
        {
            _OnWall = true;
            if (_rigidbody.velocity.y < 0)
            {
                _rigidbody.gravityScale = 0.1f;
                _rigidbody.mass = 0.5f;
            }
            else
            {
                _rigidbody.gravityScale = 5f;
                _rigidbody.mass = 5f;
            }
        }
    else
        {
            _OnWall = false;
            _rigidbody.gravityScale = 1;
            _rigidbody.mass = 1f;
        }

    }
    public void Knockback(Vector2 vector)
    {
        _rigidbody.velocity = Vector2.zero;
        float knockbackForce = 5f;
        _rigidbody.AddForce(vector * knockbackForce, ForceMode2D.Impulse);
    }
    public void SoundHit() 
    {
        audioSourceLevel.PlayOneShot(SourceHit);
    }
    public void SoundJump()
    {
        audioSourceLevel.PlayOneShot(SourceJump);
    }
    public void SoundFinish(float volume = 0.5f)
    {
        audioSourceLevel.PlayOneShot(SourceFinish, volume);
    }
    public void SoundWallJump()
    {
        audioSourceLevel.PlayOneShot(SourceWall);
    }
    public void FoodSteps()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(1, footsteps.Length);
        audioSourceLevel.PlayOneShot(footsteps[randomNumber]);
    }
    
    private bool IsFlying()
    {
        if (_rigidbody.velocity.y < 0)
        {
            return true;
        }
        else
        {

        }
        return false;
    }


}
