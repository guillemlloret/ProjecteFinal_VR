using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public GameObject [] clientPrefab;
    public Transform[] spawnPoints;
    public Transform[] waypoints;

    public float spawnInterval = 30f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnClient();
            yield return new WaitForSeconds(spawnInterval); // Tiempo fijo entre cada cliente
        }
    }

    void SpawnClient()
    {
        int index = Random.Range(0, spawnPoints.Length);
        int index_client = Random.Range(0, clientPrefab.Length);
        Transform spawnPoint = spawnPoints[index];
        GameObject client = Instantiate(clientPrefab[index_client], spawnPoint.position, spawnPoint.rotation);

        ClientMovement clientMovement = client.GetComponent<ClientMovement>();
        if (clientMovement != null)
        {
            clientMovement.SetWaypoints(waypoints);
        }
    }
}
