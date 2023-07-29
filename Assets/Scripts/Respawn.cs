using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawn : MonoBehaviour
{
    
    public void ResetTheGame(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        
    }

}
