using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyCollision : MonoBehaviour
{
    // Start is called before the first frame update


    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("hi");
        if (col.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }
}
