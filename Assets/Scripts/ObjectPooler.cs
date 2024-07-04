using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    
    
    public Queue<GameObject> bullets = new Queue<GameObject>();

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private int bulletCount;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GenerateBullets();
    }

    private void Update()
    {
        HandleBulletSpawnInput();
    }

    private void GenerateBullets()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab);
            
            bulletInstance.SetActive(false);
            bullets.Enqueue(bulletInstance);
            
            
        }
    }

    private void HandleBulletSpawnInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = bullets.Dequeue();
            newBullet.SetActive(true);
        }
    }
}
