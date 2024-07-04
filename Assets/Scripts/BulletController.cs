using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed* Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            ObjectPooler.Instance.bullets.Enqueue(gameObject);
            gameObject.SetActive(false);
            transform.position = Vector3.zero;
        }
    }
}

