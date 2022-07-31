
using UnityEngine;
using UnityEngine.UI;

public class manageUnitUI : MonoBehaviour
{
    public unitStats _unitStats;

    public Slider slider;

    void Start()
    {
        _unitStats = GetComponent<unitStats>();
    }

    public void UpdateHPBar(int currentHP, int maxHP)
    {
        slider.value = (float)currentHP / (float)maxHP;
    }
}
