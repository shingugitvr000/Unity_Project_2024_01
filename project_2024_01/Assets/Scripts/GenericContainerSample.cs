using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GenericContainerSample : MonoBehaviour
{
    private GenericContainer<int> intContainer;             //제너릭 int 로 선언
    private GenericContainer<string> stringContainer;       //제너릭 string 로 선언
    //private GenericContainer<PlayerController> PlayerControllerContainer;     //나중에 커스텀 클래스로 선언해서 사용 가능
    void Start()
    {
        intContainer = new GenericContainer<int>(5);
        stringContainer = new GenericContainer<string>(10);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))        //1번 버튼을 눌렀을 떄
        {
            intContainer.Add(Random.Range(0, 100));     // 0 ~ 99 까지 랜덤 숫자를 넣는다. 
            DisplayContainerItems(intContainer);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            string randomString = "item " + Random.Range(0, 100); // 0 ~ 99 까지 랜덤 숫자를 넣는다. ex) item 0
            stringContainer.Add(randomString);    
            DisplayContainerItems(stringContainer);
        }
    }
    private void DisplayContainerItems<T>(GenericContainer<T> container)    //제너릭으로 만든 배열을 보여주는 함수 구현 
    {
        T[] items = container.GetItems();                                   //인수로 들어온 items 제너릭 배열을 함수로 통해 가저온다.
        string temp = "";                                                   //임시로 사용할 string을 선언 
        for(int i = 0; i < items.Length; i++)                               //배열의 길이 만큼 for문을 돈다. 
        {
            if (items[i] != null) temp += items[i].ToString() + " - ";      //배열에 데이터가 있을경우 string 로 변환
            else temp += "Empty - ";                                        //배열에 데이터가 없을경우 Empty 문자열로 변환 
        }
        Debug.Log(temp);
    }
}
