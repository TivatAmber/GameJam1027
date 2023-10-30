using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boss : BaseEnemy
{
    [SerializeField] float timeBetweenSkills = 10;//两次技能之间的时间
    [SerializeField] float timeLimitZero = 2;//Boss跳起到落下的间隔
    [SerializeField] float timeLimitOne = 3f;//冲刺总时间
    [SerializeField] float timeLimitTwo = 1f;//停顿时间
    [SerializeField] float R = 1;//跳劈的提示范围
    [SerializeField] float slowSpeed = 2;//冲刺的速度
    [SerializeField] float chargeSpeed = 20;//冲刺的速度
    [SerializeField] float demageLimited = 100;//造成硬值的伤害量
    [SerializeField] float changeLimitedTimes = 10;//调用冲刺或者结束冲刺的硬值变化倍数
    [SerializeField] float stopTimes = 10;//硬值时间
    [SerializeField] int fallDamage = 10;//下落时对人物的伤害
    [SerializeField] bool isCharging = false;
    [SerializeField] bool isStop = false;
    [SerializeField] bool isJump = false;
    float distance;
    float time = 0;
    float currentdemageLimited;
    int nowHP;
    private Transform playerTransform;
    private float chargeTimer = 0f;
    private Vector3 chargeDirection;
    Player player;

    new private void Start()
    {
        base.Start();
        timer = attackCooldown;
    }
    private void Awake()
    {
        base.Start();
        player = EntityManager.Instance.player;
        playerTransform = player.transform;
        // 启动技能选择协程
        StartCoroutine(SkillSelectionCoroutine());
    }

    private void Update()
    {
        if (timer < attackCooldown)
        {
            timer += Time.deltaTime;
        }
        if (isStop)
        {
            time += Time.deltaTime;
            Stop();
        }
        else
        {
            if (!isCharging && !isJump)
            {
                Move();//移动同时计算受伤和硬值
            }
            if (isCharging)
            {
                Charge();//冲刺同时计算受伤和硬值
                return;
            }
        }
    }

    private void LateUpdate()//存储每一帧末尾的血量
    {
        nowHP = health;
        if(nowHP < 0)
        {
            Debug.Log("ok");
            Destroy(this);
        }
    }
    
    private void Stop()
    {
        if (time > stopTimes)
        {
            time = 0;
            isStop = false;
        }
    }
    public void Init()
    {
        health = maxHealth;
        timer = attackCooldown;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject target = collision.gameObject;
        TestCollsion(target);
    }
    void TestCollsion(GameObject target)
    {
        Debug.Log("success");
        if (target != null && target.tag == "Player")
        {
            Player player = target.GetComponent<Player>();
            if (player != null && timer >= attackCooldown)
            {
                player.ChangeHealth(damage);
                timer = 0;
            }
        }
        if (target != null && target.tag == "Enemy")
        {
            Destroy(target);
        }
    }
    protected override void Move()
    {
        Vector3 forward = ToolFunc.GetForward(gameObject, EntityManager.Instance.player.gameObject);
        speed = forward * maxSpeed;
        transform.position += speed * Time.deltaTime;
        Ifstop();
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

            Vector3 point = new(x, y, 0f); // 在z轴上使用0f，保证绘制在2D平面上

            lineRenderer.SetPosition(i, point);
        }
    }
    private int ChangeHP()
    {
        int ChangeHP = health - nowHP;
        return ChangeHP;
    }
    private void Crash(Vector3 center)
    {
        if (Vector3.Distance(center, playerTransform.position) < R)
        {
            player.ChangeHealth(fallDamage);
        }
        // TODO: 根据自己的需求实现具体逻辑
    }

    private void Charge()
    {
        currentdemageLimited /= changeLimitedTimes;
        Ifstop();
        chargeTimer += Time.deltaTime;
        if (chargeTimer <= timeLimitTwo)
        {
            transform.position += slowSpeed * Time.deltaTime * chargeDirection;
        }
        else if (chargeTimer <= timeLimitOne)
        {
            transform.position += chargeSpeed * Time.deltaTime * chargeDirection;
        }
        else
        {
            currentdemageLimited *= changeLimitedTimes;
            isCharging = false;
        }
    }
    private void Ifstop() //判断是否停下来
    {
        currentdemageLimited -= ChangeHP();
        if (currentdemageLimited < 0)
        {
            isStop = true;
            currentdemageLimited = demageLimited;
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
        distance = Vector3.Distance(playerTransform.position, this.transform.position);
        if (distance < 5)
        {
            return 0f;
        }
        else if (distance < 7)
        {
            return 0.4f;
        }
        else if (distance < 10)
        {
            return 0.8f;
        }
        else
        {
            return 0.95f;
        }
        // 返回选择1技能的概率
        // TODO: 根据自己的需求实现具体的概率计算公式
    }

    private System.Collections.IEnumerator SkillOneCoroutine()//
    {
        Vector3 previousPosition = playerTransform.position;
        //transform.position = playerTransform.position;
        DrawCircle(previousPosition, R);//画显示圈
        transform.position = previousPosition + new Vector3(30, 30, 30);
        isJump = true;
        yield return new WaitForSeconds(timeLimitZero);
        Crash(previousPosition);//在范围内造成伤害
        yield return new WaitForSeconds(timeLimitZero);
        transform.position = previousPosition;
        isJump = false;
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