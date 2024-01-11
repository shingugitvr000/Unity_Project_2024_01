using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public void PlayBGM(string name)
    {
        AudioManager.instance.PlayMusic(name);
    }
    public void PlaySFX(string name)
    {
        AudioManager.instance.PlaySFX(name);
    }
}
