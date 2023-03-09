using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject myBullet;
    public float myCooldown;
    public bool myCanShoot;
    public bool myIsPlayer;

    float myElapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        myElapsedTime = myCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //if cooldown is on do nothing
        if (myElapsedTime < myCooldown)
        {
            myElapsedTime += Time.fixedDeltaTime;
        }
        //spawn bullet and reset timer/cooldown
        else 
        {
            if (myCanShoot)
            {
                Quaternion direction;
                if (!myIsPlayer)
                {
                    direction = Quaternion.AngleAxis(90f, Vector3.forward);
                }
                else
                {
                    Shooting shooting = this.gameObject.GetComponentInParent<Shooting>();
                    float angle = -90f;
                    
                    if (shooting)
                    {
                        angle += shooting.GetMouseToRightAngle();
                    }

                    direction = Quaternion.AngleAxis(angle, Vector3.forward);
                }
                Instantiate(myBullet, transform.position, direction);

                myElapsedTime = 0f;
            }
        }
    }
}
