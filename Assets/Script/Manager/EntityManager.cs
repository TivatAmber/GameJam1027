using System.Collections;
using System.Collections.Generic;
using System;

public class EntityManager : Singleton<EntityManager>
{
    #region Enemys
    public List<BaseEnemy> enemies = new List<BaseEnemy>();
    public void RemoveEnemy(BaseEnemy obj)
    {
        if (enemies.Contains(obj))
        {
            enemies.Remove(obj);
        }
    }
    #endregion
    #region Player
    public Player player;
    #endregion
}
