using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public GameObject [] clientPrefab;
    public Transform[] spawnPoints;
    public Transform[] waypoints;
    public GameObject[] comanda;

    public float spawnInterval = 30f;

    public bool ClientWaiting = false;

    public static ClientSpawner Instance;
    public GameObject client;


    void Awake()
    {
        Instance = this;    
    }
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
         client = Instantiate(clientPrefab[index_client], spawnPoint.position, spawnPoint.rotation);

        ClientMovement clientMovement = client.GetComponent<ClientMovement>();
        if (clientMovement != null)
        {

            clientMovement.SetWaypoints(waypoints);

            if (ClientWaiting)
            {
                Debug.Log("client arrivat");

                int index_comanda = Random.Range(0, comanda.Length);
                comanda[index_comanda].SetActive(true);
                Debug.Log(comanda[index_comanda]);
            }
        }

        
    }


}
