using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para el Slider
using TMPro;
public class ClientMovement : MonoBehaviour
{
   
    private Transform[] waypoints;
    public int currentWaypoint = 0;
    public float speed = 2f;

    public ClientSpawner spawner;
    public bool orderCompleted = false;

    public static ClientMovement Instance;
    public Transform target;

    [SerializeField] private float timeBeforeExit = 5f;

    [SerializeField] private float countdownTimer = 0f; // visible solo en Inspector (lectura)
    private bool isLeaving = false;
    private bool timerStarted = false;

    [Header("REFERENCIAS DE UI")]
    [SerializeField] private Slider countdownSlider;
    [SerializeField] PointsHUD points;

    public void SetWaypoints(Transform[] points)
    {
        waypoints = points;
        currentWaypoint = 0;
        timerStarted = false;
        isLeaving = false;

        if (countdownSlider != null)
        {
            countdownSlider.gameObject.SetActive(false);
        }
    }

    void Awake()
    {
       
        Instance = this;

        if (countdownSlider != null)
        {
            countdownSlider.maxValue = timeBeforeExit;
            countdownSlider.minValue = 0f;
            countdownSlider.value = 0f;
            countdownSlider.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        points = FindAnyObjectByType<PointsHUD>();
    }
    private void FixedUpdate()
    {
        if (orderCompleted && !isLeaving)
        {
            if (waypoints != null && waypoints.Length > 0)
            {
                target = waypoints[0];
            }
            else
            {
                return;
            }

            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, target.position) < 0.1f ||
                transform.position.z >= target.position.z)
            {
                Destroy(ClientSpawner.Instance.client);
            }
        }
    }

    void Update()
    {
     
        if (isLeaving)
        {
            if (waypoints != null && waypoints.Length > 0)
            {
                target = waypoints[0];
                Vector3 direction = (target.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;

                if (Vector3.Distance(transform.position, target.position) < 0.1f)
                {
                    Destroy(gameObject);
                }
            }
            return;
        }

        if (waypoints != null && currentWaypoint < waypoints.Length)
        {
            Transform nextPoint = waypoints[currentWaypoint];
            Vector3 direction = (nextPoint.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, nextPoint.position) < 0.1f)
            {
                currentWaypoint++;
            }
            return;
        }

        if (!timerStarted && currentWaypoint >= waypoints.Length)
        {
            timerStarted = true;
            countdownTimer = timeBeforeExit;

            if (countdownSlider != null)
            {
                countdownSlider.value = countdownTimer;
                countdownSlider.gameObject.SetActive(true);
            }
        }

        if (timerStarted)
        {
            countdownTimer -= Time.deltaTime;
            if (countdownTimer < 0f) countdownTimer = 0f;

            if (countdownSlider != null)
            {
                countdownSlider.value = countdownTimer;
            }

            if (countdownTimer <= 0f)
            {
                timerStarted = false;
                isLeaving = true;

                if (countdownSlider != null)
                {
                    countdownSlider.gameObject.SetActive(false);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggerEnter");
        if (other.gameObject.tag == "tarrina" && ClientSpawner.Instance.client.tag == "tarrina")
        {
            points.Points += 100;
            Debug.Log("detectat tarrina");
            Destroy(other.gameObject);
            orderCompleted = true;
        }
        else if (other.gameObject.tag == "Polo_maduixa" && ClientSpawner.Instance.client.tag == "Polo_maduixa")
        {
            points.Points += 100;
            Debug.Log("detectat Polo_maduixa");
            Destroy(other.gameObject);
            orderCompleted = true;
        }
        else if (other.gameObject.tag == "Polo_llimona" && ClientSpawner.Instance.client.tag == "Polo_llimona")
        {
            points.Points += 100;
            Debug.Log("detectat Polo_llimona");
            Destroy(other.gameObject);
            orderCompleted = true;
        }
    }

    void GetOut()
    {
        Debug.Log("GetOut() invocado tras temporizador.");
    }
}