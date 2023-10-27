using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


internal static class Order
{
    public static KeyCode upCode = KeyCode.UpArrow;
    public static KeyCode downCode = KeyCode.DownArrow;
    public static KeyCode leftCode = KeyCode.LeftArrow;
    public static KeyCode rightCode = KeyCode.RightArrow;
}
public class Controller : MonoBehaviour
{
    [SerializeField] Vector3 speed = Vector3.zero;
    [SerializeField] float maxSpeed = 1f;

    private Vector3 directionToNearestEnemy;
    private GameObject nearestEnemy;
    private float nearestDistance = Mathf.Infinity;
    private void Start()
    {

    }
    private void Update()
    {
        GetInput();
        ChangePosition();
        // FindEnemy();//�����һ��ָ���ͷ
    }
    /* void LateUpdate()
    {
        // ��ÿ֡�����󽫾����޸�Ϊplayer�뵱ǰָ����˵ľ���
        // RenewDistance();
    }*/
    void ChangePosition()
    {
        transform.position += speed * Time.deltaTime;
    }
    void GetInput()
    {
        speed = Vector3.zero;
        // Up
        if (Input.GetKey(Order.upCode))
        {
            speed += Vector3.up;
        }

        // Down
        if (Input.GetKey(Order.downCode))
        {
            speed += Vector3.down;
        }

        // Left
        if (Input.GetKey(Order.leftCode))
        {
            speed += Vector3.left;
        }

        // Right
        if (Input.GetKey(Order.rightCode))
        {
            speed += Vector3.right;
        }

        speed.Normalize();
        speed *= maxSpeed;
    }
    /*
    void FindEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        if (nearestEnemy != null)
        {
            directionToNearestEnemy = nearestEnemy.transform.position - transform.position;
        }
    }
    void OnDrawGizmosSelected()
    {
        if (nearestEnemy != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, directionToNearestEnemy);
        }
    }
    void RenewDistance()
    {
        // ��ÿ֡�����󽫾����޸�Ϊplayer�뵱ǰָ����˵ľ���
        if (nearestEnemy != null)
        {
            nearestDistance = Vector3.Distance(transform.position, nearestEnemy.transform.position);
        }
    }
    */
}
