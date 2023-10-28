using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


internal static class KeyPosition
{
    public static KeyCode upCode = KeyCode.UpArrow;
    public static KeyCode downCode = KeyCode.DownArrow;
    public static KeyCode leftCode = KeyCode.LeftArrow;
    public static KeyCode rightCode = KeyCode.RightArrow;
}
public static class Order
{
    public static bool upCode;
    public static bool downCode;
    public static bool leftCode;
    public static bool rightCode;
}
public class Controller : Singleton<Controller>
{
    private void Update()
    {
        GetInput();
    }
    void GetInput()
    {
        Order.upCode = Input.GetKey(KeyPosition.upCode);
        Order.downCode = Input.GetKey(KeyPosition.downCode);
        Order.leftCode = Input.GetKey(KeyPosition.leftCode);
        Order.rightCode = Input.GetKey(KeyPosition.rightCode);
    }
}
