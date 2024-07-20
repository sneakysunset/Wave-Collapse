using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConditionalCellType
{

    public void GetCellContent();

    public void SetCellEntropy(int entropyIndex);

    public bool IsCellCollapsed(int cellRow, int cellColumn);   

    public void SetCellCollapsed(bool isCollapsed);
}
