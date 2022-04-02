using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundController : MonoBehaviour
{
    public AudioClip t1;//pipe1
    public AudioClip t2;//pipe2
    public AudioClip t3;//start
    public AudioClip t4;//end
    public AudioClip t5;//arrow
    public AudioClip t6;//grab
    public AudioClip t7;//button
    public AudioClip t8;//yellowLight
    public AudioClip t9;//redLight
    public AudioClip t10;//failLight
    public AudioClip t11;//doctor
    public AudioClip t12;//music

    private AudioSource R, L;
    public float volume;
    AudioSource Audio;
    void Start()
    {
        R = GameObject.Find("speakerR").GetComponent<AudioSource>();
        L = GameObject.Find("speakerL").GetComponent<AudioSource>();
    }

        public void StopSound()
    {
        AudioSource R = GameObject.Find("speakerR").GetComponent<AudioSource>();
        R.Stop();
    }

    public void StopMusic()
    {
        AudioSource L = GameObject.Find("speakerL").GetComponent<AudioSource>();
        L.Stop();
    }

    public void PlaySound(int index)
    {
        PlaySound(index, true);
    }

    public void PlayMusic(int index)
    {
        PlaySound(index, false);
    }



    public void PlaySound(int index,bool priorit)
    {
       

        if (index == 1)
        {
            R.clip = t1;
            //L.clip = t1;
        }
        else if(index == 2)
        { 
            R.clip = t2;
            //L.clip = t2;
        }
        else if(index == 3)
        {
            R.clip = t3;
            //L.clip = t3;
        }
        else if(index == 4)
        {
            R.clip = t4;
            //L.clip = t4;
        }
        else if(index == 5)
        {
            R.clip = t5;
            //L.clip = t5;
        }
        else if(index == 6)
        {
            R.clip = t6;
            L.clip = t6;
        }
        else if (index == 7)
        {
            R.clip = t7;
            //L.clip = t7;
        }
        else if (index == 8)
        {
            //R.clip = t8;
            L.clip = t8;
        }
        else if (index == 9)
        {
            //R.clip = t9;
            L.clip = t9;
        }
        else if (index == 10)
        {
            R.clip = t10;
            //L.clip = t10;
        }
        else if (index == 11)
        {
            R.clip = t11;
            //L.clip = t11;
        }
        else if (index == 12)
        {
            //R.clip = t12;
            L.clip = t12;
        }

        R.volume = volume;
        L.volume = volume;

        if(priorit)
            R.Play();
        else
            L.Play();
    }
   
}