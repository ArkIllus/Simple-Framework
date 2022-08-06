using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// �л�����
/// </summary>
public class SceneMgr : BaseManager<SceneMgr>
{
    public void LoadScene(string name, UnityAction fun)
    {
        // ����ͬ������
        SceneManager.LoadScene(name);
        //������ɹ��� �Ż�ִ��fun
        fun();
    }

    //�ṩ���ⲿ�� �첽���صĽӿڷ���
    public void LoadSceneAsync(string name, UnityAction fun)
    {
        // �����첽����
        // Ϊ�β�ֱ��SceneManager.LoadSceneAsync(name);???
        MonoManager.GetInstance().StartCoroutine(ReallyLoadSceneAsync(name, fun));
    }

    //Э���첽���س���
    private IEnumerator ReallyLoadSceneAsync(string name, UnityAction fun)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        while (!ao.isDone)
        {
            //������������½�����
            //ʹ���¼�����
            //EventCenter.GetInstance().EventTrigger("loading", ao.progress);
            yield return ao.progress;
        }
        yield return ao;

        //������ɹ��� �Ż�ִ��fun
        fun();
    }
}
