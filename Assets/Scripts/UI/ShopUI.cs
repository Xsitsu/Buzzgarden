using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
	static private ShopUI _instance;
	static public ShopUI Instance { get { return _instance; } }
    public GameObject Container;
	public GameObject ShopFrame;
    public GameObject ButtonOpen;
    public GameObject ButtonClose;
    public GameObject Buyables;
	void Awake()
	{
		_instance = this;
	}
	void Start()
	{
        ButtonOpen.GetComponent<Button>().onClick.AddListener(OnOpen);
        ButtonClose.GetComponent<Button>().onClick.AddListener(OnClose);
        OnClose();
	}

	void Update()
	{
        bool canSeeSomething = false;
        foreach (Transform child in Buyables.transform)
        {
            BuyableController controller = child.GetComponent<BuyableController>();
            if (controller != null)
            {
                if (controller.item != null)
                {
                    bool canSee = true;
                    foreach (ShopItemCost cost in controller.item.Costs)
                    {
                        if (PlayerInventory.Instance.GetPollen(cost.Flower.Id) == 0)
                        {
                            canSee = false;
                        }
                    }
                    if (canSee)
                    {
                        controller.Show();
                        canSeeSomething = true;
                    }
                    else
                    {
                        controller.Hide();
                    }
                }
            }
        }

        if (canSeeSomething)
        {
            Show();
        }
        else
        {
            Hide();
        }
	}
    public void Enable()
    {
        gameObject.SetActive(true);
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }
	public void Show()
	{
        Container.SetActive(true);
	}
	public void Hide()
	{
        Container.SetActive(false);
	}
    public void OnOpen()
    {
        ShopFrame.SetActive(true);
        ButtonOpen.SetActive(false);
    }
    public void OnClose()
    {
        ShopFrame.SetActive(false);
        ButtonOpen.SetActive(true);
    }
}
