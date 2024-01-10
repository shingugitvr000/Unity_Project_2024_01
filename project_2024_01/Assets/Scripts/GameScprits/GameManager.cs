using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;                 //간단한 싱글톤 화

    //플레이어 데이터 
    public int maxHp = 100;
    public int currentHp = 100;
    public int currentExp = 0;
    public float moveSpeed = 10.0f;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
