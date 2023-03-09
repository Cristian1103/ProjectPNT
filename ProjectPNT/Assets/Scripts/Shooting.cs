using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject myMuzzle;

    SpawnBullet mySpawnBullet;
    // Start is called before the first frame update
    void Start()
    {
        mySpawnBullet = myMuzzle.GetComponent<SpawnBullet>();
    }

    // Update is called once per frame
    void Update()
    {
        
        LookAfterMouse();
    }

    private void FixedUpdate()
    {
        CanPlayerShoot();
    }

    void CanPlayerShoot()
    {
        bool canShoot = false;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            canShoot = true;
        }

        if (mySpawnBullet)
        {
            mySpawnBullet.myCanShoot = canShoot;
        }
    }

    void LookAfterMouse()
    {
        Vector2 playerPos = this.gameObject.transform.position;
        float angle = GetMouseToMuzzleAngle() * Mathf.Deg2Rad;
        myMuzzle.transform.RotateAround(playerPos, Vector3.forward, angle);
    }

    public float GetMouseToMuzzleAngle()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 muzzlePos = myMuzzle.transform.position;
        Vector2 playerPos = this.gameObject.transform.position;
        Vector2 mouseDir = mousePos - playerPos;
        Vector2 muzzleDir = muzzlePos - playerPos;
        float angle = -Vector2.SignedAngle(mouseDir, muzzleDir);

        return angle;
    }

    public float GetMouseToRightAngle()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = this.gameObject.transform.position;
        Vector2 mouseDir = mousePos - playerPos;
        float angle = -Vector2.SignedAngle(mouseDir, Vector2.right);

        return angle;
    }
}
