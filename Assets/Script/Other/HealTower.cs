using System.Collections;
using UnityEngine;

public class HealTower : MonoBehaviour
{
    private int damage;
    private float distance;
    private float maxSpeed;
    private Player player;
    private void Start()
    {
        player = EntityManager.Instance.player;
        StartCoroutine(CreateHealBall());
    }
    private void Update()
    {
        if (ToolFunc.Dist(transform.position, player.transform.position) > distance)
        {
            ObjectPool.Instance.DestroyHealTower(this);
        }
    }

    private IEnumerator CreateHealBall()
    {
        HealBall healBall;
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            healBall = ObjectPool.Instance.GetHealBall();
            healBall.setHealBall(transform.position, damage, maxSpeed);
        }
    }
    public void SetHealTower(Vector3 position, int damage, float distance, float maxSpeed)
    {
        transform.position = position;
        this.damage = damage;
        this.maxSpeed = maxSpeed;
        this.distance = distance;
    }
}
