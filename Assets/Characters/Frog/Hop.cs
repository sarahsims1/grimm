using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hop : MonoBehaviour
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
    public float timeBetweenJumpsmax = 0.8f;
    public float timeBetweenJumpsMin = 0.1f;
    public float lengthOfJump = 2f;

    //Force Variables
    public float jumpHeight = 2f;
    public float forwardSpeed = 0.5f;
    private bool hasJumped;

    //Player Transform
    public Transform player;

    //Frog picture
    [SerializeField]
    private GameObject frogPic;
    void Update()
    {
        time += Time.deltaTime;
        float timeBetween = Random.Range(timeBetweenJumpsMin, timeBetweenJumpsmax);
        if(time > timeBetween && time < lengthOfJump+timeBetween)
        {
            gameObject.GetComponent<Renderer>().material = trans;
            frogPic.SetActive(true);
            if (!hasJumped) GetComponent<Rigidbody>().AddForce(0f, jumpHeight, 0, ForceMode.Impulse);
            hasJumped = true;
            gameObject.transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position,player.position,forwardSpeed);
        }
        if(time > lengthOfJump + timeBetween)
        {
            time = 0;
            hasJumped = false;
        }
        if (grounded)
        {
            frogPic.GetComponent<Renderer>().material = normal;
        }
        else
        {
            frogPic.GetComponent<Renderer>().material = hop;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Frog"))
        {
            grounded = true;
            Debug.Log("You're on the ground");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Frog"))
        {
            grounded = false;
        }
    }
}
