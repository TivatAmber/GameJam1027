using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    #region FireBall
    [SerializeField] FireBall fireBall;
    List<FireBall> fireBalls = new List<FireBall>();
    public FireBall GetFireBall()
    {
        FireBall ret;
        if (fireBalls.Count > 0)
        {
            ret = fireBalls[0];
            fireBalls.Remove(ret);
        }
        else
        {
            ret = Instantiate(fireBall);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    public void DestoryFireBall(FireBall obj)
    {
        fireBalls.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #region FireWall
    [SerializeField] FireWall fireWall;
    List<FireWall> fireWalls = new List<FireWall>();
    public FireWall GetFireWall()
    {
        FireWall ret;
        if (fireWalls.Count > 0)
        {
            ret = fireWalls[0];
            fireWalls.Remove(ret);
        }
        else
        {
            ret = Instantiate(fireWall);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    public void DestroyFireWall(FireWall obj)
    {
        fireWalls.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #region Tears
    [SerializeField] Tears tear;
    List<Tears> tears = new List<Tears>();
    public Tears GetTears()
    {
        Tears ret;
        if (tears.Count > 0)
        {
            ret = tears[0];
            tears.Remove(ret);
        }
        else
        {
            ret = Instantiate(tear);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    public void DestroyTears(Tears obj)
    {
        tears.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #region Papawu
    [SerializeField] Papawu papawu;
    List<Papawu> papawus = new List<Papawu>();
    public Papawu GetPapawu()
    {
        Papawu ret;
        if (papawus.Count > 0)
        {
            ret = papawus[0];
            papawus.Remove(ret);
        }
        else
        {
            ret = Instantiate(papawu);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    public void Destroy(Papawu obj)
    {
        papawus.Add(obj);
        papawu.gameObject.SetActive(false);
    }
    #endregion
    #region Pumpkin
    [SerializeField] Pumpkin pumpkin;
    List<Pumpkin> pumpkins = new List<Pumpkin>();
    public Pumpkin GetPumpkin()
    {
        Pumpkin ret;
        if (pumpkins.Count > 0)
        {
            ret = pumpkins[0];
            pumpkins.Remove(ret);
        }
        else
        {
            ret = Instantiate(pumpkin);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    public void DestroyPumkin(Pumpkin obj)
    {
        pumpkins.Add(obj);
        pumpkin.gameObject.SetActive(false);
    }
    #endregion
}
