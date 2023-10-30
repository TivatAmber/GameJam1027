using JetBrains.Annotations;
using UnityEngine;

public class ExperienceBall : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    public int maxExperience;
    private Player player;
    private bool used = false;
    private TimeManager timeManager;
    // Start is called before the first frame update
    void Start()
    {
        maxExperience = 1;
        player = EntityManager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        if (used)
        {
            Vector3 forward = ToolFunc.GetForward(gameObject, player.gameObject);
            transform.position += forward * maxSpeed * Time.deltaTime;
        }
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
                player.AddExp(maxExperience);
                ObjectPool.Instance.DestroyExperienceBall(this);
            }
        }
        if (target != null && target.CompareTag("Experience"))
        {
            used = true;
        }
    }
    public void setExperienceBall(Vector3 position, int Experience, float maxSpeed)
    {
        transform.position = position;
        this.maxSpeed = maxSpeed;
        this.maxExperience = Experience;
    }
}
