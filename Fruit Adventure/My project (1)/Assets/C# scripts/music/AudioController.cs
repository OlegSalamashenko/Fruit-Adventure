using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Sprite audioON;
    public Sprite audioOFF;
    public GameObject AudioButton;
    public GameObject ObjectMusic;
    private AudioSource audioSource;

    public Slider slider;

    private void Start()
    {
        ObjectMusic = GameObject.FindWithTag("Music");
        audioSource = ObjectMusic.GetComponent<AudioSource>();

        slider.value = audioSource.volume;
    }
    public void SetVolume(float vol)
    {
        audioSource.volume = vol;
    }

    public void OnOffAudio()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            AudioButton.GetComponent<Image>().sprite = audioOFF;
        }
        else
        {
            AudioListener.volume = 1;
            AudioButton.GetComponent<Image>().sprite = audioON;
        }
    }

}


