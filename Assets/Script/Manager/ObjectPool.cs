using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    #region Bullet
    [SerializeField] FireBall fireball;
    List<FireBall> fireBalls = new List<FireBall>();
    public FireBall GetFireBall()
    {
        FireBall ret = fireBalls.Count > 0 ? ret = fireBalls[0] : Instantiate(fireball);
        ret.gameObject.SetActive(true);
        return ret;
    }
    public void DestoryFireBall(FireBall obj)
    {
        fireBalls.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion

}
