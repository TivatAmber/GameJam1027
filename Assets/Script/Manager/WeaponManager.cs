using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] List<BaseMagic> magics = new List<BaseMagic>();
    private void Start()
    {
    }
    public void AddMagic(BaseMagic magic)
    {
        magics.Add(magic);
    }
}
