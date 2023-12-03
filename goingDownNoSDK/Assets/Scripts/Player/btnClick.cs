using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnClick : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void clickAnim()
    {
        anim.SetBool("clicked",true);   
    }
}
