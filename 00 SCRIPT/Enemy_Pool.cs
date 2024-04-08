using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pool : MonoBehaviour
{
    private static Enemy_Pool _instance;
    public static Enemy_Pool Instance => _instance;

    [SerializeField] GameObject _enemyPF;
    [SerializeField] List<GameObject> _listEnemy = new List<GameObject>();
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
    public GameObject getEnemy()
    {
        foreach (GameObject go in _listEnemy)
        {
            if (go.gameObject.activeSelf)
            {
                continue;
            }
            return go;
        }
        GameObject GO = Instantiate(_enemyPF, this.transform.position, Quaternion.identity, this.transform);
        _listEnemy.Add(GO);
        GO.SetActive(false);
        return GO;

    }
}
