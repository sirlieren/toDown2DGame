using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tabCreator : MonoBehaviour
{
    [SerializeField] private charController cC;
    [SerializeField] private GameObject[] tabs;
    [SerializeField] private GameObject[] badTabs;
    [SerializeField] private GameObject[] fruits;
    private GameObject[] currentTabs;

    [SerializeField] private int maxTab = 15;
    [SerializeField] private float spawnSpeed;

    [SerializeField] private float spawnPosXmin, spawnPosXmax;
    [SerializeField] private float spawnPosYmin, spawnPosYmax;
    private float currentYpos=0;

    private GameObject destroyIt;

    bool createBadTab = false;
    bool isCreatedTab = false;

    public bool startGame=false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(startGame)
        {
            if (!isCreatedTab && gameObject.transform.childCount < 25)
            {
                creatTab();
            }
            if (cC.score > 100)
            {
                createBadTab = true;
            }
        }

        
            

        
    }
    
    void creatTab()
    {
        isCreatedTab = true;
        float spawnPosX=Random.Range(spawnPosXmin, spawnPosXmax);
        float spawnPosY = Random.Range(spawnPosYmin, spawnPosYmax);

        currentYpos -= spawnPosY;

        if(createBadTab)
        {
            Vector3 createPos = new Vector3(spawnPosX, currentYpos, 0);
            int isBadTab=Random.Range(0,10);
            if(isBadTab==8)
            {
                GameObject newTab = Instantiate(badTabs[0], createPos, default);
                newTab.transform.parent = transform;
            }
            else
            {
                
                int whichTab = Random.Range(0, tabs.Length);
                GameObject newTab = Instantiate(tabs[whichTab], createPos, default);
                newTab.transform.parent = transform;
                createFruit(createPos);
            }
          
        }
        else
        {
            Vector3 createPos = new Vector3(spawnPosX, currentYpos, 0);
            int whichTab = Random.Range(0, tabs.Length);
            GameObject newTab = Instantiate(tabs[whichTab], createPos, default);
            newTab.transform.parent = transform;
            createFruit(createPos);
        }
       

      
        
        

       
        StartCoroutine(tabCoroutine());
        
        
    }

    void createFruit(Vector3 creatFrPos)
    {
        int createFruit = Random.Range(0, 11);
        if(createFruit>8)
        {
            int whichFruit=Random.Range(0, fruits.Length);
            GameObject fruit = Instantiate(fruits[whichFruit], creatFrPos+new Vector3(0,.5f,0), default);
            fruit.transform.parent = transform;
            
        }
    }

    IEnumerator tabCoroutine()
    {
        yield return new WaitForSeconds(spawnSpeed);
        isCreatedTab=false;
    }
}
