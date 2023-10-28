using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class DashSkill : BaseSkill
{
    public override void Influence()
    {
        GameObject player = EntityManager.Instance.player.gameObject;
        Vector3 forward = ToolFunc.GetForward(player, gameObject);
        player.transform.position = transform.position + forward * distance;
        End();
    }
}
