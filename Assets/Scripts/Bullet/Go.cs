using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go : MonoBehaviour
{
    public float shootSpeed = 20.0f;

    Rigidbody2D rigid;
    Transform tr;
    ParticleSystem ps;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        ps = GetComponent<ParticleSystem>();
        Invoke("Destroy", 1);
    }

    private void FixedUpdate()
    {
        if(ps != null)
        {
            ParticleSystem.MainModule main = ps.main;

            if(main.startRotation.mode == ParticleSystemCurveMode.Constant)
            {
                main.startRotation = -tr.eulerAngles.z * Mathf.Deg2Rad;
            }
        }
    }

    public void goThrought(Vector2 Dir)
    {
        rigid.AddForce(Dir.normalized * shootSpeed, ForceMode2D.Impulse);
    }

    void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    public void Rotation(Vector2 dir)
    {
        // 마우스 거리로부터 각도 계산
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // 축으로부터 방향과 각도의 회전값
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        tr.rotation = rotation;
    }
}
