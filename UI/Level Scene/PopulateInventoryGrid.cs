using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PopulateInventoryGrid : MonoBehaviour
{
    public GameObject cellButton;
    private Sprite[] cells;

    private int toolIndex = 9; // trell

    public GameObject drag;
    public GameObject select;
    public GameObject placeable;

    public PlacementManager placeM;

    private int page = 0;
    private int maxPage;

    void Start() {
        List<Transform> place = placeM.Buttons;
        cells = GameObject.Find("CellLoader").GetComponent<CellLoader>().sprites.ToArray();

        foreach (var cell in cells) {
            GameObject button = Instantiate(cellButton);
            button.transform.SetParent(this.transform);

            button.GetComponent<Image>().sprite = cell;
            button.GetComponent<RectTransform>().localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            button.GetComponent<EditorButtons>().tool = toolIndex;

            place.Add(button.transform);
            toolIndex++;
        }

        placeable.GetComponent<EditorButtons>().tool = toolIndex;
        drag.GetComponent<EditorButtons>().tool = toolIndex + 1;
        select.GetComponent<EditorButtons>().tool = toolIndex + 2;

        place.Add(placeable.transform);
        place.Add(drag.transform);
        place.Add(select.transform);

        placeM.Buttons = place;
        maxPage = (int)Math.Ceiling((double)place.Count / 9) - 1;
        print(maxPage);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.X) && page < maxPage)
            page++;
        else if (Input.GetKeyDown(KeyCode.Z) && page > 0)
            page--;
        this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.gameObject.GetComponent<RectTransform>().anchoredPosition.x, (float)(40.951 + ((-1000 - 40.951) * page)));
    }
}
