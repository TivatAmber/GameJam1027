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
    private void Start()
    {

    }
    private void Update()
    {
        GetInput();
        ChangePosition();
    }
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
}
