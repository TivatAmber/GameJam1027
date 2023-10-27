using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Follow();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }
    public GameObject target;

    void Follow()
    {
        if (target != null)
        {
            // 获取目标物体的位置
            Vector3 targetPosition = target.transform.position;
            // 将摄像机的位置设置为目标物体的位置
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }
    }
}
