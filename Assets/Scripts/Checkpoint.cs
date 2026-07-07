using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform spawnPoint;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnManager.Instance.SetSpawnPoint(spawnPoint);
        }
    }
}
