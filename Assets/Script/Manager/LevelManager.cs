using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public void LevelUp()
    {
        Time.timeScale = 0f;
        
    }
}
