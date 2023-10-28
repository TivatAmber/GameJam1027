using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        else
        {
            Debug.Log("No Enemy But Remove");
        }
    }
    // TODO Create Enemy
    #endregion
    #region Player
    public Player player;
    #endregion
    #region Skills
    public List<BaseSkill> skills = new List<BaseSkill>();
    public void RemoveSkill(BaseSkill obj)
    {
        if (skills.Contains(obj))
        {
            skills.Remove(obj);
        }
        else
        {
            Debug.LogWarning("No Skills But Remove");
        }
    }
    // TODO Create Skill
    #endregion
}
