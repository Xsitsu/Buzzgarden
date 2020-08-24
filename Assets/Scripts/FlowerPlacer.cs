using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPlacer : MonoBehaviour
{
    static Color ColorClear = new Color(0, 0, 0, 0);
    static Color ColorWhite = new Color(1, 1, 1, 1);
    static Color ColorBad = new Color(1, 0, 0, 1);
    static private FlowerPlacer _instance;
	static public FlowerPlacer Instance { get { return _instance; } }
    public GameObject SpriteTransform;
    public SpriteRenderer PetalsRenderer;
    public SpriteRenderer DetailRenderer;
    public FlowerType flowerType { get; private set; }
    void Awake()
	{
		_instance = this;
	}
    void Start()
    {
        SetFlowerType(null);
    }
    void Update()
    {
        if (flowerType != null)
        {
            Vector3Int cell = TileSelector.Instance.SelectedCell;
            MapTile tile = MapHandler.Instance.Map.GetTileFromCell(cell);
            SpriteTransform.transform.localPosition = new Vector3(cell.x, cell.y, cell.z);
            if (tile != null)
            {
                bool canPlace = (tile.Type == MapTile.TileType.Grass && tile.Flower == null);
                if (canPlace)
                {
                    PetalsRenderer.color = flowerType.FlowerColor;
                    DetailRenderer.color = ColorWhite;

                    if (Input.GetMouseButtonDown(0))
                    {
                        Flower flower = FlowerHandler.Instance.CreateFlower(flowerType);
                        tile.AddFlower(flower);
                        flower.SetPosition(cell.x, cell.y);
                        SetFlowerType(null);
                    }
                }
                else
                {
                    PetalsRenderer.color = ColorBad;
                    DetailRenderer.color = ColorBad;
                }
            }
        }
    }
    public void SetFlowerType(FlowerType flowerType)
    {
        this.flowerType = flowerType;
        if (flowerType != null)
        {
            TileSelector.Instance.Visible = true;
        }
        else
        {
            TileSelector.Instance.Visible = false;
            PetalsRenderer.color = ColorClear;
            DetailRenderer.color = ColorClear;
        }
    }
}
