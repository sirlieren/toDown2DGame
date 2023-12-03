using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruits : MonoBehaviour
{
    public int fruitScore;
    public GameObject popUp;
    private charController cc;
    private Animator anim;
    void Start()
    {
        //cc=GameObject.FindGameObjectWithTag("Player").GetComponent<charController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            cc = collision.GetComponent<charController>();
            GameObject PopUp=Instantiate(popUp,transform);
            anim.SetTrigger("destroy");
            cc.score += fruitScore;
            Destroy(PopUp, 1);
            Destroy(this.gameObject,1);  
        }
    }
}
