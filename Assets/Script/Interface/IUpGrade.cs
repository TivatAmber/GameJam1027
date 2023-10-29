using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpGrade
{
    public int Level { get; }
    public bool CanUpGrade { get; }
    public void UpGrade();
    public void AddCombo(int delta);
    public void SubCoolTime(int percent);
}
