using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    [SerializeField] GameObject _player;
    public GameObject player => _player;
    [SerializeField] GameObject _enemyPF;
    [SerializeField] List<GameObject> list_spawnpos;
    [SerializeField] int diem = 0, hightscore = 0;
    public int Diem => diem;
    public int Hightscore => hightscore;

    float count = 0;

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
        hightscore = PlayerPrefs.GetInt("HIGHSCORE");
        Obsever.Instance.AddListener("Enemy_Kill", SetScore);
        Obsever.Instance.Notify("ScoreChange", diem);
    }

    void Update()
    {
        Spawn();
    }
    void Spawn()
    {
        count -= Time.deltaTime;
        if (count <= 0)
        {
            Vector2 newPos = list_spawnpos[Random.Range(0, 8)].transform.position;
            GameObject enemy = Object_Pooling.Instance.getPreFabs(_enemyPF);
            enemy.transform.position = newPos;
            enemy.SetActive(true);
            count = 4;
        }
    }
    public void SetScore(object i)
    {
        diem += (int)i;
        if (hightscore < diem)
        {
            hightscore = diem;
        }
        Obsever.Instance.Notify("ScoreChange", diem);
        PlayerPrefs.SetInt("HIGHSCORE", hightscore);

    }


}

