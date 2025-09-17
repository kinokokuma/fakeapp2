using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S2Page3 : BasePopUp
{
    public TMP_Text[] text1;
    private string[] string1 = { "jint1234", "0891547826", "jint1234@gmail.com" };
    public TMP_Text[] text2, text3;
    private string[] string2 = { "®‘πµÏ", " √√æ°ÿ≈∏√", "456125", "1730125690555", "5 ‰√Ë 2 ß“π", "µ”∫≈ÀÈ«¬¢«“ß Õ”‡¿Õ°”·æß· π ®—ßÀ«—¥π§√ª∞¡" };
    public GameObject animator;
    public GameObject home1,home2,back;
   public void Start()
    {
        startTime = Time.time;
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

    public void BackS()
    {
        manager.OpenChat("story2-16");
        TimeRecord.Instance.SaveRecord(ID, "‰¡Ë ¡—§√", startTime);
        gameObject.SetActive(false);
    }
    public void Back(bool have)
    {
        manager.IDPath.Add("webDin");
        if (have)
        {
            manager.OpenChat("story2-17");
        }
        else
        {
            manager.OpenChat("story2-18");
        }
        TimeRecord.Instance.SaveRecord(ID, "°≈—∫·™∑", startTime);
        gameObject.SetActive(false);
    }

    public void ClickWrite(bool is1)
    {
        if (is1)
        {
            StartCoroutine(Write());
        }
        else
        {
            StartCoroutine(Write2());
        }
    }
    IEnumerator Write()
    {
        for (int i = 0; i < text1.Length; i++)
        {
            print(string1[i].Length);
            for (int j = 0; j < string1[i].Length;j++)
            {
                text1[i].text += string1[i][j];
                print(string1[i][j]);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(2);
        //home1.SetActive(true);
    }
    IEnumerator Write2()
    {
        for (int i = 0; i < text2.Length; i++)
        {
            for (int j = 0; j < string2[i].Length; j++)
            {
                text2[i].text += string2[i][j];
                text3[i].text += string2[i][j];
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.2f);
        }
        home1.SetActive(true);
        StartCoroutine(Popup());
    }
    IEnumerator Popup()
    {
        
        yield return new WaitForSeconds(2.5f);
        animator.SetActive(true);
        SoundManager.Instance.PlaySound(SoundID.ms);
        yield return new WaitForSeconds(3.7f);
        SoundManager.Instance.PlaySound(SoundID.ms);
        yield return new WaitForSeconds(3.5f);
        SoundManager.Instance.PlaySound(SoundID.ms);
        yield return new WaitForSeconds(2.6f);
        SoundManager.Instance.PlaySound(SoundID.ms);
        yield return new WaitForSeconds(2);
        home2.SetActive(true);


    }
    public void fake()
    {
        manager.IDPath.Add("app");
    }
}