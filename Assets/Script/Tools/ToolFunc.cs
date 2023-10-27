using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ToolFunc
{
    /// <summary>
    /// return val * val
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    private static float sqr(float val)
    {
        return val * val;
    }
    /// <summary>
    /// Two Vector's dist
    /// </summary>
    /// <param name="vec1"></param>
    /// <param name="vec2"></param>
    /// <returns></returns>
    public static float Dist(Vector3 vec1, Vector3 vec2)
    {
        return Mathf.Sqrt(sqr(vec1.x - vec2.x) + sqr(vec1.y - vec2.y) + sqr(vec1.z - vec2.z));
    }
    /// <summary>
    /// fir to sec forward Vector
    /// </summary>
    /// <param name="fir"></param>
    /// <param name="sec"></param>
    /// <returns></returns>
    public static Vector3 GetForward(GameObject fir, GameObject sec)
    {
        return (sec.transform.position - fir.transform.position).normalized;
    }
}
