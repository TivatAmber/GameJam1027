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
    public void SubAllCoolTime(int delta)
    {
        foreach (BaseMagic m in magics)
        {
            m.SubCoolTime(delta);
        }
    }
}
