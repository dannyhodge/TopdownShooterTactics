using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{

    public float bulletSpeed = 10f;

    public float bulletDestroyTime = 3f;
    public float bulletDestroyTimer = 0f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * bulletSpeed);

        DestroySelf();
    }

    void DestroySelf()
    {
        bulletDestroyTimer += Time.deltaTime;

        if(bulletDestroyTimer >= bulletDestroyTime)
        {
            Destroy(this.gameObject);
        }
    }
}
