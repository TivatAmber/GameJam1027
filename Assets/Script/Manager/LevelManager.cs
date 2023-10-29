using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<BaseMagic> magicList = new List<BaseMagic>();
    [SerializeField] private List<BaseBuff> buffList = new List<BaseBuff>();
    [SerializeField] private List<IUpGrade> upGrades = new List<IUpGrade>();
    [SerializeField] private List<Button> buttons = new List<Button>();
    [SerializeField] private GameObject canvas;
    List<int> nowDraw = new List<int>();
    private void Awake()
    {
        foreach (BaseMagic m in magicList)
        {
            upGrades.Add(m);
        }
        foreach (BaseBuff m in buffList)
        {
            upGrades.Add(m);
        }
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(End);
        }
    }
    public void LevelUp()
    {
        Time.timeScale = 0f;
        canvas.SetActive(true);
        nowDraw = DrawCard();
    }
    private List<int> DrawCard() {
        System.Random random = new System.Random(242);
        var randomNumbers = Enumerable.Range(0, upGrades.Count).OrderBy(_ => random.Next()).Take(buttons.Count).ToList();
        foreach (int idx in Enumerable.Range(0, buttons.Count))
        {
            buttons[idx].onClick.AddListener(upGrades[randomNumbers[idx]].UpGrade);
            buttons[idx].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = upGrades[randomNumbers[idx]].thisGameObject.name;
        }
        return randomNumbers;
    }
    private void End()
    {
        Time.timeScale = 1.0f;
        canvas.SetActive(false);
        foreach (int idx in Enumerable.Range(0, buttons.Count))
        {
            buttons[idx].onClick.RemoveListener(upGrades[nowDraw[idx]].UpGrade);
            buttons[idx].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = upGrades[nowDraw[idx]].thisGameObject.name;
        }
    }
}
