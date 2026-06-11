using System.Collections;
using Cinemachine;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Transform spawnPoint;
    public float respawnDelay = 1;
    public GameObject newPlayer;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineFreeLook freelookCamera;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);

        GameObject playerClone = Instantiate(newPlayer, spawnPoint.position, Quaternion.identity);

        freelookCamera.Follow = playerClone.transform;
        freelookCamera.LookAt = playerClone.transform;
    }
}
