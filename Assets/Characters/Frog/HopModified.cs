using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopModified : MonoBehaviour
{
    //Materials
    [SerializeField]
    private Material normal;
    [SerializeField]
    private Material trans;
    [SerializeField]
    private Material hop;

    //Are we on the ground?
    bool grounded;

    //Time variables
    private float time;
    public float timeBetweenJumps = 5f;
    public float lengthOfJump = 2f;

    //Force Variables
    public float jumpHeight = 2f;
    public float forwardSpeed = 0.5f;
    private bool hasJumped;

    //Player Transform
    public Transform player;

    //Talk stuff
    private static bool ready;

    //Frog picture
    [SerializeField]
    private GameObject frogPic;

    //Other frogs
    [SerializeField]
    private GameObject otherFrogs;

    private void Start()
    {
        frogPic.SetActive(false);
    }
    void Update()
    {

        //Starts the hopping
        if (ready == true)
        {
            otherFrogs.SetActive(true);
            time += Time.deltaTime;
            if (time > timeBetweenJumps && time < lengthOfJump + timeBetweenJumps)
            {
                gameObject.GetComponent<Renderer>().material = trans;
                frogPic.SetActive(true);
                if (!hasJumped) GetComponent<Rigidbody>().AddForce(0f, jumpHeight, 0, ForceMode.Impulse);
                hasJumped = true;
                gameObject.transform.LookAt(player);
                transform.position = Vector3.MoveTowards(transform.position, player.position, forwardSpeed);
            }
            if (time > lengthOfJump + timeBetweenJumps)
            {
                time = 0;
                hasJumped = false;
            }
        }

        //Changes materials
        if(grounded)
        {
            frogPic.GetComponent<Renderer>().material = normal;
        }
        else
        {
            frogPic.GetComponent<Renderer>().material = hop;
        }
    }
    public static void StartTheHop()
    {
        ready = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ground"))
        {
            grounded = true;
            Debug.Log("You're on the ground");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            grounded = false;
        }
    }
}
