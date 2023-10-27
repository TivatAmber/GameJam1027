using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMagic : BaseMagic
{
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > colldown)
        {
            timer = 0;
            Fire();
        }
        timer += Time.deltaTime;
    }
    protected override GameObject FindEnemy()
    {
        return null;
    }
    protected override void Fire()
    {
        GameObject target = FindEnemy();
        if (target != null)
        {
            Vector3 forward = target.transform.position - gameObject.transform.position;
            forward.Normalize();
            GameObject obj = ObjectPool.Instance.GetFireBall();
            FireBall bullet = obj.GetComponent<FireBall>();
            bullet.Speed = speed * forward;
            bullet.Damage = damage;
        }
    }
    protected override void Upgrade()
    {
        // TODO
    }
}
