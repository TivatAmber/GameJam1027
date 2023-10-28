using UnityEngine;

public class HealBall : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    private int heal;
    private Player player;
    private void Start()
    {
        player = EntityManager.Instance.player;
    }
    private void Update()
    {
        Vector3 forward = ToolFunc.GetForward(gameObject, player.gameObject);
        transform.position += forward * maxSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        TestCollsion(target);
    }
    void TestCollsion(GameObject target)
    {
        if (target != null && target.CompareTag("Player"))
        {
            if (target.TryGetComponent<Player>(out var player))
            {
                player.ChangeHealth(-heal);
                ObjectPool.Instance.DestroyHealBall(this);
            }
        }
    }
    public void setHealBall(Vector3 position, int heal, float maxSpeed)
    {
        transform.position = position;
        this.maxSpeed = maxSpeed;
        this.heal = heal;
    }
}
