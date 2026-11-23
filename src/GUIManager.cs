using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [SerializeField] Slider health;
    [SerializeField] TMP_Text totalCollectables;
    [SerializeField] PlayerLife playerLife;
    public delegate void Increment();
    int collectablesObtained;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collectablesObtained = 0;
        Collectable[] collectables = GetComponent<DamageManager>().GetCollectables();
        for (int i = 0; i < collectables.Length; ++i)
        {
            collectables[i].OnCollectableObtained += IncrementCollectables;
        }
        playerLife.OnActualLifeChanged += LifeChanged;
        playerLife.OnMaxLifeChanged += MaxLifeChanged;
    }

    void LifeChanged(int actualLife)
    {
        health.value = actualLife;
    }

    void MaxLifeChanged(int maxLife)
    {
        health.maxValue = maxLife;
        RectTransform rect = health.gameObject.GetComponent<RectTransform>();
        rect.sizeDelta = new(maxLife, rect.rect.height);   
    }

    void IncrementCollectables()
    {
        collectablesObtained++;
        totalCollectables.text = collectablesObtained.ToString();
    }
}
