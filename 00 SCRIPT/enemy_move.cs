using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    Rigidbody2D _rigi;
    [SerializeField] float _speed = 200;
    [SerializeField] GameObject target;
    void Start()
    {
        target = GameManager.Instance.player;
        _rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move()
    {
        Quaternion q = this.transform.rotation;
        Vector3 dir = target.transform.position - this.transform.position;
        dir = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        q.eulerAngles = new Vector3(0, 0, angle);
        this.transform.rotation = q;
        _rigi.velocity = dir * _speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player_bullet"))
        {
            Audicontroller.Instance.PlaySound("cannon_02");

            // GameManager.Instance.SetScore(1);
            Obsever.Instance.Notify("Enemy_Kill", 1);

            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }

}
