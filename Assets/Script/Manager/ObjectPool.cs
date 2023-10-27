using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    #region Bullet
    GameObject fireball;
    List<GameObject> fireBalls = new List<GameObject>();
    public GameObject GetFireBall()
    {
        GameObject ret = fireBalls.Count > 0 ? ret = fireBalls[0] : Instantiate(fireball);
        ret.SetActive(true);
        return ret;
    }
    public void DestoryFireBall(GameObject obj)
    {
        fireBalls.Add(obj);
        obj.SetActive(false);
    }
    #endregion

}
