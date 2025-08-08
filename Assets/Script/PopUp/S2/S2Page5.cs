using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S2Page5 : BasePopUp
{
    public TMP_Text[] text1;
    private string[] string1 = { "®‘πµÏ", " √√æ°ÿ≈∏√", "jint1234@gmail.com", "1730125690555" , "0891547826" };
    public GameObject home1,next;
    public void Start()
    {
        startTime = Time.time;
        StartCoroutine(Count(home1));
    }

    public void OpenCount(GameObject obj)
    {
        StartCoroutine(Count(obj));
    }

    IEnumerator Count(GameObject obj)
    {
        yield return new WaitForSeconds(3);
        obj.SetActive(true);
        yield return new WaitForSeconds(1);
        StartCoroutine(Write());
    }


    public void Back(bool have)
    {
        manager.IDPath.Add("web1");
        if (manager.IDPath.Contains("google"))
        {
            manager.OpenChat("story2-9-1");
        }
        else
        {
            manager.OpenChat("story2-9-2");
        }
        
        TimeRecord.Instance.SaveRecord(ID, "°≈—∫·™∑", startTime);
        gameObject.SetActive(false);
    }
    IEnumerator Write()
    {
        for (int i = 0; i < text1.Length; i++)
        {
            print(string1[i].Length);
            for (int j = 0; j < string1[i].Length; j++)
            {
                text1[i].text += string1[i][j];
                print(string1[i][j]);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(1f);
        next.SetActive(true);
    }
}
