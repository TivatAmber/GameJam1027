using UnityEngine;

public class HealBall : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    private int heal;
    private GameObject player;
    private void Update()
    {
        Vector3 forward = ToolFunc.GetForward(gameObject, player);
        transform.position += forward * maxSpeed;
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
    public void setHealBall(int heal, float maxSpeed)
    {
        this.maxSpeed = maxSpeed;
        this.heal = heal;
        player = EntityManager.Instance.player.gameObject;
    }
}
