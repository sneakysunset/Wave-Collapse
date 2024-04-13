using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICellType
{
    public void GetCellContent();

    public void UpdateEntropy();

    public void SetCellEntropy(int entropyIndex);

    public bool IsCellCollapsed(int cellRow, int cellColumn);   
}
