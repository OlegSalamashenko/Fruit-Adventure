using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;

    public bool isMoving { private get; set; }
    public bool isFlying { private get; set; }

    public bool OnWall { private get; set; }
   

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _animator.SetBool("isMoving", isMoving);
        _animator.SetBool("isFlying", isFlying);
        _animator.SetBool("OnWall", OnWall);
       
    }

    public void Hit()
    {
        _animator.SetTrigger("Hit");
    }
    public void Jump()
    {
        if (_animator.GetBool("IsFlying") == false)
        {
            _animator.SetTrigger("Jump");
        }
    }
}
