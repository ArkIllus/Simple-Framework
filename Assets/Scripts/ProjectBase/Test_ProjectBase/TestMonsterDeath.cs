using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonsterDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener<TestMonster>("MonsterDead", OtherWaitMonsterDeadDo);
        EventCenter.GetInstance().AddEventListener("Win", Win);
        EventCenter.GetInstance().EventTrigger("Win");
    }

    public void OtherWaitMonsterDeadDo(TestMonster info)
    {
        Debug.Log("������������Ҫ������");
    }
    public void Win()
    {

    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener<TestMonster>("MonsterDead", OtherWaitMonsterDeadDo);
    }
}
