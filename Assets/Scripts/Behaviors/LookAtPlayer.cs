using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    public float damping = 0.5f;
   
    void Update()
    {
        var lookPos = player.position - transform.position;
        lookPos.y = -90;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}
