using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Pool : MonoBehaviour
{
    private static Bullet_Pool _instance;
    public static Bullet_Pool Instance => _instance;
    [SerializeField] GameObject _bulletPF;
    [SerializeField] List<GameObject> _list_bullet = new List<GameObject>();
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            return;
        }
        if (_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
    public GameObject getBullet()
    {
        foreach (GameObject go in _list_bullet)
        {
            if (go.activeSelf)
                continue;
            return go;
        }
        GameObject GO = Instantiate(_bulletPF, this.transform.position, Quaternion.identity, this.transform);
        _list_bullet.Add(GO);
        return GO;

    }
}
