using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChatNormal : ChatObjectBase
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Image iconMask;
    [SerializeField]
    private Image postImage;
    [SerializeField]
    private AspectRatioFitter postImageRatio;
    [SerializeField]
    private GameObject nameParent;
    [SerializeField]
    private TMP_Text name;
    [SerializeField]
    private Image contentParent;
    [SerializeField]
    private TMP_Text content;
    [SerializeField]
    private ContentSizeFitter contentSize;
    [SerializeField]
    private Button button;
    [SerializeField]
    private HorizontalLayoutGroup layOutGroup;
    [SerializeField]
    private GameObject guildLineTag;
    [SerializeField]
    private TMP_Text time;
    [SerializeField]
    private TMP_Text readLeft;
    [SerializeField]
    private TMP_Text readRight;
    [SerializeField]
    private Image dataImage;
    [SerializeField]
    private Image bubble;
    [SerializeField]
    private Sprite bubbleRight;

    public GameObject video;
    public GameObject textImage;
    public TMP_Text URLText;
    public Image URLImage;
    public AspectRatioFitter URLImageRatio;
    public GameObject timeparent;
    public override void Initialized(ChatDataDetail data, ChatPopup chatPopup, PopUpManager manager, bool muteSound)
    {
        base.Initialized(data, chatPopup, manager, muteSound);
        data.Content =data.Content.Trim();
        if (data.Icon != string.Empty)
        {
            iconMask.color = new Color32(255,255,255,255);
            icon.sprite = ImageManager.Instance.LoadImage(data.Icon);
        }
        else
        {
            iconMask.color = new Color32(255, 255, 255, 0);
        }
        


        if (data.OnwerName == "my")
        {
            bubble.sprite = bubbleRight;
            //content.alignment = TextAlignmentOptions.MidlineRight;
            layOutGroup.childAlignment = TextAnchor.UpperRight;
            contentParent.color = new Color32(142, 227, 134, 255);
            if (!muteSound)
            {
                SoundManager.Instance.PlaySound(SoundID.chatPop, 0.5f);
            }
            
        }
        else
        {
            if (!muteSound)
            {
                SoundManager.Instance.PlaySound(SoundID.chatPop);
            }
        }

      

        if(data.OnwerName != string.Empty && data.OnwerName!="my")
        {
            nameParent.SetActive(true);
            name.text = data.OnwerName;
            readLeft.gameObject.SetActive(false);
            readRight.gameObject.SetActive(true);
        }
        else
        {
            readLeft.gameObject.SetActive(true);
            readRight.gameObject.SetActive(false);
            nameParent.SetActive(false);
            iconMask.color = new Color32(0, 0, 0, 0);
        }

        if (isSingle)
        {
            nameParent.SetActive(false);
        }

        if (manager.OldChatname == data.OnwerName)
        {
            nameParent.SetActive(false);
            iconMask.color = new Color32(0, 0, 0, 0);
        }
      

        if (data.ChatType == "Button")
        {
            nameParent.SetActive(true);
            button.enabled = data.ChatType == "Button-N"? false:true;
            button.onClick.AddListener(() => ChatButton());
            guildLineTag.SetActive(true);
            postImage.gameObject.SetActive(false);
            contentParent.gameObject.SetActive(false);
            textImage.SetActive(true);
            URLText.text = data.Content;
            if (data.PostImage != "Image/Story3/videoPet")
            {
                URLImage.sprite = ImageManager.Instance.LoadImage(data.PostImage);
            }
            if ((float)URLImage.sprite.texture.width / URLImage.sprite.texture.height > 0)
            {

                URLImageRatio.aspectRatio = (float)URLImage.sprite.texture.width / (float)URLImage.sprite.texture.height;
            }
        }
        else if (data.ChatType == "Button-N")
        {
            textImage.SetActive(true);
            URLText.text = data.Content;
            if (data.PostImage != "Image/Story3/videoPet")
            {
                URLImage.sprite = ImageManager.Instance.LoadImage(data.PostImage);
            }
            if ((float)URLImage.sprite.texture.width / URLImage.sprite.texture.height > 0)
            {
                print((float)URLImage.sprite.texture.width / (float)URLImage.sprite.texture.height);
                URLImageRatio.aspectRatio = (float)URLImage.sprite.texture.width / (float)URLImage.sprite.texture.height;
            }
        }
        else if (data.ChatType == "Time")
        {
            readLeft.gameObject.SetActive(false);
            readRight.gameObject.SetActive(false);
            icon.gameObject.SetActive(false);
            contentParent.gameObject.SetActive(false);
            postImage.gameObject.SetActive(false);
            time.gameObject.SetActive(false);
            time.text = data.Content;
            timeparent.SetActive(false);
            muteSound = true;
        }
        else
        {
            if (data.PostImage != string.Empty && data.PostImage != "Image/Story3/videoPet")
            {
                postImage.gameObject.SetActive(true);
                print("PostImage " + data.PostImage);
                postImage.sprite = ImageManager.Instance.LoadImage(data.PostImage);

                if ((float)postImage.sprite.texture.width / postImage.sprite.texture.height > 0)
                {
                    postImageRatio.aspectRatio = (float)postImage.sprite.texture.width / postImage.sprite.texture.height;
                }

                if (data.PostImage == "Image/Like")
                {
                    postImage.rectTransform.sizeDelta = postImage.rectTransform.sizeDelta / 3.0f;
                }
            }
            else if(data.PostImage == "Image/Story3/videoPet")
            {
                video.SetActive(true);
            }
            else
            {
                postImage.gameObject.SetActive(false);
            }

            if (data.Content == string.Empty)
            {
                contentParent.gameObject.SetActive(false);
            }
            else
            {
                contentParent.gameObject.SetActive(true);
                if (data.Content.Length < 25)
                {
                    contentSize.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
                }
                else
                {
                    contentSize.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
                }
                string text = data.Content.Replace("{name}", UserData.UserName);
                text = text.Replace("{name}", UserData.UserName);
                text = text.Replace("{type}", UserData.UserSex == "ชาย"?"ลุง":"ป้า");
                if (data.OnwerName == "my")
                {
                    if (UserData.UserSex == "ชาย")
                    {
                        text = text.Replace("ค่ะ", "ครับ");
                        text = text.Replace("คะ", "ครับ");
                    }
                }
                content.text = text;
            }
        }
        if (data.showTime == string.Empty || data.showTime == null)
        {
            readLeft.gameObject.SetActive(false);
            readRight.gameObject.SetActive(false);

        }
        else if(data.OnwerName == "my")
        {
            readLeft.text = $"อ่านแล้ว\n{data.showTime}";
            readRight.text = $"อ่านแล้ว\n{data.showTime}";
        }
        else
        {
            readLeft.text = $"\n{data.showTime}";
            readRight.text = $"\n{data.showTime}";
        }
        //StartCoroutine(UpdateLayoutGroup());
        manager.OldChatname = data.OnwerName;
    }

    void Update()
    {
        readLeft.rectTransform.sizeDelta = new Vector2(readLeft.rectTransform.sizeDelta.x, content.rectTransform.sizeDelta.y + 20);
        if (postImage.IsActive())
        {
            readRight.rectTransform.sizeDelta = new Vector2(readRight.rectTransform.sizeDelta.x, postImage.rectTransform.sizeDelta.y + 20);
        }
        else
        {
            readRight.rectTransform.sizeDelta = new Vector2(readRight.rectTransform.sizeDelta.x, content.rectTransform.sizeDelta.y + 20);
        } 
        if (gameObject.transform.localScale != Vector3.one)
        gameObject.transform.localScale = Vector3.one;
    }

    private void ChatButton()
    {

        if (data.LinkType == "page")
        {
            chatPopup.gameObject.SetActive(false);
        }
        else if(data.LinkType == "chat")
        {

        }
        else
        {
            manager.CreatePopup(data.FileName);
        }
        TimeRecord.Instance.SaveRecord(data.ID,$"go to ID : {data.FileName}", timeFromStart);
        button.enabled = false;
        guildLineTag.SetActive(false);
    }
}
