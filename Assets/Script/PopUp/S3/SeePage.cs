using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SeePage : BasePopUp
{
    public GameObject first,backbutt;
    public ScrollRect scrollRect;

    void Update()
    {         
        print(scrollRect.verticalNormalizedPosition);
        if(scrollRect.verticalNormalizedPosition < 0.03f)
        {
            first.SetActive(false);
            backbutt.SetActive(true);
        }
    }
    public void back(string name)
    {
        manager.OpenChat(name);
        TimeRecord.Instance.SaveRecord(ID, "¡ÅÑºáª·", startTime);
        gameObject.SetActive(false);
    }
    public void NextPage(string name)
    {
        manager.CreatePopup(name);
        TimeRecord.Instance.SaveRecord(ID, "ä»à¾¨" + name, startTime);
        gameObject.SetActive(false);
    }
    public void countPage()
    {
        StartCoroutine(Count());
    }
    IEnumerator Count()
    {
        yield return new WaitForSeconds(3);
        back("story3-11");
    }
}
