using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayPush : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Push", 1);
    }

    void Push()
    {
        PoolManager.GetInstance().PushObj(this.gameObject.name, this.gameObject);
    }
}
