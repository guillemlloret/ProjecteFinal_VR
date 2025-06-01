using System.Collections;
using System.Collections.Generic;
using Unity.VRTemplate;
using UnityEngine;

public class ClientMovement : MonoBehaviour
{
    private Transform[] waypoints;
    public int currentWaypoint = 0;
    public float speed = 2f;

    public  ClientSpawner spawner;
    public bool orderCompleted = false;

    public static ClientMovement Instance;
    public Transform target;

    public void SetWaypoints(Transform[] points)
    {
        waypoints = points;
        currentWaypoint = 0;
    }
    void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        //if (waypoints == null || currentWaypoint >= waypoints.Length) return;
         target = waypoints[0];
        
        if (orderCompleted)
        {
            
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            //if (Vector3.Distance(transform.position, target.position) > 0.1f && orderCompleted)
            //{
            //    currentWaypoint++;
            //}
            Debug.Log(transform.position);
            if (transform.position == target.position || transform.position.z >= target.position.z)
            {
                Debug.Log("arribat");
                Destroy(ClientSpawner.Instance.client);
            }
        }
        


    }

    void Update()
    {
        if (waypoints == null || currentWaypoint >= waypoints.Length) return;

        Transform target = waypoints[currentWaypoint];

        // Movimiento hacia el waypoint
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypoint++;
        }

        


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "tarrina" && ClientSpawner.Instance.client.tag == "tarrina")
        {
            Debug.Log("detectat");
            //Destroy(ClientSpawner.Instance.client);
            Destroy(other.gameObject);
            orderCompleted = true;
            //GetOut();
            
        }

        else if (other.gameObject.tag == "Polo_maduixa" && ClientSpawner.Instance.client.tag == "Polo_maduixa")
        {
            Debug.Log("detectat");
            //Destroy(ClientSpawner.Instance.client);
            Destroy(other.gameObject);
            orderCompleted = true;
            //GetOut();
        }

        else if (other.gameObject.tag == "Polo_llimona" && ClientSpawner.Instance.client.tag == "Polo_llimona")
        {
            Debug.Log("detectat");
            //Destroy(ClientSpawner.Instance.client);
            Destroy(other.gameObject);
            orderCompleted = true;
            //GetOut();
        }
    }
    void GetOut()
    {

        if (orderCompleted == true)
        {
            Debug.Log("orderCompleted");
            target = waypoints[0];
            Debug.Log(target);
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.position) > 0.1f && orderCompleted)
        {
            currentWaypoint--;
        }
    }

   
}