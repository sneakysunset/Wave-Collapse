using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellTypeLandscape : ConditionCellBase<ECellLandscape>
{
    //public List<ECellLandscape> cellTypes;
    public CellTypeLandscape() { }

    public CellTypeLandscape(int _row, int _column)
        : base(_row, _column)   
    {
        cellTypes = new List<ECellLandscape>()
        {
            ECellLandscape.Sea,
            ECellLandscape.Land,
            ECellLandscape.Sand,
            ECellLandscape.Mountain
        };
    }

    public override bool SetCellEntropy(int entropyIndex)
    {
        cellTypes = new List<ECellLandscape>() { (ECellLandscape)entropyIndex };
        base.SetCellEntropy(entropyIndex);
        return false;
    }

/*    public override void UpdateEntropy<CellTypeLandscape, J>(WaveCollapseFunction<CellTypeLandscape, J> waveCollapseFunction)
    {
        CellTypeLandscape[,] landscapeGrid = waveCollapseFunction._conditionalGrid;
        for (int i = cellTypes.Count - 1; i >= 0; i--)
        {
*//*            if (!LandscapeCellConversions.IsLandscapeValid(cellTypes[i], landscapeGrid, new Vector2Int(row, column)))
            {
                cellTypes.RemoveAt(i);
            }*//*
        }
        base.UpdateEntropy(waveCollapseFunction);
    }*/


}
