using System.Collections;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.LoseLife();
        }
    }
}
