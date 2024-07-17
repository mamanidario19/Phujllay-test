using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZorritoNavMeshController : MonoBehaviour
{
    public Animator anim;
    public ZorritoAnimator zorritoAnimator;
    public ZorritoVision zorritoVision;
    public Character character;
    public Transform DestinoZorrito;
    public Transform objective;
    private NavMeshAgent agente;
    private Rigidbody rb;
    public float speedY;
    public float jumpForce = 70f;
    public bool waitStatus = false;
    public bool TrackingStatus = false;
    public bool GuideStatus = false;
    public bool MouseTrackingStatus = false;
    public bool wasWatching = false;
    public bool isSearching = false;
    private Vector3 lastKnownPosition;
    public float searchTimer = 0f;
    private float searchInterval = 5f;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            TrackingStatus = false;
            GuideStatus = false;
            isSearching = false;
            waitStatus = true;
            agente.destination = agente.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            waitStatus = false;
            GuideStatus = false;
            MouseTrackingStatus = false;
            isSearching = false;
            zorritoVision.isWatching = true;
            TrackingStatus = true;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            waitStatus = false;
            TrackingStatus = false;
            MouseTrackingStatus = false;
            GuideStatus = true;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            waitStatus = false;
            GuideStatus = false;
            TrackingStatus = false;
            isSearching = false;
            zorritoVision.isWatching = true;
            MouseTrackingStatus = true;
        }

        if (MouseTrackingStatus == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    agente.destination = hit.point;
                }
            }
            //EL codigo anterior sirve para enviar una ubicacion desde la perspectiva de la camara, y que el personaje se mueva hasta ahi
            //Estilo League Of Legends
        }
        if (TrackingStatus == true)
        {
            if (zorritoVision.isWatching == true)
            {
                wasWatching = true;
                isSearching = false;
                agente.isStopped = false;
                Vector3 direction = (DestinoZorrito.transform.position - agente.transform.position).normalized;
                float distance = 1f;
                Vector3 destino = DestinoZorrito.transform.position - direction * distance;

                agente.destination = destino;
            }
            else
            {
                if (wasWatching)
                {
                    wasWatching = false;
                    lastKnownPosition = transform.position;
                    Invoke("StopAgent", 3f);
                    //Track();
                    Invoke("StartSearching", 4f);
                }
            }
        }
        else if (GuideStatus == true)
        {
            if (zorritoVision.isWatching == true)
            {
                wasWatching = true;
                isSearching = false;
                agente.isStopped = false;
                agente.destination = objective.position;
            }
            else
            {
                if (wasWatching)
                {
                    wasWatching = false;
                    lastKnownPosition = transform.position;
                    Invoke("StopAgent", 2f);
                    //Invoke("StartSniffing", 3.1f);
                    //Track();
                    Invoke("StartSearching", 2f);
                }
            }
        }

        if (isSearching)
        {
            searchTimer += Time.deltaTime;
            if (searchTimer >= searchInterval)
            {
                StartCoroutine(Search());
                searchTimer = 0f;
            }

            if (speedY <= 0.5f)
            {
                zorritoAnimator.Sniff();
            }
            else if (speedY > 0.5)
            {
                zorritoAnimator.NotSniffing();
            }
        }

        if (agente.isOnOffMeshLink)
        {
            zorritoAnimator.Jump();
            //Debug.Log("Estoy saltando");

            //agente.enabled = false;
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //transform.Translate(Vector3.up * jumpForce * Time.deltaTime);            
        }
        else if (!agente.isOnOffMeshLink)
        {
            zorritoAnimator.NotJump();
        }

        speedY = agente.velocity.magnitude;

        //if (agente.velocity.magnitude > 0f)
        //{
        //    zorritoAnimator.Walk();
        //}
        //else if (agente.velocity.magnitude == 0f)
        //{
        //    zorritoAnimator.Idle();
        //}

        anim.SetFloat("speedY", speedY, 0.1f, Time.deltaTime);        
    }

    void StopAgent()
    {
        //Debug.Log("Me detuve");
        agente.destination = agente.transform.position;
        agente.isStopped = true;
        //Track();
    }

    void StartSearching()
    {
        agente.isStopped = false;
        isSearching = true;
    }

    void Track()
    {
        //zorritoAnimator.Sniff();
        Debug.Log("Estoy rastreando");
    }

    IEnumerator Search()
    {    
        //if (agente.velocity.magnitude < 1f)
        //{
        //    zorritoAnimator.Sniff();
        //}
        //else
        //{
        //    zorritoAnimator.NotSniffing();
        //}

        
        Vector3 randomPosition = lastKnownPosition + Random.insideUnitSphere * 4f;
        randomPosition.y = 0;
        agente.destination = randomPosition;
        yield return null;
        //yield return new WaitForSeconds(2);



        //zorritoAnimator.Sniff();
        Track();
    }
}