using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToLevels : MonoBehaviour
{
    public void OnMouseDown(){
        SceneManager.LoadScene(2);
    }

}
