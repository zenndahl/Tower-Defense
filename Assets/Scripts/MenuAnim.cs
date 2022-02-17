using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAim : MonoBehaviour
{

    public void PlayMove(){
        transform.Rotate(0, 45, 0, Space.World);  
    }
}
