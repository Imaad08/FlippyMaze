using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scene2Coins : MonoBehaviour
{
    public int RecievedCoins = GravityFlip.n;
    public Text CoinsText;
    // Start is called before the first frame update
    void Start()
    {
        CoinsText.text = RecievedCoins.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
