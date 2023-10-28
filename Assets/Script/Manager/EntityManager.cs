using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneityManager : Singleton<EneityManager>
{
    #region Enemys
    public List<BaseEnemy> enemys = new List<BaseEnemy>();

    #endregion
    #region Player
    public Player player;
    #endregion
}
