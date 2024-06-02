using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvents : MonoBehaviour
{
    [SerializeField] private float _invulnerabilityTime; 

    private float _currentInvulnerabilityTime; 

    private CharacterMoving _movement;
    private CharacterAnimation _animations;
    private CharacterInfo _info;
    void Start()
    {
        _info = FindObjectOfType<CharacterInfo>();
        _movement = GetComponent<CharacterMoving>();
        _animations = GetComponent<CharacterAnimation>();
    }

    void Update()
    {
        if (_currentInvulnerabilityTime > 0)
        {
            _currentInvulnerabilityTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Fruit>(out Fruit fruit))
        {
            fruit.Destroy();
            _info.AddScore(fruit.Points);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            if (_currentInvulnerabilityTime <= 0)
            {
                
                Vector2 difference = transform.position - collision.transform.position;
                _movement.Knockback(difference.normalized);
                _animations.Hit();
                _currentInvulnerabilityTime = _invulnerabilityTime;
                _info.AddScore(0,5);
            }
        }
    }

}
