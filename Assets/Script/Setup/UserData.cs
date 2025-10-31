using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;
using UnityEngine.Networking;

public class UserData : MonoBehaviour
{
    public static string UserID;
    public static string Story;
    public static string Solution;
    public static string UserName;
    public static string UserSex;
    public static bool UserPass =false;
    public static bool S2Pass = false;
    //public static ImageUrl data;
    public static int Story1PostIndex;

    public Button next;
    public TMP_InputField inputID;
    public TMP_Dropdown dropdownStory;
    public TMP_Dropdown dropdownSolution;

    public Button nextPage;
    public TMP_InputField inputName;
    public TMP_Dropdown dropdownSex;
    public TMP_Text type;

    public GameObject User;
    public TMP_Text des;

    private string story1Des = "ในเกมนี้ ผู้เล่นสวมบทบาทเป็น “นภัส เอื้อสุทรกุล” อาศัยอยู่ที่จังหวัดสระบุรี มีเพื่อนสนิทสองคนคือ “แม้น” และ “พงศ์” ผู้เล่นยังเป็น{type}ของ “ผิงผิง” หลานสาวที่กำลังจะมาเยี่ยมในวันนี้พร้อมพ่อและแม่ของเธอ\r\nการทำธุรกรรมทางการเงินของผู้เล่นในเนื้อเรื่องจะดำเนินการผ่านธนาคารกุ้งไทย\r\n";
    private string story2Des = "ในเกมนี้ ผู้เล่นสวมบทบาทเป็น “จินต์ สรรพกุลธร” อาศัยอยู่ตำบลห้วยขวาง อำเภอกำแพงแสน จังหวัดนครปฐม ผู้เล่นเป็นเจ้าของที่ดิน 5 ไร่ 2 งาน เลขที่โฉนด 456125 ตั้งอยู่ในพื้นที่ตำบลห้วยขวาง อำเภอกำแพงแสน จังหวัดนครปฐม นอกจากนี้ ผู้เล่นมีเพื่อนสนิทสองคนคือ “หาญ” และ “อุ่ม” และเป็นคุณ{type}ของ “ภูมิ” หลานชายที่อาศัยอยู่กรุงเทพฯ\r\nการทำธุรกรรมทางการเงินของผู้เล่นในเนื้อเรื่องจะดำเนินการผ่านธนาคารกุ้งไทย\r\n";
    private string story3Des = "ในเกมนี้ ผู้เล่นสวมบทบาทเป็น “กานต์ สิริวัฒน์” อาศัยอยู่ที่จังหวัดพระนครศรีอยุธยา มีเพื่อนสนิทสองคนคือ  “เพ็ญ” และ “แสวง” ทั้งสามคนเกษียณจากการทำงานแล้วและกำลังมองหางานเพื่อทำในเวลาว่าง ผู้เล่นยังสนใจธรรมะ และเป็นสมาชิกกลุ่มไลน์ที่พูดคุยเรื่องธรรมะและการทำบุญบริจาคต่าง ๆ\r\nการทำธุรกรรมทางการเงินของผู้เล่นในเนื้อเรื่องจะดำเนินการผ่านธนาคารกุ้งไทย\r\n";


    public void Start()
    {
        DontDestroyOnLoad(this);
        next.onClick.AddListener(() => { User.SetActive(true); });
    }

    public void Update()
    {
        if (inputID.text == string.Empty)
        {
            next.interactable = false;
        }
        else
        {
            next.interactable = true;
        }
        UserID = inputID.text;
        Solution = dropdownSolution.captionText.text;
        Story = dropdownStory.captionText.text;
        type.text = Solution.Split('_')[1];
        if (inputName.text == string.Empty)
        {
            nextPage.interactable = false;
        }
        else
        {
            nextPage.interactable = true;
        }
        UserName = inputName.text;
        UserSex = dropdownSex.captionText.text;
        string replaceString = UserSex == "ชาย" ? "ลุง" : "ป้า";
        if (Story == "Story1")
        {
            des.text = story1Des.Replace("{type}", replaceString);
        }
        else if(Story == "Story2")
        {
            des.text = story2Des.Replace("{type}", replaceString);
        }
        else if (Story == "Story3")
        {
            des.text = story3Des.Replace("{type}", replaceString);
        }
    }

    void extract(string zipPath)
    {
        using (FileStream zipFileToOpen = new FileStream(zipPath, FileMode.OpenOrCreate))
        {
            using (ZipArchive archive = new ZipArchive(zipFileToOpen, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(@"D:\Example\file1.pdf", "file1.pdf");
                archive.CreateEntryFromFile(@"D:\Example\file2.pdf", "file2.pdf");
            }
        }
        UserPass = true;
    }

    IEnumerator GetText(string file_name)
    {
        string url = "https://drive.google.com/file/d/1CBmLGUoZCs7L4AdeQKpOSx84Kwa3ssru/view?usp=drive_link";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {

                string savePath = string.Format("{0}/{1}.zip", Application.persistentDataPath, file_name);
                System.IO.File.WriteAllText(savePath, www.downloadHandler.text);
            }
        }
    }
}
