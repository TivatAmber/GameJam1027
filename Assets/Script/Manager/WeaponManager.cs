using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    [SerializeField] List<BaseMagic> magics = new List<BaseMagic>();

    public void AddAllCombo(int delta)
    {
        foreach (BaseMagic m in magics)
        {
            m.AddCombo(delta);
        }
    }
    public void AddAllRange(int percent)
    {
        foreach (BaseMagic m in magics)
        {
            m.AddRange(percent);
        }
    }
    public void SubAllCoolTime(int percent)
    {
        foreach (BaseMagic m in magics)
        {
            m.SubCoolTime(percent);
        }
    }
}
