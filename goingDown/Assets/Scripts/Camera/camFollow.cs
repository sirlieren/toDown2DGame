using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;

public class camFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;

    [Header("Cam Speed")]
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float cameraSpeedMax;
    [SerializeField] private float cameraSpeedMultiply;

    [Header("Changing Color")]
    public Color primaryColor;
    public Color secondaryColor; 
    public float transitionDuration = 2.0f;
    private float transitionTimer = 0.0f;
    private bool toSecondaryColor = true;

    Camera cam;
    private Vector3 velo= Vector3.zero;

    public bool startGame=false;
    private void Start()
    {
        cam = GetComponent<Camera>();
        cam.backgroundColor = primaryColor;


    }
    private void Update()
    {
       
            speedCamValue();
        
      
        cameraColor();
    }

    void cameraColor()
    {
        
            transitionTimer += Time.deltaTime;
            float t = transitionTimer / transitionDuration;

            if (toSecondaryColor)
            {
                cam.backgroundColor = Color.Lerp(primaryColor, secondaryColor, t);
            }
            else
            {
                cam.backgroundColor = Color.Lerp(secondaryColor, primaryColor, t);
            }

            if (transitionTimer >= transitionDuration)
            {
           
                toSecondaryColor = !toSecondaryColor; // Renk geçiþi tamamlandýðýnda diðer renge geçiþ yapýn.
                transitionTimer = 0.0f;
            }
            

       


    }

    public void speedCamValue()
    {
        
        if (cameraSpeed > cameraSpeedMax)
            cameraSpeed = cameraSpeedMax+.1f;
        else
            cameraSpeed += 1 *cameraSpeedMultiply* Time.deltaTime;

        transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
    }
}
