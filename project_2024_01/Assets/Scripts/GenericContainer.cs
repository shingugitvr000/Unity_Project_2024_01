using System.Collections.Generic;
public class GenericContainer<T>
{
    private T[] items;                      //���ʸ� �迭 ����
    //private List<T> itemList;
    private int curretIndex = 0;            //�迭 Index ����
    public GenericContainer(int capacity)       //������ �� �� ���ڸ� �޾ƿͼ� �迭 ������ �����. 
    {
        items = new T[capacity];
    }
    public void Add(T item)                 //�迭�� �����͸� �ִ� �Լ� 
    {
        if(curretIndex < items.Length)      //�迭�� ���̸� �˻�
        {
            items[curretIndex] = item;      //�迭�� index�� �°� �迭�� �ִ´�. 
            curretIndex++;
        }
    }
    public T[] GetItems()
    {
        return items;
    }
}
