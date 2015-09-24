using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Inventory : MonoBehaviour {
	
	public int slotsX, slotsY ;
	public GUISkin skin ;
	public List<Item> inventory = new List<Item> () ;
	public List<Item> slots = new List<Item> () ;
	private bool showInventory ;
	private ItemDatabase database ;
	private bool showToolTip ;
	private string tooltip ;
	
	private bool draggingItem ;
	private Item draggedItem ;
	private int prevIndex ;
	
		
	// Use this for initialization
	void Start () {
		for (int i = 0;i < (slotsX * slotsY);i++) 
		{
			slots.Add(new Item()) ;
			inventory.Add(new Item()) ;
		}
	
		database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>() ;
		
		AddItem(0) ;
		AddItem(1) ;
		AddItem(0) ;
		AddItem(1) ;
		AddItem(0) ;
		AddItem(1) ;
		AddItem(0) ;
		AddItem(1) ;
		AddItem(0) ;
		AddItem(1) ;
		AddItem(0) ;
		AddItem(1) ;
		AddItem(0) ;
		AddItem(1) ;
		AddItem(0) ;
		AddItem(1) ;
		AddItem(0) ;
		AddItem(1) ;
		AddItem(0) ;
		AddItem(1) ;
		
		//RemoveItem(0) ;
		//print (InventoryContains(2)) ;
		
		
	}
	void Update()
	{
		if (Input.GetButtonDown("Inventory"))
		{
			showInventory = !showInventory ;
		}
		
	}
	
	void OnGUI ()
	{
		tooltip ="" ;
		GUI.skin =skin ;
		
		if (showInventory)
		{
			DrawInventory() ;
			if (showToolTip)
			{
				GUI.Box(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,200,50), tooltip) ;
			
			}
			if (draggingItem)
			{
				GUI.DrawTexture(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,50,50), draggedItem.itemIcon) ;
			}
		}			
	
	}	
	
	void DrawInventory()
	{
		Event e = Event.current ;
		int i = 0;
		for (int x = 0; x < slotsX; x++)
		{
			for (int y = 0; y < slotsY; y++)
			{
				Rect slotRect = new Rect(x*32,250+y*32,32,32); 
				GUI.Box(slotRect,"",skin.GetStyle("Slot"));
				slots[i] = inventory[i] ;
				if (slots[i].itemName != null)
				{
					GUI.DrawTexture(slotRect,slots[i].itemIcon);      // show tooltip if mouse hovers over box
					if (slotRect.Contains(e.mousePosition))
					
					{	
						tooltip = CreateTooltip(slots[i]);
						showToolTip = true ;
						if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
						{
							draggingItem = true ;				// swap items to each others slot.
							prevIndex = i;
							draggedItem = slots[i] ;
							inventory[i] = new Item() ;
						}	
						if (e.type == EventType.mouseUp && draggingItem)   
						{
							inventory[prevIndex] = inventory[i] ;  // remove item from slot when start dragging
							inventory[i] = draggedItem ;
							draggingItem = false ;
							draggedItem = null;
						
						}														
					}
				}else {												// move item to a empty slot
					if (e.type == EventType.mouseUp && draggingItem)
					{
						inventory[i] = draggedItem ;
						draggingItem = false ;
						draggedItem = null;
						
					}					
					
				}
				if (tooltip == "")
				{
					showToolTip = false ;
				}	
				
				i++ ;
			}
		
		}
	}
	
	string CreateTooltip(Item item) 
	{
		tooltip = item.itemName +"\n" +"<color=#4DA4BF>" +item.itemDesc +"</color>" ;
		return tooltip ;
		
	}
	void RemoveItem (int id)
		
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].itemID == id)
			{
				inventory[i] = new Item();
				break;
				
			}
		}
		
	}
	
	void AddItem (int id)
	
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].itemName == null)
			{
				for (int j = 0;j< database.items.Count;j++)
				{
					if (database.items[j].itemID == id)
					{
						inventory[i] = database.items[j] ;	
					}
				
				}
				break;
				
			}
		}
	
	}
	bool InventoryContains (int id)
	{	
		for (int i = 0; i < inventory.Count; i++)
		{
			print (inventory[i].itemID) ;
			if (inventory[i].itemID == id)
			{
				return true ;
			}
		}
		return false ;
	}
	
	
}
