using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class HugeSoulSpear : MonoBehaviour
{
    private int damage;
    private int distance;
    private float range;
    private float lstAngle;
    private Vector3 origin;
    private List<BaseEnemy> enemyList = new List<BaseEnemy>();
    public void setHugeSoulSpear(Vector3 position, int damage, int distance, float range)
    {
        Vector3 forward = ToolFunc.GetForward(EntityManager.Instance.player.transform.position, position);
        lstAngle = ToolFunc.GetAngle(forward, Vector3.right);
        transform.RotateAround(transform.position, Vector3.Cross(Vector3.right, forward).normalized, lstAngle);
        transform.position = position + forward * distance / 2;
        origin = position;
        this.distance = distance;
        this.damage = damage;
        this.range = range;
        transform.localScale = new Vector3(distance, 1, 1);
        StartCoroutine(Attack());
        StartCoroutine(End());
    }
    private void Update()
    {
        Vector3 forward = ToolFunc.GetForward(EntityManager.Instance.player.transform.position, origin);
        float angle = ToolFunc.GetAngle(forward, Vector3.right);
        transform.RotateAround(origin, Vector3.Cross(Vector3.right, forward).normalized, angle - lstAngle);
        lstAngle = angle;
        transform.position = origin + forward * distance / 2;
        Debug.DrawLine(origin, EntityManager.Instance.player.transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        TestCollsion(target);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        RemoveCollsion(target);
    }
    void TestCollsion(GameObject target)
    {
        if (target != null && target.CompareTag("Enemy"))
        {
            if (target.TryGetComponent<BaseEnemy>(out var enemy))
            {
                if (!enemyList.Contains(enemy))
                {
                    enemyList.Add(enemy);
                }
            }
        }
    }
    private void RemoveCollsion(GameObject target)
    {
        if (target != null && target.CompareTag("Enemy"))
        {
            if (target.TryGetComponent<BaseEnemy>(out var enemy))
            {
                if (enemyList.Contains(enemy))
                {
                    enemyList.Remove(enemy);
                }
            }
        }
    }
    private IEnumerator Attack()
    {
        List<BaseEnemy> targets = new List<BaseEnemy>();
        while (true)
        {
            foreach (BaseEnemy enemy in enemyList)
            {
                if (enemy != null && enemy.gameObject.activeSelf)
                {
                    targets.Add(enemy);
                }
            }
            foreach (BaseEnemy enemy in targets)
            {
                enemy.ChangeHealth(damage);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    private IEnumerator End()
    {
        yield return new WaitForSeconds(range);
        ObjectPool.Instance.DestroyHugeSoulSpear(this);
    }
}
