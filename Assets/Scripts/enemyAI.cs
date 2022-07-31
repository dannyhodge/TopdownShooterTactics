
using UnityEngine;

public class enemyAI : unitAI
{


    void Update()
    {
        if(currentTarget == null) FindHighestPriorityTarget();
        RotateTowardsEnemy();
        AttackTarget();
    }


    public override void FindHighestPriorityTarget()
    {
        var numFriendlies = _battleManager.allFriendlies.Count;
        if (numFriendlies == 0) return;
        int randEnemyId = Random.Range(0, numFriendlies);

        currentTarget = _battleManager.allFriendlies[randEnemyId];
        currentTarget.GetComponent<unitAI>().attackingMe.Add(gameObject);
    }
}
