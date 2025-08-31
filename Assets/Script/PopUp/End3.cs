using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class End3 : BasePopUp
{
    public List<Toggle> task;
    void Start()
    {

        if (manager.IDPath.Contains("story3-8"))
        {
            task[0].isOn = true;
        }
        if (manager.IDPath.Contains("story3-15"))
        {
            task[1].isOn = true;
        }
        if (manager.IDPath.Contains("thunder"))
        {
            task[2].isOn = true;
        }
    }

    public void BackHome()
    {
        SceneManager.LoadScene(1);
    }
}
