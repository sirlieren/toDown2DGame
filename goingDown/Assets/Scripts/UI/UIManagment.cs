using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagment : MonoBehaviour
{
    public void tryAgain()
    {
        SceneManager.LoadScene(0);
    }
}
 