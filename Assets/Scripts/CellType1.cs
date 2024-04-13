using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellType1 : CellBase
{
    public ECellType[] cellTypes;

    public CellType1()
    {
        cellTypes = new ECellType[4]
        {
            ECellType.Sea,
            ECellType.Land,
            ECellType.Land,
            ECellType.Mountain
        };
    }
}
