using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;                 //������ �̱��� ȭ

    //�÷��̾� ������ 
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
