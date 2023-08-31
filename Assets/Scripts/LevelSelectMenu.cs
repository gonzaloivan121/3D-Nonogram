using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour {

    public int totalLevels = 0;
    public int unlockedLevels = 0;

    private LevelButton[] levelButtons;

    private int totalPages = 0; 
    private int currentPage = 0; 
    private int pageItems = 9;

    public GameObject nextButton;
    public GameObject backButton;

    public Game game;

    private bool test;

    void OnEnable() {
        levelButtons = GetComponentsInChildren<LevelButton>();
    }

    // Start is called before the first frame update
    void Start() {
        Refresh();
    }

    public void SetTestMode() {
        unlockedLevels = totalLevels;
        Refresh();
    }

    public void StartLevel(int level) {
        game.UpdateLevel(level);
        gameObject.SetActive(false);
    }

    public void UnlockNextLevel() {
        if (unlockedLevels < totalLevels) {
            unlockedLevels++;
            Refresh();
        }
    }

    public void ClickNext() {
        currentPage++;
        Refresh();
    }

    public void ClickBack() {
        currentPage--;
        Refresh();
    }

    public void Refresh() {
        totalPages = totalLevels / pageItems;

        int index = currentPage * pageItems;
        for (int i = 0; i < levelButtons.Length; i++) {
            int level = index + i + 1;

            if (level <= totalLevels) {
                levelButtons[i].gameObject.SetActive(true);
                levelButtons[i].Setup(level, level <= unlockedLevels);
            } else {
                levelButtons[i].gameObject.SetActive(false);
            }
        }

        CheckButton();
    }

    private void CheckButton() {
        backButton.SetActive(currentPage > 0);
        nextButton.SetActive(currentPage < totalPages);
    }
}
