using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceBall : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    private int Experience;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = EntityManager.Instance.player;
    }

    // Update is called once per frame
    void Update()
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
                player.ChangeExperience(Experience);
                ObjectPool.Instance.DestroyExperienceBall(this);
            }
        }
    }
    public void setExperienceBall(Vector3 position, int Experience, float maxSpeed)
    {
        transform.position = position;
        this.maxSpeed = maxSpeed;
        this.Experience = Experience;
    }
}
