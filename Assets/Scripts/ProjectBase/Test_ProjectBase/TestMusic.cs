using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMusic : MonoBehaviour
{
    float volume;
    GUIStyle s1;
    GUIStyle s2;
    AudioSource sound;

    private void OnGUI()
    {
        //---BGM---
        if (GUI.Button(new Rect(0,0,100,100), "Play BGM"))
        {
            MusicManager.GetInstance().PlayBGM("Unite In The Sky (short)");
            MusicManager.GetInstance().ChangeBGMVolume(0.1f);
        }

        if (GUI.Button(new Rect(0,100,100,100),"Pause BGM"))
        {
            MusicManager.GetInstance().PauseBGM();
        }

        if (GUI.Button(new Rect(0, 200, 100, 100), "Stop BGM"))
        {
            MusicManager.GetInstance().StopBGM();
        }

        //volume = GUI.Slider(new Rect(0, 300, 100, 50), volume, 1, 0, 1, s1, s2, true, 0);
        //MusicManager.GetInstance().ChangeBGMVolume(volume);


        //---Sound---
        if (GUI.Button(new Rect(0, 300, 100, 100), "Play Sound"))
        {
            MusicManager.GetInstance().PlaySound("can", isLoop: false, (s) =>
            {
                sound = s;
            });
        }
        if (GUI.Button(new Rect(0, 400, 100, 100), "Stop Sound"))
        {
            MusicManager.GetInstance().StopSound(sound);
            sound = null;
        }
    }
}
