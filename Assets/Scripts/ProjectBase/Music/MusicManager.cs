using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicManager : BaseManager<MusicManager>
{
    //�ļ�·��
    public static string path_BGM = "Music/BGM/";
    public static string path_Sound = "Music/Sound/";

    //BGM
    private AudioSource bgm = null;
    private float bgmVolume = 1;

    //����������Ч
    //[ע]Ŀǰ��Ч������һ��soundObj�£������Ƿ���������GameObject�£�
    //û�о������֣����ʺ�3D��Ϸ
    private GameObject soundObj = null;
    private List<AudioSource> soundList = new List<AudioSource>();
    private float soundVolume = 1;

    public MusicManager()
    {
        MonoManager.GetInstance().AddUpdateListener(Update);
    }

    //��һ��AudioSource�������ˣ������Ƴ���
    //[ע]Unity�����Զ��Ƴ��������AudioSource������û���ṩһ��AudioSource������ִ�еĻص�������
    //����ֻ����Update�������Ƿ񲥷����ˣ�����
    private void Update()
    {
        for(int i = soundList.Count - 1; i >= 0; --i)
        {
            if (!soundList[i].isPlaying)
            {
                GameObject.Destroy(soundList[i]);
                soundList.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// ���ű�������
    /// </summary>
    /// <param name="name"></param>
    public void PlayBGM(string name)
    {
        if (bgm == null)
        {
            GameObject obj = new GameObject();
            obj.name = "BGM";
            bgm = obj.AddComponent<AudioSource>();
        }
        //�첽����BGM��������ɺ� ����
        ResourceManager.GetInstance().LoadAsync<AudioClip>(path_BGM + name, (clip) =>
        {
            bgm.clip = clip;
            bgm.volume = bgmVolume;
            bgm.loop = true; //Ĭ��ѭ������
            bgm.Play();
        });
    }
    /// <summary>
    /// ��ͣ��������
    /// </summary>
    public void PauseBGM()
    {
        if (bgm == null)
            return;
        bgm.Pause();
    }
    /// <summary>
    /// ֹͣ��������
    /// </summary>
    public void StopBGM()
    {
        if (bgm == null)
            return;
        bgm.Stop();
    }
    /// <summary>
    /// �ı䱳������ ������С
    /// </summary>
    /// <param name="vol"></param>
    public void ChangeBGMVolume(float vol)
    {
        bgmVolume = vol;
        if (bgm == null)
            return;
        bgm.volume = bgmVolume;
    }

    /// <summary>
    /// ������Ч
    /// </summary>
    /// <param name="name"></param>
    /// <param name="callBack">���ڰ����sound����ȥ</param>
    public void PlaySound(string name, bool isLoop, UnityAction<AudioSource> callBack = null)
    {
        if (soundObj == null)
        {
            soundObj = new GameObject();
            soundObj.name = "Sound";
        }
        //�첽������Ч��Դ��������ɺ� ��� ����
        ResourceManager.GetInstance().LoadAsync<AudioClip>(path_Sound + name, (clip) =>
        {
            AudioSource sound = soundObj.AddComponent<AudioSource>();
            sound.clip = clip;
            sound.loop = isLoop; //Ĭ�ϲ�ѭ������
            sound.volume = bgmVolume;
            sound.Play();
            soundList.Add(sound);

            if (callBack != null)
                callBack(sound);
        });
    }
    /// <summary>
    /// ֹͣ��Ч
    /// </summary>
    /// <param name="name"></param>
    public void StopSound(AudioSource audioSource)
    {
        if (soundList.Contains(audioSource))
        {
            soundList.Remove(audioSource);
            audioSource.Stop();
            GameObject.Destroy(audioSource); //TODO:�Ż� �����
        }
    }
    /// <summary>
    /// �ı䣨���У���Ч ������С
    /// </summary>
    /// <param name="vol"></param>
    public void ChangeSoundVolume(float vol)
    {
        soundVolume = vol;
        foreach (var sound in soundList)
        {
            sound.volume = vol;
        }
    }
}
