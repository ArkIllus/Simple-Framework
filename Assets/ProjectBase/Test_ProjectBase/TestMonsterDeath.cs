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
        Debug.Log("其他各个对象要做的事");
    }
    public void Win()
    {

    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener<TestMonster>("MonsterDead", OtherWaitMonsterDeadDo);
    }
}
