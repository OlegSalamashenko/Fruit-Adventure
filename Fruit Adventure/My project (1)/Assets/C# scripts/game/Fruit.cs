using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffect;
    [field: SerializeField] public int Points { get; private set; }

    private GameObject player;

    private AudioSource audioSource;

    public AudioClip audioClip;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
    }
    public void Destroy()
    {
        
        if (_destroyEffect != null)
        {
            audioSource.PlayOneShot(audioClip);
            GameObject effect = Instantiate(_destroyEffect, transform.position, transform.rotation);
            Destroy(effect, 0.3f); 
        }
        
        Destroy(gameObject);
    }
}
