using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceBall : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    public int maxExperience;
    private Player player;
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
        //Vector3 forward = ToolFunc.GetForward(gameObject, player.gameObject);
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
                player.ChangeExperience(maxExperience);
                ObjectPool.Instance.DestroyExperienceBall(this);
            }
        }
    }
    public void setExperienceBall(Vector3 position, int Experience, float maxSpeed)
    {
        transform.position = position;
        this.maxSpeed = maxSpeed;
        this.maxExperience = Experience;
    }
}
