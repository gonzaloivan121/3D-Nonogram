using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour {

    public LevelSelectMenu menu;

    public Sprite lockedSprite;
    public TextMeshProUGUI levelText;

    private int level = 0;
    private Button button;
    private Image image;

    void OnEnable() {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    public void Setup(int _level, bool isUnlocked) {
        level = _level;
        levelText.text = level.ToString();

        if (isUnlocked) {
            image.sprite = null;
            AlterButton(isUnlocked);
        } else {
            image.sprite = lockedSprite;
            AlterButton(isUnlocked);
        }
    }

    void AlterButton(bool isUnlocked) {
        button.enabled = isUnlocked;
        levelText.gameObject.SetActive(isUnlocked);
    }

    public void Clicked() {
        menu.StartLevel(level);
    }
}
