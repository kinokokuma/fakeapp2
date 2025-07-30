using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S2Page4 : BasePopUp
{
    public string name;
    private float count;
    public TMP_Text[] timeText;
    public GameObject[] page1,page2;
    public AudioClip[] clip1, clip2;
    public GameObject submit;
    public int index;
        public void Start()
    {
        if (UserData.UserSex == "ชาย")
        {
            page1[index].SetActive(true);
        }
        else
        {
            page2[index].SetActive(true);

        }
        StartCoroutine(PlayFirst(clip1[0].length));
        startTime = Time.time;
    }


    IEnumerator Count()
    {
        float time;
        if (SoundManager.Instance.source.isPlaying)
        {
            SoundManager.Instance.source.Stop();
        }
        if (UserData.UserSex == "ชาย")
        {
            SoundManager.Instance.source.PlayOneShot(clip1[index], 1);
            time = clip1[index].length;
        }
        else
        {
            SoundManager.Instance.source.PlayOneShot(clip2[index], 1);
            time = clip2[index].length;

        }
        index++;

        yield return new WaitForSeconds(time);

        
        if (UserData.UserSex == "ชาย")
        {
            SoundManager.Instance.source.PlayOneShot(clip1[index], 1);
            time = clip1[index].length;
        }
        else
        {
            SoundManager.Instance.source.PlayOneShot(clip2[index], 1);
            time = clip2[index].length;

        }
        

        yield return new WaitForSeconds(time);
        if (index >= page1.Length)
        {
            Back();
        }
        else
        {
            if (UserData.UserSex == "ชาย")
            {
                page1[index].SetActive(true);
            }
            else
            {
                page2[index].SetActive(true);

            }
            index++;
        }
    }

    IEnumerator PlayFirst(float time)
    {
        SoundManager.Instance.source.PlayOneShot(clip2[0], 1);
        index++;
        yield return new WaitForSeconds(time);
    }
    IEnumerator Play()
    {
        float time;
        if (UserData.UserSex == "ชาย")
        {
            time=clip1[index].length;
        }
        else
        {
            time = clip2[index].length;

        }
        yield return new WaitForSeconds(time);
        index++;

        NextPage();
        
    }

    public void NextPage()
    {
        if (UserData.UserSex == "ชาย")
        {
            
            StartCoroutine(Count());
        }
        else
        {
            
            StartCoroutine(Count());

        }
        TimeRecord.Instance.SaveRecord(ID, "ฟังเสียงต่อไป", startTime);
    }

    public void Back()
    {

        manager.OpenChat(name);
        TimeRecord.Instance.SaveRecord(ID, "กลับแชท", startTime);
        gameObject.SetActive(false);
    }

    public void ResetTime()
    {
        count = 0;
    }
    public void Update()
    {
        count += Time.deltaTime;
        for (int i = 0; i < timeText.Length; i++)
        {
            timeText[i].text = ConvertSecondsToTime((int)count);
        }
    }
    string ConvertSecondsToTime(int seconds)
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;

        return string.Format("{0:D2}:{1:D2}", minutes, remainingSeconds);
    }
}
