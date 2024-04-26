using UnityEngine;

public class ContentCellColor : ContentCellBase
{
    public Color itemColor { get; set; }
    public GameObject item;

    public override void CreateContent(int row, int column)
    {
        base.CreateContent(row, column);
        //GameObject.Instantiate(item, );
    }
}
