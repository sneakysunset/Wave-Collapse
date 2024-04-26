using UnityEngine;

public enum ECellLandscape
{
    Sea,
    Land,
    Sand,
    Mountain
}

public static class LandscapeCellConversions
{
    public static bool IsLandscapeValid(ECellLandscape cellType, CellTypeLandscape[,] LandScapeGrid, Vector2Int Coordinates)
    {
        switch(cellType)
        {
            case ECellLandscape.Sea:
                return SeaCondition() ;
            case ECellLandscape.Land:
                return LandCondition();
            case ECellLandscape.Sand:
                return SandCondition();
            case ECellLandscape.Mountain:
                return MountainCondition();
            default: return false;
        }
    }

    public static bool SeaCondition()
    {
        return true;
    }

    public static bool LandCondition()
    {
        return true;
    }

    public static bool SandCondition()
    {
        return true;
    }

    public static bool MountainCondition()
    {
        return true;
    }
}
