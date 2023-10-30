using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


internal static class KeyPosition//¥¶¿Ì ‰»Î
{
    public static KeyCode upCode = KeyCode.W;
    public static KeyCode downCode = KeyCode.S;
    public static KeyCode leftCode = KeyCode.A;
    public static KeyCode rightCode = KeyCode.D;
    public static KeyCode getSkill = KeyCode.E;
}
public static class Order
{
    public static bool upCode;
    public static bool downCode;
    public static bool leftCode;
    public static bool rightCode;
    public static bool getSkill;
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
        Order.getSkill = Input.GetKeyDown(KeyPosition.getSkill);
    }
}
