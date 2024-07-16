using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public List<AudioClip> bink;
    public List<AudioSource> bonk;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAudio(int index)
    {
        foreach (var AudioSource in bonk)
        {
            if (AudioSource.isPlaying)
            {
                continue;
            }

            AudioSource.clip = bink[index];
            AudioSource.Play();
            
            break;
        }
    }
}
