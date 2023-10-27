using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ToolFunc
{
    private static float sqr(float val)
    {
        return val * val;
    }
    public static float Dist(Vector3 vec1, Vector3 vec2)
    {
        return Mathf.Sqrt(sqr(vec1.x - vec2.x) + sqr(vec1.y - vec2.y) + sqr(vec1.z - vec2.z));
    }
}
