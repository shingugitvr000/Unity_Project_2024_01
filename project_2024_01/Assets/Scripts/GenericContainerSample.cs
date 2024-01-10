using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GenericContainerSample : MonoBehaviour
{
    private GenericContainer<int> intContainer;             //���ʸ� int �� ����
    private GenericContainer<string> stringContainer;       //���ʸ� string �� ����
    //private GenericContainer<PlayerController> PlayerControllerContainer;     //���߿� Ŀ���� Ŭ������ �����ؼ� ��� ����
    void Start()
    {
        intContainer = new GenericContainer<int>(5);
        stringContainer = new GenericContainer<string>(10);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))        //1�� ��ư�� ������ ��
        {
            intContainer.Add(Random.Range(0, 100));     // 0 ~ 99 ���� ���� ���ڸ� �ִ´�. 
            DisplayContainerItems(intContainer);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            string randomString = "item " + Random.Range(0, 100); // 0 ~ 99 ���� ���� ���ڸ� �ִ´�. ex) item 0
            stringContainer.Add(randomString);    
            DisplayContainerItems(stringContainer);
        }
    }
    private void DisplayContainerItems<T>(GenericContainer<T> container)    //���ʸ����� ���� �迭�� �����ִ� �Լ� ���� 
    {
        T[] items = container.GetItems();                                   //�μ��� ���� items ���ʸ� �迭�� �Լ��� ���� �����´�.
        string temp = "";                                                   //�ӽ÷� ����� string�� ���� 
        for(int i = 0; i < items.Length; i++)                               //�迭�� ���� ��ŭ for���� ����. 
        {
            if (items[i] != null) temp += items[i].ToString() + " - ";      //�迭�� �����Ͱ� ������� string �� ��ȯ
            else temp += "Empty - ";                                        //�迭�� �����Ͱ� ������� Empty ���ڿ��� ��ȯ 
        }
        Debug.Log(temp);
    }
}
