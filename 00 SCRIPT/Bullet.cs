using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 2000f;
    Rigidbody2D _rigi;
    Coroutine _DeActiveTime = null;


    // Start is called before the first frame update
    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        _DeActiveTime = StartCoroutine(DeActiveAfterTime());
    }
    private void OnDisable()
    {
        if (_DeActiveTime != null)
        {
            StopCoroutine(_DeActiveTime);
            _DeActiveTime = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        _rigi.velocity = this.transform.up * _speed * Time.deltaTime;
    }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("enemy"))
    //     {
    //         GameManager.Instance.SetScore(1);
    //         Destroy(this.gameObject);
    //         Destroy(collision.gameObject);
    //     }
    // }
    IEnumerator DeActiveAfterTime()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
