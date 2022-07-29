using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameObject : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PoolManager.GetInstance().GetObj("Test/Cube", (o) =>
            {
                o.transform.localScale = Vector3.one * 2;
            });
            //GameObject obj = ResourceManager.GetInstance().Load<GameObject>("Test/Cube");
            //obj.transform.localScale = Vector3.one * 2;
        }
        if (Input.GetMouseButtonDown(1))
        {
            //PoolManager.GetInstance().GetObj("Test/Sphere");

            //GameObject obj = ResourceManager.GetInstance().LoadAsync<GameObject>("Test/Sphere"); //错 异步加载，使用协程，没有返回值
            //不用lambda表达式，不太简洁
            //ResourceManager.GetInstance().LoadAsync<GameObject>("Test/Sphere", DoSomething); 
            //可以改用lambda表达式，更加简洁
            ResourceManager.GetInstance().LoadAsync<GameObject>("Test/Sphere", (obj) =>
            {
                obj.transform.localScale = Vector3.one * 3;
            });
        }
    }

    private void DoSomething(GameObject obj)
    {
        obj.transform.localScale = Vector3.one * 2;
    }
}
