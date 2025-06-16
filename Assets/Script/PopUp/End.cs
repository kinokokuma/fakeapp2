using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class End : BasePopUp
{
    public GameObject[] Image;
    public List<Toggle> task;
    void Start()
    {
        StartCoroutine(Count());

        if (manager.IDPath.Contains("story1-10-1"))
        {
            task[0].isOn = true;
        }
        if (manager.IDPath.Contains("story1-16-1")|| manager.IDPath.Contains("story1-15-2"))
        {
            task[1].isOn = true;
        }
        if (manager.IDPath.Contains("story1-19-1"))
        {
            task[2].isOn = true;
        }
    }

    IEnumerator Count()
    {
        for (int i = 0; i < Image.Length; i++)
        {
            yield return new WaitForSeconds(3);
            Image[i].SetActive(false);
        }

    }
    
    public void BackHome()
    {
        SceneManager.LoadScene(1);
    }
}
