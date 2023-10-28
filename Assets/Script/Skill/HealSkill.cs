using System.Collections;
using UnityEngine;

public class HealSkill : BaseSkill
{
    [SerializeField] float maxSpeed;
    private bool used = false;
    private void Update()
    {
        if (used && ToolFunc.Dist(transform.position, EntityManager.Instance.transform.position) > distance)
        {
            End();
        }
    }
    public override void Influence()
    {
        used = true;
        StartCoroutine(CreateHealBall());
    }
    private IEnumerator CreateHealBall()
    {
        HealBall healBall;
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            healBall = ObjectPool.Instance.GetHealBall();
            healBall.setHealBall(damage, maxSpeed);
        }
    }
}
