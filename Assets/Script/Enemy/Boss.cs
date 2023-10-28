using UnityEngine;

public class Boss : BaseEnemy
{
    [SerializeField] float timeBetweenSkills = 10;//两次技能之间的时间
    [SerializeField] float timeLimitZero = 4;//Boss跳起到落下的间隔
    [SerializeField] float timeLimitOne = 5;//冲刺时间
    [SerializeField] float R = 10;//跳劈的提示范围
    [SerializeField] float chargeSpeed = 20;//冲刺的速度

    private Transform playerTransform;
    private bool isCharging = false;
    private float chargeTimer = 0f;
    private Vector3 chargeDirection;

    private void Awake()
    {
        base.Start();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // 启动技能选择协程
        StartCoroutine(SkillSelectionCoroutine());
    }

    private void Update()
    {
        if (isCharging)
        {
            Charge();//冲刺
            return;
        }
    }

    private void DrawCircle(Vector3 center, float radius)
    {
        int segments = 360; // 圆环的分段数，值越大，圆环越平滑
        float anglePerSegment = 360f / segments;

        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f; // 圆环的线宽
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material.color = Color.red; // 设置圆环的颜色
        lineRenderer.positionCount = segments + 1; // 设置LineRenderer的位置数量

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * anglePerSegment;

            float x = center.x + Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = center.y + Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            Vector3 point = new Vector3(x, y, 0f); // 在z轴上使用0f，保证绘制在2D平面上

            lineRenderer.SetPosition(i, point);
        }
    }

    private void Crash()
    {
        // 调用Crash函数的逻辑
        // TODO: 根据自己的需求实现具体逻辑
    }

    private void Charge()
    {
        chargeTimer += Time.deltaTime;
        if (chargeTimer <= timeLimitOne)
        {
            transform.position += chargeDirection * chargeSpeed * Time.deltaTime;
        }
        else
        {
            isCharging = false;
        }
    }

    private System.Collections.IEnumerator SkillSelectionCoroutine()//选择不同的协程
    {
        while (true)
        {
            float randomValue = Random.value;
            if (randomValue <= ChooseSkillProbability())
            {
                StartCoroutine(SkillOneCoroutine());//跳劈
            }
            else
            {
                StartCoroutine(SkillTwoCoroutine());//冲撞
            }
            yield return new WaitForSeconds(timeBetweenSkills);
        }
    }

    private float ChooseSkillProbability()
    {
        // 返回选择1技能的概率
        // TODO: 根据自己的需求实现具体的概率计算公式
        return 0.5f;
    }

    private System.Collections.IEnumerator SkillOneCoroutine()//
    {
        Vector3 previousPosition = playerTransform.position;
        //transform.position = playerTransform.position;
        DrawCircle(playerTransform.position, R);
        yield return new WaitForSeconds(timeLimitZero);
        Crash();
        yield return new WaitForSeconds(timeLimitOne);
        transform.position = previousPosition;
    }

    private System.Collections.IEnumerator SkillTwoCoroutine()
    {
        chargeDirection = (playerTransform.position - transform.position).normalized;
        chargeTimer = 0f;
        isCharging = true;
        yield return new WaitForSeconds(timeLimitOne);
        isCharging = false;
    }
}