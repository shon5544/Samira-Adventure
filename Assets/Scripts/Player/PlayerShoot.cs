using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    Transform tr;
    Go bulletController;

    public GameObject bullet;
    public GameObject Q_bullet;

    bool canShoot_0 = true;
    bool canShoot_1 = true;
    //Vector2 FVec;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        //float axis = Input.GetAxisRaw("Horizontal");

        //if(axis != 0)
        //{
            //FVec = new Vector2(axis, 0);
        //}

        if (Input.GetMouseButton(1))
        {
            if (canShoot_0)
            {
                Shoot(0);
                StartCoroutine(CoolDown_0());
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (canShoot_1)
            {
                Shoot(1);
                StartCoroutine(CoolDown_1());
            }
        }
    }

    void Shoot(int bulletType)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = tr.position;
        Vector2 Dir = mousePos - playerPos;



        if (bulletType == 0)
        {
            canShoot_0 = false;

            GameObject bulletObj = Instantiate(bullet, tr.position, Quaternion.identity);

            bulletController = bulletObj.GetComponent<Go>();
            bulletController.Rotation(Dir);
            bulletController.goThrought(Dir);
        } else if(bulletType == 1)
        {
            canShoot_1 = false;

            GameObject bulletObj = Instantiate(Q_bullet, tr.position, Quaternion.identity);

            bulletController = bulletObj.GetComponent<Go>();
            bulletController.Rotation(Dir);
            bulletController.goThrought(Dir);
        }
    }

    IEnumerator CoolDown_0()
    {
        yield return new WaitForSeconds(1.5f);
        canShoot_0 = true;
    }

    IEnumerator CoolDown_1()
    {
        yield return new WaitForSeconds(6f);
        canShoot_1 = true;
    }

    float CalCulateAbs(Vector2 vec)
    {
        float value = vec.x * vec.x + vec.y * vec.y;
        return Mathf.Sqrt(value);
    }
}
