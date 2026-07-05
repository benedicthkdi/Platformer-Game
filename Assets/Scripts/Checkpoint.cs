using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool isActivated;

    public Transform spawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isActivated == false)
            {
                isActivated = true;
                RespawnManager.Instance.SetCheckpoint(spawnPoint);
            }
        }
    }
}
