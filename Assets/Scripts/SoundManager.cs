using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static private SoundManager _instance;
	static public SoundManager Instance { get { return _instance; } }
    public AudioClip GetPollen, SelectMenu, PlaceFlower;
    AudioSource audioSource;
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        //GetPollen = Resources.Load<AudioClip>("HarvestPollen");
        //SelectMenu = Resources.Load<AudioClip>("Select02");
        //PlaceFlower = Resources.Load<AudioClip>("Select01");

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void PlaySelectMenu()
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(SelectMenu);
    }
    public void PlayPlaceFlower()
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(PlaceFlower);
    }
    public void PlayGetPollen()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.loop = true;
            audioSource.clip = GetPollen;
            audioSource.Play();
        }
    }
    public void StopSound()
    {
        audioSource.Stop();
    }
}
