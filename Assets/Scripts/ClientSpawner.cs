using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public GameObject clientPrefab;
    public Transform[] spawnPoints;

    public Transform[] waypoints; // Añade esta línea para asignar los waypoints de la escena

    public float spawnInterval = 5f;
    public float spawnIntervalRandomOffset = 10f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnClient();
            float randomOffset = Random.Range(-spawnIntervalRandomOffset, spawnIntervalRandomOffset);
            yield return new WaitForSeconds(spawnInterval + randomOffset);
        }
    }

    void SpawnClient()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];
        GameObject client = Instantiate(clientPrefab, spawnPoint.position, spawnPoint.rotation);

        // Aquí pasas los waypoints al script ClientMovement del cliente instanciado
        ClientMovement clientMovement = client.GetComponent<ClientMovement>();
        if (clientMovement != null)
        {
            clientMovement.SetWaypoints(waypoints);
        }
    }
}
