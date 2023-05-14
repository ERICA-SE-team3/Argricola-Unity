using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBakingBread : MonoBehaviour
{
    public Image displayImage; // 클릭한 이미지
    public Image breadImage; // 클릭하면 뜨게될 이미지

    void Start()
    {
        // displayImage 오브젝트 가져오기
        displayImage = GetComponent<Image>();
        breadImage = GetComponent<Image>();

        // displayImage 오브젝트가 null인 경우 오류 처리
        if (displayImage == null)
        {
            Debug.LogError("displayImage is null");
            return;
        }
    }

    void OnClick()
    {
        // breadImage가 null인 경우 오류 처리
        if (breadImage == null)
        {
            Debug.LogError("breadImage is null");
            return;
        }

        // displayImage가 null인 경우 오류 처리
        if (displayImage == null)
        {
            Debug.LogError("displayImage is null");
            return;
        }

        // displayImage에 breadImage 이미지 설정
        breadImage.sprite = displayImage.sprite;
    }

        public void SelectBakingCard()
    {
        OnClick();
    }
}