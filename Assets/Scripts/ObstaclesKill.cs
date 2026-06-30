using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesKill : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.StartDie();
        }
    }
}
