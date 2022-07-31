
using UnityEngine;

public class unitStats : MonoBehaviour
{
    public int currentHealth = 100;
    public int maxHealth = 100;
    public bool isAlive = true;

    public int cover = 0;
    public int accuracy = 100; // % hit chance

    public int experience = 0;
    public int experienceForLevelUp = 100;
    public SoldierClass soldierClass = SoldierClass.Rifleman;

    public int attackDamage = 5;
    public int attackSpeed = 5;

    public battleManager _battleManager;

    public manageUnitUI _myUI;

    void Start()
    {
        _battleManager = GameObject.Find("battleManager").GetComponent<battleManager>();
        _myUI = GetComponent<manageUnitUI>();

        _myUI.UpdateHPBar(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroySelf()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                _battleManager.allEnemies.Remove(gameObject);

                foreach (var friendly in _battleManager.allFriendlies)
                {
                    friendly.GetComponent<unitAI>().attackingMe.Remove(gameObject);
                }
            }
            if (gameObject.tag == "Friendly")
            {
                _battleManager.allFriendlies.Remove(gameObject);

                foreach (var enemy in _battleManager.allEnemies)
                {
                    enemy.GetComponent<unitAI>().attackingMe.Remove(gameObject);
                }
            }

            GetComponent<unitAI>()?.currentTarget.GetComponent<unitAI>().attackingMe.Remove(gameObject);

            //Do death animation using bool below, animation bool?
            isAlive = false;
            foreach (var unitAttackingMe in GetComponent<unitAI>().attackingMe)
            {
                if (unitAttackingMe != null) unitAttackingMe.GetComponent<unitAI>().FindHighestPriorityTarget();
            }
            Destroy(gameObject);
        }

    }

    public void LoseHP()
    {
        DestroySelf();
        _myUI.UpdateHPBar(currentHealth, maxHealth);
    }
}


public enum SoldierClass
{
    Sniper,     // High damage/accuracy, low speed,                     upgrade paths to make more stealthy (low threat) or better assassin (high damage/CC)
    MG,         // Low damage/accuracy, high speed, high suppression,   upgrade paths to increase suppression, or attack speed increases over time
    Medic,      // Low everything, but heals allies every X seconds     upgrade paths to improve healing (heal all instead of lowest hp) or stim (increase everyones stats_
    Rifleman,   // default unit before it gets upgraded
    Assault,    // average stats, high hp/cover, high threat            upgrade paths to increase threat or increase hp/cover
    Grenadier,  // similar stats to medic, but destroys enemy cover     upgrade paths to better destroy cover, or to suppress while destroying cover
    Engineer,    // similar stats to assault, but fixes cover           upgrade paths to start round with higher cover, or to fix faster
    Mech  // Starts out with terrible stats (replaces a rifleman)       upgrade paths to anti infantry or tank
}