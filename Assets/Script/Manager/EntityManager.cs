using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    #region Enemys
    public List<BaseEnemy> enemys = new List<BaseEnemy>();

    #endregion
    #region Player
    public Player player;
    #endregion
}
