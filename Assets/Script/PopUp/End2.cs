using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class End2 : BasePopUp
{
    public List<Toggle> task;
    void Start()
    {

        if (manager.IDPath.Contains("story2-5"))
        {
            task[0].isOn = true;
        }
        if (manager.IDPath.Contains("web1") || manager.IDPath.Contains("story1-15-2"))
        {
            task[1].isOn = true;
        }
        if (manager.IDPath.Contains("app"))
        {
            task[2].isOn = true;
        }
    }

    public void BackHome()
    {
        SceneManager.LoadScene(1);
    }
}
