using System.Collections;
using Cinemachine;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            RespawnManager.Instance.StartRespawn();
        }
    }
}

