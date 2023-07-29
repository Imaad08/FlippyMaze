using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throwable : MonoBehaviour
{
    public GameObject objectThrown;
    public Vector3 offset;
    public int throwableCounter;
    public Text collectableCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 throwablePosition = transform.position + offset;
            offset = transform.localScale.x * new Vector3(1, 0, 0);
            
            if (throwableCounter >= 1)
            {
                Debug.Log("Test1");
                Instantiate(objectThrown, throwablePosition, transform.rotation);
                
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (throwableCounter >= 1)
            {
                throwableCounter--;
            }
                
            collectableCounter.text = throwableCounter.ToString();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Collectable")
        {
            
            Destroy(col.gameObject);
            throwableCounter += 1;
            collectableCounter.text = throwableCounter.ToString(); 
        }
        

    }
}
