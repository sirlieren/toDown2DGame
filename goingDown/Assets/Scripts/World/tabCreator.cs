using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tabCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] tabs;
    [SerializeField] private GameObject[] badTabs;
    private GameObject[] currentTabs;

    [SerializeField] private int maxTab = 15;
    [SerializeField] private float spawnSpeed;

    [SerializeField] private float spawnPosXmin, spawnPosXmax;
    [SerializeField] private float spawnPosYmin, spawnPosYmax;
    private float currentYpos=0;

    private GameObject destroyIt;


    bool isCreatedTab = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!isCreatedTab&&gameObject.transform.childCount<25)
        {
            creatTab();
        }
        
    }
    
    void creatTab()
    {
        isCreatedTab = true;
        float spawnPosX=Random.Range(spawnPosXmin, spawnPosXmax);
        float spawnPosY = Random.Range(spawnPosYmin, spawnPosYmax);

        currentYpos -= spawnPosY;

        Vector3 createPos= new Vector3(spawnPosX, currentYpos, 0);
        int whichTab = Random.Range(0, tabs.Length);

        GameObject newTab= Instantiate(tabs[whichTab], createPos, default);
        newTab.transform.parent = transform;
        
        

       
        StartCoroutine(tabCoroutine());
        
        
    }


    IEnumerator tabCoroutine()
    {
        yield return new WaitForSeconds(spawnSpeed);
        isCreatedTab=false;
    }
}
