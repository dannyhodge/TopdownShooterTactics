
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class unitAI : MonoBehaviour
{
    public GameObject currentTarget;
    public battleManager _battleManager;
    public unitStats _myStats;
    public List<GameObject> attackingMe = new List<GameObject>();

    public float attackTime = 1f;
    public float attackTimer = 0f;

    public float rotationSpeed = 5f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPos;

    public Animator anim;

    void Start()
    {
        _battleManager = GameObject.Find("battleManager").GetComponent<battleManager>();

        _myStats = GetComponent<unitStats>();

        anim = gameObject.GetComponentInChildren<Animator>();

        attackTime = 5f / (float)_myStats.attackSpeed;
        attackTimer = UnityEngine.Random.Range(0f, 0.2f);
    }

    protected void RotateTowardsEnemy()
    {
        float angle = Mathf.Atan2(currentTarget.transform.position.y - transform.position.y, currentTarget.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        angle -= 90;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public abstract void FindHighestPriorityTarget();

    protected void AttackTarget()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackTime)
        {
            currentTarget.GetComponent<unitStats>().currentHealth -= CalculateDamageDealt();
            currentTarget.GetComponent<unitStats>().LoseHP();
            anim.Play("Shoot_Recoil");
            GameObject.Instantiate(bulletPrefab, bulletSpawnPos.position, bulletSpawnPos.rotation);
            attackTimer = UnityEngine.Random.Range(0f, 0.2f);
        }
    }

    private int CalculateDamageDealt()
    {

        Debug.Log("dmg val " + gameObject.name + ": " + (int)Math.Ceiling(_myStats.attackDamage * (100 - currentTarget.GetComponent<unitStats>().cover) / 100f));
   

        return (int)Math.Ceiling(_myStats.attackDamage * (100 - currentTarget.GetComponent<unitStats>().cover) / 100f);
    }


}
