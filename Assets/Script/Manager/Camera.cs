using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            // ��ȡĿ�������λ��
            Vector3 targetPosition = target.transform.position;
            targetPosition.z = transform.position.z;
            // ���������λ������ΪĿ�������λ��
            // transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.4f);
        }
    }
}
