using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadController : MonoBehaviour
{
    charController cController;
    private void Start()
    {
        cController = GetComponent<charController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="bumDead")
        {
            cController.canMove = false;
            Debug.Log("DEAD");
        }
    }
}
