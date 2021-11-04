using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    private int width;
    private int height;
    private int depth;

    public GameObject cube;
    public GameObject pivot;

    private GameObject[,,] cubes;
    private int[][] shape;

    [Range(0, 4)] public int life = 4;
    [Range(0, 3)] public int level = 1;
    private int actualLevel = 1;
    private readonly int maxLevels = 4;
    private int cubesLeft = 0;

    private Cube previousCube;
    private int previousLife;

    private bool breakMode = true;
    private bool canRewind = true;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Color heartColor;
    public Color winHeartColor = new Color(255, 200, 0);

    public Text levelText;

    public GameObject shapeController;
    public ToogleSwitch toogleSwitch;

    public LevelSelectMenu menu;

    public bool test = false;

    // Start is called before the first frame update
    void Start() {
        toogleSwitch.valueChanged += ChangeGameMode;
        if (test) {
            level = 0;
            actualLevel = 0;
            menu.gameObject.SetActive(false);
        }
        heartColor = hearts[0].color;
        LoadLevel(level);
    }

    // Update is called once per frame
    void Update() {
        if (level != actualLevel) LoadLevel(level);
        if (test) {
            if (Input.GetMouseButtonDown(1)) Rewind();
        }
    }

    public void PreviousLevel() {
        if (level > 1) level--;
    }

    public void NextLevel() {
        if (level < maxLevels-1) level++;
    }

    public void UpdateLevel(int _level) {
        level = _level;
    }

    public void SelectLevel() {
        menu.gameObject.SetActive(true);
    }

    public void LooseLife() {
        if (life > 1) {
            life--;
            UpdateHearts(false);
        } else { 
            LooseGame();
        }
    }

    void UpdateHearts(bool gainedLife) {
        if (gainedLife) {
            hearts[life-1].sprite = fullHeart;
        } else {
            hearts[life].sprite = emptyHeart;
        }
    }

    void LooseGame() {
        print("You Loose!");
        hearts[0].sprite = emptyHeart;
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < depth; z++) {
                    cubes[x, y, z].GetComponent<Cube>().SetGameOver();
                }
            }
        }
    }

    void WinGame() {
        print("You Win!");
        SetWinOnCubes();

        foreach (Image heart in hearts) {
            heart.color = winHeartColor;
        }

        pivot.transform.parent.transform.DOScale(new Vector3(1f, 1f, 1f), 4f);
        pivot.transform.parent.transform.DORotate(new Vector3(0f, 0f, 0f),4f, RotateMode.FastBeyond360);
    }

    void SetWinOnCubes() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < depth; z++) {
                    cubes[x, y, z].GetComponent<Cube>().Win();
                }
            }
        }
    }

    public void LoadLevel(int lvl) {
        actualLevel = lvl;
        levelText.text = actualLevel == 0 ? "Test" : "Level " + lvl;
        shapeController.transform.localScale = Vector3.one;
        switch (lvl) {
            case 0:
                InitializeLevel(Level00.GetSize(), Level00.GetShape());
                break;
            case 1:
                InitializeLevel(Level01.GetSize(), Level01.GetShape());
                break;
            case 2:
                InitializeLevel(Level02.GetSize(), Level02.GetShape());
                break;
            case 3:
                InitializeLevel(Level03.GetSize(), Level03.GetShape());
                break;
            default:
                break;
        }
    }

    void InitializeLevel(int[] _size, int[][] _shape) {
        ResetLevel(_size, _shape);
        Generate();
        SetCubesCanBreak();
        UpdatePivot();
        ChangeGameMode(!breakMode);
    }

    void ResetLevel(int[] _size, int[][] _shape) {
        if (cubes != null) { Array.Clear(cubes, 0, cubes.Length); }
        GameObject[] _cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject _cube in _cubes) Destroy(_cube);
        pivot.transform.position = Vector3.zero;
        SetShapeDimensions(_size);
        cubes = new GameObject[_size[0], _size[1], _size[2]];
        shape = _shape;
        life = 4;
        ResetHearts();
    }

    void ResetHearts() {
        foreach (Image heart in hearts) {
            heart.sprite = fullHeart;
            heart.color = heartColor;
        }
    }

    void SetShapeDimensions(int[] _size) {
        width = _size[0];
        height = _size[1];
        depth = _size[2];
        cubesLeft = width * height * depth;
    }

    void UpdatePivot() {
        Vector3 newPosition = new Vector3(-width / 2f + .5f, -height / 2f + .5f, -depth / 2f + .5f);
        pivot.transform.position = newPosition;
    }

    void SetCubesCanBreak() {
        foreach (int[] _cube in shape) {
            cubes[_cube[0], _cube[1], _cube[2]].GetComponent<Cube>().SetCanBreak(false);
        }
    }

    void Generate() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < depth; z++) {
                    cubes[x, y, z] = Instantiate(cube, new Vector3(x, y, z), transform.rotation, pivot.transform);
                }
            }
        }
    }

    void Rewind() {
        if (canRewind) {
            if (previousLife != life) {
                life++;
                UpdateHearts(true);
            } else {
                previousCube.Unbreak();
            }
            canRewind = false;
        }
    }

    public void BreakCube(Cube _cube) {
        previousCube = _cube;
        previousLife = life;
        cubesLeft--;
        if (cubesLeft == shape.Length) {
            WinGame();
        }
    }

    private void ChangeGameMode(bool value) {
        breakMode = !value;
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < depth; z++) {
                    cubes[x, y, z].GetComponent<Cube>().ChangeGameMode(breakMode);
                }
            }
        }
    }

}
