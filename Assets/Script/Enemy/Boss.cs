using UnityEngine;

public class Boss : BaseEnemy
{
    [SerializeField] float timeBetweenSkills = 10;//���μ���֮���ʱ��
    [SerializeField] float timeLimitZero = 4;//Boss�������µļ��
    [SerializeField] float timeLimitOne = 5;//���ʱ��
    [SerializeField] float R = 10;//��������ʾ��Χ
    [SerializeField] float chargeSpeed = 20;//��̵��ٶ�

    private Transform playerTransform;
    private bool isCharging = false;
    private float chargeTimer = 0f;
    private Vector3 chargeDirection;

    private void Awake()
    {
        base.Start();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // ��������ѡ��Э��
        StartCoroutine(SkillSelectionCoroutine());
    }

    private void Update()
    {
        if (isCharging)
        {
            Charge();//���
            return;
        }
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

            Vector3 point = new Vector3(x, y, 0f); // ��z����ʹ��0f����֤������2Dƽ����

            lineRenderer.SetPosition(i, point);
        }
    }

    private void Crash()
    {
        // ����Crash�������߼�
        // TODO: �����Լ�������ʵ�־����߼�
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
        // ����ѡ��1���ܵĸ���
        // TODO: �����Լ�������ʵ�־���ĸ��ʼ��㹫ʽ
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