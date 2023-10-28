using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    // ʯɽ
    #region Bullet
    public void DestroyBullet(BaseBullet bullet)
    {
        if (bullet == null)
        {
            Debug.LogWarning("No Bullet But Destroy");
            return;
        }
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
    [Header("Bullet")]
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
        if (enemy == null)
        {
            Debug.LogWarning("No Enemy But Destroy");
            return;
        }
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
    [Header("Enemys")]
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
    #region Skills
    public void DestroySkill(BaseSkill skill)
    {
        if (skill == null)
        {
            Debug.LogWarning("No Enemy But Destroy");
            return;
        }
        switch (skill)
        {
            case DashSkill:
                DestroyDashSkill(skill as DashSkill); break;
            case HealSkill:
                DestroyHealSkill(skill as HealSkill); break;
            case TheWallSkill:
                DestroyTheWallSkill(skill as TheWallSkill); break;
            case HugeSoulSpearSkill:
                DestroyHugeSoulSpearSkill(skill as HugeSoulSpearSkill); break;
        }
    }
    [Header("Skills")]
    #region DashSkill
    [SerializeField] DashSkill dashSkill;
    List<DashSkill> dashSkills = new List<DashSkill>();
    public DashSkill GetDashSkill()
    {
        DashSkill ret;
        if (dashSkills.Count > 0)
        {
            ret = dashSkills[0];
            dashSkills.Remove(ret);
        }
        else
        {
            ret = Instantiate(dashSkill);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    private void DestroyDashSkill(DashSkill obj)
    {
        dashSkills.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #region HealSkill
    [SerializeField] HealSkill healSkill;
    List<HealSkill> healSkills = new List<HealSkill>();
    public HealSkill GetHealSkill()
    {
        HealSkill ret;
        if (healSkills.Count > 0)
        {
            ret = healSkills[0];
            healSkills.Remove(ret);
        }
        else
        {
            ret = Instantiate(healSkill);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    private void DestroyHealSkill(HealSkill obj)
    {
        healSkills.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #region TheWallSkill
    [SerializeField] TheWallSkill theWallSkill;
    List<TheWallSkill> theWallSkills = new List<TheWallSkill>();
    public TheWallSkill GetTheWallSkill()
    {
        TheWallSkill ret;
        if (theWallSkills.Count > 0)
        {
            ret = theWallSkills[0];
            theWallSkills.Remove(ret);
        }
        else
        {
            ret = Instantiate(theWallSkill);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    private void DestroyTheWallSkill(TheWallSkill obj)
    {
        theWallSkills.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #region HugeSoulSpearSkill
    [SerializeField] HugeSoulSpearSkill hugeSoulSpearSkill;
    List<HugeSoulSpearSkill> hugeSoulSpearSkills = new List<HugeSoulSpearSkill>();
    public HugeSoulSpearSkill GetHugeSoulSpearSkill()
    {
        HugeSoulSpearSkill ret;
        if (hugeSoulSpearSkills.Count > 0)
        {
            ret = hugeSoulSpearSkills[0];
            hugeSoulSpearSkills.Remove(ret);
        }
        else
        {
            ret = Instantiate(hugeSoulSpearSkill);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    private void DestroyHugeSoulSpearSkill(HugeSoulSpearSkill obj)
    {
        hugeSoulSpearSkills.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #endregion
    #region Other
    [Header("Other")]
    #region HealBall
    [SerializeField] HealBall healBall;
    List<HealBall> healBalls = new List<HealBall>();
    public HealBall GetHealBall()
    {
        HealBall ret;
        if (healBalls.Count > 0)
        {
            ret = healBalls[0];
            healBalls.Remove(ret);
        }
        else
        {
            ret = Instantiate(healBall);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    public void DestroyHealBall(HealBall obj)
    {
        healBalls.Add(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #region HealTower
    [SerializeField] HealTower healTower;
    List<HealTower> healTowers = new List<HealTower>();
    public HealTower GetHealTower()
    {
        HealTower ret;
        if (healTowers.Count > 0)
        {
            ret = healTowers[0];
            healTowers.Remove(ret);
        }
        else
        {
            ret = Instantiate(healTower);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    public void DestroyHealTower(HealTower obj) 
    { 
        healTowers.Remove(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #region
    [SerializeField] HugeSoulSpear hugeSoulSpear;
    List<HugeSoulSpear> hugeSoulSpears = new List<HugeSoulSpear>();
    public HugeSoulSpear GetHugeSoulSpear()
    {
        HugeSoulSpear ret;
        if (hugeSoulSpears.Count > 0)
        {
            ret = hugeSoulSpears[0];
            hugeSoulSpears.Remove(ret);
        }
        else
        {
            ret = Instantiate(hugeSoulSpear);
        }
        ret.gameObject.SetActive(true);
        return ret;
    }
    public void DestroyHugeSoulSpear(HugeSoulSpear obj)
    {
        hugeSoulSpears.Remove(obj);
        obj.gameObject.SetActive(false);
    }
    #endregion
    #endregion
}
