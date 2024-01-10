using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenSingleton : GenericSingleton<GenSingleton>
{
    public int playerScore = 0;
    public void AddScore(int amount)
    {
        playerScore += amount;
    }
}
