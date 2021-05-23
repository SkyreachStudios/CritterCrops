using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip[] clips = new AudioClip[10];
    public AudioSource[] sources = new AudioSource[5];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(int clipIndex, int sourceIndex)
    {
        Debug.Log("Playing clip....");
        sources[sourceIndex].clip = clips[clipIndex];
        sources[sourceIndex].Play();
    }

    public void PlayRandomAudio(int clipFirstIndex, int clipLastIndex, int sourceIndex)
    {
        
        Debug.Log("Playing clip....");
        sources[sourceIndex].clip = clips[Random.Range(clipFirstIndex,clipLastIndex)];
        sources[sourceIndex].Play();
    }
}
