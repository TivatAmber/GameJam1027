using UnityEngine;

public class FindEnemy : MonoBehaviour
{
    private Vector3 directionToNearestEnemy;
    private GameObject nearestEnemy;
    private float nearestDistance = Mathf.Infinity;

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        if (nearestEnemy != null)
        {
            directionToNearestEnemy = nearestEnemy.transform.position - transform.position;
        }
    }

    void LateUpdate()
    {
        // ��ÿ֡�����󽫾����޸�Ϊplayer�뵱ǰָ����˵ľ���
        if (nearestEnemy != null)
        {
            nearestDistance = Vector3.Distance(transform.position, nearestEnemy.transform.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (nearestEnemy != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, directionToNearestEnemy);
        }
    }
}