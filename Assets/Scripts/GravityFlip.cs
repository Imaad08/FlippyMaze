using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GravityFlip : MonoBehaviour
{
    public GameObject Assassino;

    public Rigidbody2D avatarRigidbody;
    private List<GameObject> keys = new List<GameObject>();
    private List<GameObject> S2keys = new List<GameObject>();

    public bool allKeysCollected = false;
    public bool allKeysCollectedS2 = false;

    public bool didCollide;

    public static int n;
    public static int n2;
    
    public Text CoinTotal;
    public Text PlayAgain;

    public GameObject Coin1;
    public GameObject Coin2;
    public GameObject Coin3;
    public GameObject Coin4;
    public GameObject Coin5;
    public GameObject Coin6;
    public GameObject FireImage;
    public Text CollectablesCounter;
    public Text timerText;
    public Text FirePowerText;
    public bool ResetStart;
    public bool hasFirePower = false;
    public float firePowerDuration = 10.0f;
    public float currentFirePowerTime = 0.0f;
    //public bool dead;

    public GameObject RespawnButton;
    // Start is called before the first frame update
    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        didCollide = false;
        ResetStart = false;
        //dead = false;
        RespawnButton.SetActive(false);
        
        FirePowerText.enabled = false;
        FireImage.SetActive(false);
        PlayAgain.enabled = false;
        // allKeysCollected = false; 
        // allKeysCollectedS2 = false;
        if(currentSceneName == "Level1(1)")
        {
            ResetScene1();
            print("hi");
        }
        if(currentSceneName == "Level2(3)")
        {
            ResetScene2();
        }
    }

    // Update is called once per frame
  //  void Update()
   // {
       /* if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            avatarRigidbody.gravityScale = -1;
            Vector3 newDirection = transform.localScale;
            newDirection.y = -1;
            transform.localScale = newDirection;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            avatarRigidbody.gravityScale = 1;
            Vector3 newDirection = transform.localScale;
            newDirection.z = 1;
            transform.localScale = newDirection;
        }*/
   // }
   private void OnTriggerEnter2D(Collider2D col){
          if(col.gameObject.tag == "Coin 1"){
                Coin1.SetActive(false);
                n++;
                CollectablesCounter.text = n.ToString();
                
          }
          if(col.gameObject.tag == "Coin 2"){
                Coin2.SetActive(false);
                n++;
                CollectablesCounter.text = n.ToString();
                
          }
          if(col.gameObject.tag == "Coin 3"){
                Coin3.SetActive(false);
                n++;
                CollectablesCounter.text = n.ToString();
                
          }
          if(col.gameObject.tag == "Coin 4"){
                Coin4.SetActive(false);
                n2++;
                CollectablesCounter.text = n2.ToString();
                
          }
          if(col.gameObject.tag == "Coin 5"){
                Coin5.SetActive(false);
                n2++;
                CollectablesCounter.text = n2.ToString();
                
          }
          if(col.gameObject.tag == "Coin 6"){
                Coin6.SetActive(false);
                n2++;
                CollectablesCounter.text = n2.ToString();
                
          }
          if (col.gameObject.tag == "FirePower")
        {
            
            col.gameObject.SetActive(false);

            
            hasFirePower = true;
            currentFirePowerTime = 10.0f;
        }
        if (col.CompareTag("Key")) //level 1
        {
            keys.Add(col.gameObject);
            col.gameObject.SetActive(false);
            if (keys.Count == 1)
            {
                allKeysCollected = true;
            }
        }
        if (col.CompareTag("KeyS2")) //level 2
        {
            S2keys.Add(col.gameObject);
            col.gameObject.SetActive(false);
            if (S2keys.Count == 2)
            {
                allKeysCollectedS2 = true;
            }
        }
   }

private void OnCollisionStay2D(Collision2D collision){
    
    if(collision.gameObject.tag == "Wall"){
    
        didCollide = false;
            
        
    }
    if(allKeysCollected == true && collision.gameObject.tag == "Portal"){
        SceneManager.LoadScene(3);
    }
    if(allKeysCollected == false && collision.gameObject.tag == "Portal"){
        Physics2D.gravity = new Vector2(0, -9.8f);
        Assassino.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
    if(allKeysCollectedS2 == true && collision.gameObject.tag == "Portal2"){
        SceneManager.LoadScene(5);
        
    }
    if(allKeysCollectedS2 == false && collision.gameObject.tag == "Portal2"){
        Physics2D.gravity = new Vector2(0, -9.8f);
        Assassino.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
     
        if (!hasFirePower && collision.gameObject.tag == "Fire"){
            gameObject.SetActive(false);
            //dead = true;
            RespawnButton.SetActive(true);
            timerText.enabled = false;
            Physics2D.gravity = new Vector2(0, -9.8f);
            Assassino.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            n=0;
            CollectablesCounter.text = n.ToString();
        }
        if (!hasFirePower && collision.gameObject.tag == "FireS2"){
            gameObject.SetActive(false);
            //dead = true;
            RespawnButton.SetActive(true);
            timerText.enabled = false;
            Physics2D.gravity = new Vector2(0, -9.8f);
            Assassino.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            n2=0;
            CollectablesCounter.text = n2.ToString();
            
        }
         if (hasFirePower && collision.gameObject.tag == "Fire"){
            didCollide = false;

         }
         if (hasFirePower && collision.gameObject.tag == "FireS2"){
            didCollide = false;

         }

    //else 
   // {
   //     didCollide = false;
   // }
    
    
}
void Update(){
        if (didCollide == false && Input.GetKeyDown(KeyCode.RightArrow)){
            Physics2D.gravity = new Vector2(9.8f, 0);
            Assassino.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            didCollide = true;
            //Assassino.transform.Rotate(0.0f, 0.0f, 270.0f, Space.Self);
           

        }
        if (didCollide == false && Input.GetKeyDown(KeyCode.LeftArrow)){
            Physics2D.gravity = new Vector2(-9.8f, 0);
            
            //Assassino.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
            Assassino.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
            didCollide = true;
        }
        if (didCollide == false && Input.GetKeyDown(KeyCode.UpArrow)){
            Physics2D.gravity = new Vector2(0, 9.8f);
           // Assassino.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
            Assassino.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
            didCollide = true;
        }
        if (didCollide == false && Input.GetKeyDown(KeyCode.DownArrow)){
            Physics2D.gravity = new Vector2(0, -9.8f);
            //Assassino.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
            Assassino.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            didCollide = true;
        }
         if (hasFirePower && currentFirePowerTime > 0)
        {
            
            currentFirePowerTime -= Time.deltaTime;
            FirePowerText.enabled = true;
            FireImage.SetActive(true);

            
            if (currentFirePowerTime <= 0)
            {
                currentFirePowerTime = 0.0f;
                hasFirePower = false;
                FirePowerText.enabled = false;
                FireImage.SetActive(false);

                
            }
            UpdateFirePowerText();
        }
    int TotalCoins = n + n2;
    CoinTotal.text = "You collected " + TotalCoins + " out of 6 coins";
    if(TotalCoins <= 5)
    {
        PlayAgain.enabled = true;

    }
    

        
       


}
 private void ResetScene1()
 {
    n=0;


 }
 private void ResetScene2()
 {
    n2=0;


 }
 private void UpdateFirePowerText()
        {
        
        int seconds = Mathf.FloorToInt(currentFirePowerTime % 60);
        FirePowerText.text = seconds.ToString();
        }



        
    }
//}

