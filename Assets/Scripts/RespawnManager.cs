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

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRespawn()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        BlackScreenFader.Instance.StartFadeAnimation();

        yield return new WaitForSeconds(respawnDelay);

        GameObject playerClone = Instantiate(newPlayer, spawnPoint.position, Quaternion.identity);

        freelookCamera.Follow = playerClone.transform;
        freelookCamera.LookAt = playerClone.transform;

        freelookCamera.PreviousStateIsValid = false;
        freelookCamera.m_YAxis.Value = 0.5f;
        freelookCamera.m_XAxis.Value = 0f;
    }
}
