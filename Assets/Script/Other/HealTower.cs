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
            healBall = ObjectPool.Instance.GetHealBall();
            healBall.setHealBall(transform.position, damage, maxSpeed);
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void SetHealTower(Vector3 position, int damage, float distance, float maxSpeed)
    {
        transform.position = position;
        this.damage = damage;
        this.maxSpeed = maxSpeed;
        this.distance = distance;
        DrawCircle(position, distance);
    }
    private void DrawCircle(Vector3 center, float radius)
    {
        int segments = 360; // 圆环的分段数，值越大，圆环越平滑
        float anglePerSegment = 360f / segments;

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f; // 圆环的线宽
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material.color = Color.green; // 设置圆环的颜色
        lineRenderer.positionCount = segments + 1; // 设置LineRenderer的位置数量

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * anglePerSegment;

            float x = center.x + Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = center.y + Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            Vector3 point = new(x, y, 0f); // 在z轴上使用0f，保证绘制在2D平面上

            lineRenderer.SetPosition(i, point);
        }
    }
}
