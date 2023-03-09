using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float myBulletType = 0;
    public float myBulletSpeed;
    public float myBulletTTL;

    float myTimeElapsed;

    Rigidbody2D myRB;

    bool myImpact = false;

    // Start is called before the first frame update
    void Start()
    {
        myTimeElapsed = 0f;
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;
        if (myTimeElapsed < myBulletTTL)
        {
            switch (myBulletType)
            {
                case 0:
                    NormalBulletBehaviour(delta);
                    break;
                default:
                    break;
            }

            myTimeElapsed += delta;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    void NormalBulletBehaviour(float delta)
    {
        myRB.velocity = transform.up * delta * myBulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpawnBullet spawnBullet = GetComponentInParent<SpawnBullet>();

        if (true)//trebuie sa nu mai am coliziune cu player-ul cand tot el trage
        {
            myImpact = true;
            Debug.Log("Bullet Hit!");
        }
    }
}
