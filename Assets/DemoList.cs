using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoList : MonoBehaviour
{
    
    
    private void Start()
    {
        //Test t = new Test();
        //t.list = new List<int>() { -1, -1 };
        //foreach (int i in t.list)
        //{
        //    Debug.Log(i);
        //}
        //string json = JsonUtility.ToJson(t);
        //PlayerPrefs.SetString("skillList", json);
        //Debug.Log(json);    

        string getID = PlayerPrefs.GetString("skillList");
        var listID = JsonUtility.FromJson<Test>(getID);
        Debug.Log(getID);
        foreach (var item in listID.list)
        {
            Debug.Log(item);
        }
    }


}
[Serializable]
public class Test
{
    public List<int> list;
}
