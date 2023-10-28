using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    #region Bullet
    public void DestroyBullet(BaseBullet bullet)
    {
        if (bullet == null) throw new Exception("No Bullet But Destroy");
        switch (bullet)
        {
            case FireBall:
                DestoryFireBall(bullet as FireBall); break;
            case FireWall:
                DestroyFireWall(bullet as FireWall); break;
            case Tears:
                DestroyTears(bullet as Tears); break;
            case SoulSpear:
                DestroySoulSpear(bullet as SoulSpear); break;
        }
    }
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
    private void DestoryFireBall(FireBall obj)
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
    private void DestroyFireWall(FireWall obj)
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
    private void DestroyTears(Tears obj)
    {
        tears.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #region SoulSpear
    [SerializeField] SoulSpear soulSpear;
    List<SoulSpear> soulSpears = new List<SoulSpear>();
    public SoulSpear GetSoulSpear()
    {
        SoulSpear ret;
        if (soulSpears.Count > 0)
        {
            ret = soulSpears[0];
            soulSpears.Remove(ret);
        }
        else
        {
            ret = Instantiate(soulSpear);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    private void DestroySoulSpear(SoulSpear obj)
    {
        soulSpears.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #endregion
    #region Enemys
    public void DestroyEnemy(BaseEnemy enemy)
    {
        if (enemy == null) throw new Exception("No Enemy But Destroy");
        switch (enemy)
        {
            case Papawu:
                DestroyPapawu(enemy as Papawu); break;
            case Pumpkin:
                DestroyPumkin(enemy as Pumpkin); break;
            case Hat:
                DestroyHat(enemy as Hat); break;
        }
    }
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
    private void DestroyPapawu(Papawu obj)
    {
        papawus.Add(obj);
        obj.gameObject.SetActive(false);
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
    private void DestroyPumkin(Pumpkin obj)
    {
        pumpkins.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #region Hat
    [SerializeField] Hat hat;
    List<Hat> hats = new List<Hat>();
    public Hat GetHat()
    {
        Hat ret;
        if (hats.Count > 0)
        {
            ret = hats[0];
            hats.Remove(ret);
        }
        else
        {
            ret = Instantiate(hat);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    private void DestroyHat(Hat obj)
    {
        hats.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #endregion
}
