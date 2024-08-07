﻿using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class CellTypeNumber : ConditionCellBase<int>
{
    public TextMeshProUGUI[] texts;
    private TextMeshProUGUI prefab;
    private Transform parent;
    int Row;
    int Col;
    public CellTypeNumber() { }
    public CellTypeNumber(int _row, int _column, TextMeshProUGUI txtPrefab, Transform parent)
        : base(_row, _column)
    {
        cellTypes = new List<int>();
        texts = new TextMeshProUGUI[9];
        for(int i = 1; i <= 9; i++)
        {
            cellTypes.Add(i);
            texts[i - 1] = TextMeshProUGUI.Instantiate(txtPrefab, new Vector3(_row * 10 + (i - 1) % 3 * 3, _column * 10 + Mathf.FloorToInt((i - 1) / 3) * 3, 0), Quaternion.identity, parent);
            texts[i - 1].text = i.ToString();
        }
        this.parent = parent;
        prefab = txtPrefab;
        Row = _row;
        Col = _column;

    }

    public override bool SetCellEntropy(int entropyIndex)
    {
        if (!cellTypes.Contains(entropyIndex))
        {
            return false;
        }
        cellTypes = new List<int>() { entropyIndex };
        base.SetCellEntropy(entropyIndex);
        UpdateTexts();
        return true;
    }

    private void UpdateTexts()
    {
        foreach(var text in texts)
        {
            GameObject.DestroyImmediate(text.gameObject);
        }
        texts = new TextMeshProUGUI[cellTypes.Count];
        for(int i = 0; i < cellTypes.Count; i++)
        {
            texts[i] = TextMeshProUGUI.Instantiate(prefab, new Vector3(Row * 10 + (i) % 3 * 3, Col * 10 + Mathf.FloorToInt((i) / 3) * 3, 0), Quaternion.identity, parent);
            texts[i].text = cellTypes[i].ToString();
        }
    }

    public void UpdateEntropy(CellTypeNumber[,] conditionArray)
    {
        for (int i = 0; i < conditionArray.GetLength(0); i++)
        {
            List<int> cellNums = conditionArray[i, column].cellTypes;
            if (cellNums.Count == 1 && cellTypes.Contains(cellNums.First())) 
            {
                cellTypes.Remove(cellNums.First());
/*                for(int v = cellTypes.Count - 1; v >= 0; v--)
                {
                    if (cellNums[0].i == cellTypes[v].i)
                    {
                        cellTypes.RemoveAt(v);
                        continue;
                    }
                }*/
            }
        }
        for (int i = 0; i < conditionArray.GetLength(1); i++)
        {
            List<int> cellNums = conditionArray[row, i].cellTypes;
            if (cellNums.Count == 1 && cellTypes.Contains(cellNums.First()))
            {
                cellTypes.Remove(cellNums.First());
            }
        }
/*        for(int i = 1; i <= 9; i++)
        {
            if (cellTypes.Contains(i + 1)) texts[i].text = (i + 1).ToString();
            else texts[i].text = "";
        }*/
        UpdateTexts();
        base.UpdateEntropy(conditionArray);
    }
}


