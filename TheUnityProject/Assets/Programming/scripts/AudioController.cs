using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public List<AudioClip> bink;
    public List<AudioSource> bonk;
    
    

    public void playAudio(int index)
    {
        foreach (var AudioSource in bonk)
        {
            if (AudioSource.isPlaying)
            {
                if (AudioSource.clip == bink[index] && AudioSource.clip != bink[0])
                {
                    break;
                }
                continue;   
            }

            AudioSource.clip = bink[index];
            AudioSource.Play();
            
            break;
        }
    }
    public void stopAudio(int index)
    {
        foreach (var AudioSource in bonk)
        {
            if (!AudioSource.isPlaying)
            {
                continue;   
            }
            else if (AudioSource.isPlaying && AudioSource.clip == bink[index])
            {
                AudioSource.Stop();
                break;
            }

        }
    }
}
