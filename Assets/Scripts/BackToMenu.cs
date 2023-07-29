using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToMenu : MonoBehaviour
{
    public void OnMouseDown(){
        SceneManager.LoadScene(0);
    }
    // Start is called before the first frame update


}
