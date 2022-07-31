
using UnityEngine;

public class friendlyAI : unitAI
{

    void Update()
    {
        if (currentTarget == null) FindHighestPriorityTarget();
        RotateTowardsEnemy();
        AttackTarget();
    }


    public override void FindHighestPriorityTarget()
    {
        var numEnemies = _battleManager.allEnemies.Count;
        if (numEnemies == 0) return;
        int randEnemyId = Random.Range(0, numEnemies);

        currentTarget = _battleManager.allEnemies[randEnemyId];
        currentTarget.GetComponent<unitAI>().attackingMe.Add(gameObject);
    }



}
