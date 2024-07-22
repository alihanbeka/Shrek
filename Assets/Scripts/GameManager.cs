using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public GameAssets gameAssets;
    private void Awake()
    {
        instance = this;
    }

}
