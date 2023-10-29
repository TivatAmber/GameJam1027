using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuff : MonoBehaviour, IUpGrade
{
    [SerializeField] protected int level;
    [SerializeField] protected int maxLevel;
    public int Level { get { return level; } }
    public bool CanUpGrade { get { return maxLevel != level; } }
    private void Start()
    {
        level = 0;
    }
    public virtual void UpGrade()
    {
        Debug.LogWarning(this.name + "Can't UpGrade");
    }
    public void AddCombo(int delta)
    {
        Debug.LogWarning("Shouldn't Call this Func in " + this.name);
        return;
    }
    public void SubCoolTime(int delta)
    {
        Debug.LogWarning("Shouldn't Call this Func in " + this.name);
        return;
    }
}
