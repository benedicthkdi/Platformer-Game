using System.Collections;
using UnityEngine;
using Cinemachine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;

    public Transform spawnPoint;
    public float respawnDelay = 1;
    public GameObject newPlayer;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineFreeLook freelookCamera;

    void Awake()
    {
        Instance = this;
    }

    public void StartRespawn()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);

        GameObject playerClone = Instantiate(newPlayer, spawnPoint.position, Quaternion.identity);

        freelookCamera.Follow = playerClone.transform;
        freelookCamera.LookAt = playerClone.transform;
    }
}


