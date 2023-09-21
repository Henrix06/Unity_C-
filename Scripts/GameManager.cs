using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    [SerializeField]private int currentSouls;
    [SerializeField]private Text  souls;

    public void AddSouls(int soulsToAdd){
        currentSouls += soulsToAdd;
        souls.text = "Souls : "+currentSouls;
    }
}
