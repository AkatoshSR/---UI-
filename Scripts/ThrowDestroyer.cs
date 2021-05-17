using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDestroyer : MonoBehaviour
{
    [SerializeField] private float lifeTimer = 0.5f;

    private void Start()
    {
        Destroy(gameObject, lifeTimer);
    }
}
