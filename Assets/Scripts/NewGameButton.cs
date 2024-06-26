using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour
{
    public List<Button> availableLevels = new List<Button>();
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        for (int i = 0; i < availableLevels.Count; i++)
        {
            string levelName = $"Scenes/Level{i + 2}";
            bool isUnlocked = PlayerPrefs.GetInt(levelName) == 1 ? true : false;
            availableLevels[i].interactable = isUnlocked;

            Debug.Log(levelName + "_" + isUnlocked);
        }
    }

    void OnClick()
    {
        Debug.Log("New Game 버튼이 눌렸습니다.");

        //현재 PlayerPrefs에 저장된 모든 기록을 삭제
        PlayerPrefs.DeleteAll();

        for(int i=0; i<availableLevels.Count; i++)
        {
            availableLevels[i].interactable = false;
        }
    }
}
