using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour{
    
    public static int Money;
    public static int Lives;
    public int startMoney = 200;
    public int startLives = 5;
    public static int rounds;

    // Start is called before the first frame update
    void Start(){
        Money = startMoney;
        Lives = startLives;
        rounds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
