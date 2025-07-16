using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class End : BasePopUp
{
    public List<Toggle> task;
    void Start()
    {

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
    
    public void BackHome()
    {
        SceneManager.LoadScene(1);
    }
}
