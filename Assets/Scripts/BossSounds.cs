using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSounds : MonoBehaviour {

    //Потрібно для того, щоб можна було помістити якийсь із кліпів
    private AudioSource source;

    public AudioClip[] clips;

    public float timeBetweenSoundEffects;
    private float nextSoundEffectTime;


    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.time >= nextSoundEffectTime)
        {
            int randomNumber = Random.Range(0, clips.Length);
            source.clip = clips[randomNumber];
            source.Play();
            nextSoundEffectTime = Time.time + timeBetweenSoundEffects;
        }

       
    }

}
