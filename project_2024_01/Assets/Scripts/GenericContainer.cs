using System.Collections.Generic;
public class GenericContainer<T>
{
    private T[] items;                      //제너릭 배열 생성
    //private List<T> itemList;
    private int curretIndex = 0;            //배열 Index 선언
    public GenericContainer(int capacity)       //생성이 될 때 숫자를 받아와서 배열 갯수를 만든다. 
    {
        items = new T[capacity];
    }
    public void Add(T item)                 //배열에 데이터를 넣는 함수 
    {
        if(curretIndex < items.Length)      //배열의 길이를 검사
        {
            items[curretIndex] = item;      //배열의 index에 맞게 배열에 넣는다. 
            curretIndex++;
        }
    }
    public T[] GetItems()
    {
        return items;
    }
}
