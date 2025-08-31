using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop : MonoBehaviour
{
    public GameObject animator, home2;
    void Start()
    {
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

}
