using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour
{
    public Transform spawnPoint;
    public float respawnDelay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                StartCoroutine(RespawnAfterDelay(player));
            }
        }
    }

    private IEnumerator RespawnAfterDelay(PlayerController player)
    {
        // Hide the player while waiting for the respawn delay.
        player.gameObject.SetActive(false);

        // wait for seconds before respawning
        yield return new WaitForSeconds(respawnDelay);

        // Re-enable before calling Respawn
        player.gameObject.SetActive(true);

        // Pass both position and rotation from the spawn point
        // so the player always respawn in the correct position and
        player.Respawn(spawnPoint.position, spawnPoint.rotation);
    }
}
