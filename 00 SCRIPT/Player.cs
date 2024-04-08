using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] float _speed, _speedQuay;
    [SerializeField] GameObject dan;
    [SerializeField] float atkspeed = 3;
    Rigidbody2D _rigi;
    float count = 0;
    void Start()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        move();
        shoot();
    }
    void move()
    {
        Quaternion q = this.transform.rotation;
        float angle = q.eulerAngles.z + _speedQuay * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        q.eulerAngles = new Vector3(0, 0, angle);
        this.transform.rotation = q;
        _rigi.velocity = this.transform.up * _speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
    }
    void shoot()
    {
        count -= Time.deltaTime;
        if (count > 0)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Object_Pooling.Instance.getPreFabs(dan);
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = this.transform.rotation;
            bullet.SetActive(true);
            count = atkspeed;

            Audicontroller.Instance.PlaySound("cannon_01");
        }
    }
}


