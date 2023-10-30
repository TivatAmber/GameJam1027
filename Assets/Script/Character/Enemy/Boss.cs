using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boss : BaseEnemy
{
    [SerializeField] float timeBetweenSkills = 10;//���μ���֮���ʱ��
    [SerializeField] float timeLimitZero = 2;//Boss�������µļ��
    [SerializeField] float timeLimitOne = 3f;//�����ʱ��
    [SerializeField] float timeLimitTwo = 1f;//ͣ��ʱ��
    [SerializeField] float R = 1;//��������ʾ��Χ
    [SerializeField] float slowSpeed = 2;//��̵��ٶ�
    [SerializeField] float chargeSpeed = 20;//��̵��ٶ�
    [SerializeField] float demageLimited = 100;//���Ӳֵ���˺���
    [SerializeField] float changeLimitedTimes = 10;//���ó�̻��߽�����̵�Ӳֵ�仯����
    [SerializeField] float stopTimes = 10;//Ӳֵʱ��
    [SerializeField] int fallDamage = 10;//����ʱ��������˺�
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
        // ��������ѡ��Э��
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
                Move();//�ƶ�ͬʱ�������˺�Ӳֵ
            }
            if (isCharging)
            {
                Charge();//���ͬʱ�������˺�Ӳֵ
                return;
            }
        }
    }

    private void LateUpdate()//�洢ÿһ֡ĩβ��Ѫ��
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
        int segments = 360; // Բ���ķֶ�����ֵԽ��Բ��Խƽ��
        float anglePerSegment = 360f / segments;

        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f; // Բ�����߿�
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material.color = Color.red; // ����Բ������ɫ
        lineRenderer.positionCount = segments + 1; // ����LineRenderer��λ������

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * anglePerSegment;
            float x = center.x + Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = center.y + Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            Vector3 point = new(x, y, 0f); // ��z����ʹ��0f����֤������2Dƽ����

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
        // TODO: �����Լ�������ʵ�־����߼�
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
    private void Ifstop() //�ж��Ƿ�ͣ����
    {
        currentdemageLimited -= ChangeHP();
        if (currentdemageLimited < 0)
        {
            isStop = true;
            currentdemageLimited = demageLimited;
            isCharging = false;
        }
    }
    private System.Collections.IEnumerator SkillSelectionCoroutine()//ѡ��ͬ��Э��
    {
        while (true)
        {
            float randomValue = Random.value;
            if (randomValue <= ChooseSkillProbability())
            {
                StartCoroutine(SkillOneCoroutine());//����
            }
            else
            {
                StartCoroutine(SkillTwoCoroutine());//��ײ
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
        // ����ѡ��1���ܵĸ���
        // TODO: �����Լ�������ʵ�־���ĸ��ʼ��㹫ʽ
    }

    private System.Collections.IEnumerator SkillOneCoroutine()//
    {
        Vector3 previousPosition = playerTransform.position;
        //transform.position = playerTransform.position;
        DrawCircle(previousPosition, R);//����ʾȦ
        transform.position = previousPosition + new Vector3(30, 30, 30);
        isJump = true;
        yield return new WaitForSeconds(timeLimitZero);
        Crash(previousPosition);//�ڷ�Χ������˺�
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