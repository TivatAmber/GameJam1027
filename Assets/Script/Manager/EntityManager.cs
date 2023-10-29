using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EntityManager : Singleton<EntityManager>
{
    #region Enemys
    [SerializeField] float distance;
    [SerializeField] int deltaMaxHealth;
    [SerializeField] int maxPapawuNumber;
    [SerializeField] int deltaPapawuNumber;
    public List<BaseEnemy> enemies = new List<BaseEnemy>();
    private int papawuNumber;
    private int pumpkinNumber;
    private int hatNumber;
    private void Start()
    {
        StartCoroutine(Strengthen());
        StartCoroutine(AddPapawuNumber());
        StartCoroutine(ControllerCoroutine());
    }
    private IEnumerator Strengthen()
    {
        WaitForSeconds deltaTime = new WaitForSeconds(60);
        while (true)
        {
            yield return deltaTime;
            ObjectPool.Instance.papawu.AddMaxHealth(deltaMaxHealth);
            ObjectPool.Instance.pumpkin.AddMaxHealth(deltaMaxHealth);
        }
    }
    private IEnumerator AddPapawuNumber()
    {
        WaitForSeconds deltaTime = new WaitForSeconds(30);
        while (true)
        {
            yield return deltaTime;
            maxPapawuNumber += deltaPapawuNumber;
        }
    }
    private IEnumerator CreatePapawu()
    {
        WaitForSeconds deltaTime = new WaitForSeconds(0.1f);
        while (true)
        {
            if (papawuNumber < maxPapawuNumber)
            {
                Papawu papawu = ObjectPool.Instance.GetPapawu();
                enemies.Add(papawu);
                papawu.Init(GetRandomPosition());
                papawuNumber++;
            }
            yield return deltaTime;
        }
    }
    private IEnumerator CreatePumpkin()
    {
        yield return new WaitForSeconds(120f);
        while (true)
        {
            Pumpkin pumpkin = ObjectPool.Instance.GetPumpkin();
            enemies.Add(pumpkin);
            pumpkin.Init(GetRandomPosition());
            pumpkinNumber++;
            yield return new WaitForSeconds(Random.Range(3f, 5f));
        }
    }
    private IEnumerator CreateHat() 
    {
        WaitForSeconds deltaTime = new WaitForSeconds(0.1f);
        while (true)
        {
            Hat hat = ObjectPool.Instance.GetHat();
            enemies.Add(hat);
            hat.Init(GetRandomPosition());
            hatNumber++;
            yield return deltaTime;
        }
    }
    public void CreateBoss()
    {
        Boss now = ObjectPool.Instance.GetBoss();
        now.transform.position = GetRandomPosition();
    }
    private IEnumerator ControllerCoroutine()
    {
        WaitForSeconds deltaTime1 = new WaitForSeconds(150);
        WaitForSeconds deltaTime2 = new WaitForSeconds(30);
        WaitForSeconds deltaTime3 = new WaitForSeconds(60);
        while (true)
        {
            StartCoroutine(CreatePapawu());
            StartCoroutine(CreatePumpkin());
            yield return deltaTime1;
            StopCoroutine(CreatePapawu());
            StopCoroutine(CreatePumpkin());
            StartCoroutine(CreateHat());
            yield return deltaTime2;
            StartCoroutine(CreatePapawu());
            StartCoroutine(CreatePumpkin());
            StopCoroutine(CreateHat());
            yield return deltaTime3;
            StopCoroutine(CreatePapawu());
            StopCoroutine(CreatePumpkin());
            CreateBoss();
            yield return deltaTime2;
        }
    }
    private Vector3 GetRandomPosition()
    {
        float angle = Random.Range(0f, 360f);
        Vector3 position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * distance;
        return position + EntityManager.Instance.player.transform.position;
    }
    public void RemoveEnemy(BaseEnemy obj)
    {
        if (enemies.Contains(obj))
        {
            enemies.Remove(obj);
            ChangeNumber(obj);
        }
        else
        {
            Debug.Log("No Enemy But Remove");
        }
    }
    private void ChangeNumber(BaseEnemy obj)
    {
        switch (obj)
        {
            case Papawu:
                papawuNumber--;
                break;
            case Pumpkin:
                pumpkinNumber--;
                break;
            case Hat: 
                hatNumber--;
                break;
        }
    }
    #endregion
    #region Player
    public Player player;
    #endregion
    #region Skills
    public List<BaseSkill> skills = new List<BaseSkill>();
    public void RemoveSkill(BaseSkill obj)
    {
        if (skills.Contains(obj))
        {
            skills.Remove(obj);
        }
        else
        {
            Debug.LogWarning("No Skills But Remove");
        }
    }
    // TODO Create Skill
    #endregion
}
