using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController current;
    void Awake()
    {
        current = this;
    }
    [SerializeField]
    private AudioSource swipeSource;
    [SerializeField]
    private AudioSource pick_upSource;


    void Start()
    {
    }

    public void PlaySwipeSound()
    {
        swipeSource.volume = PlayerPrefs.GetFloat("SaveVolume");
        swipeSource.Play();
    }

    public void PlayPickUpSound()
    {
        pick_upSource.volume = PlayerPrefs.GetFloat("SaveVolume");
        pick_upSource.Play();
    }
}
