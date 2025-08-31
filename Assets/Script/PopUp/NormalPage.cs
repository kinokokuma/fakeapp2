using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPage : BasePopUp
{
    private float startTime;
    public GameObject[] startObject;
    void Start()
    {
        startTime = Time.time;
        foreach (GameObject obj in startObject) 
        {
            StartCoroutine(Count(obj));
        }
    }

    public void back(string name)
    {
        manager.OpenChat(name);
        TimeRecord.Instance.SaveRecord(ID, "¡ÅÑºáª·", startTime);
        gameObject.SetActive(false);
    }
    public void OpenCount(GameObject obj)
    {
        StartCoroutine(Count(obj));
    }

    IEnumerator Count(GameObject obj)
    {
        yield return new WaitForSeconds(3);
        obj.SetActive(true);
    }
    public void NextPage(string name)
    {
        manager.CreatePopup(name);
        TimeRecord.Instance.SaveRecord(ID, "ä»à¾¨"+ name, startTime);
        gameObject.SetActive(false);
    }

    public void AddPath(string name)
    {
        manager.IDPath.Add(name);
    }
}
