using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Inventory : MonoBehaviour {
	
	public int slotsX, slotsY ;
	public GUISkin skin ;
	public List<Item> inventory = new List<Item> () ;
	public List<Item> slots = new List<Item> () ;
	public bool showInventory ;
	private ItemDatabase database ;
	private bool showToolTip ;
	private string tooltip ;
	
	public bool draggingItem ;
	public Item draggedItem ;
	public int prevIndex ;
	private _GameSaveLoad gameLoad ;
	
		
	// Use this for initialization
	void Start () {
		//Get the Database list of items	
		database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>() ;
		gameLoad = GameObject.FindObjectOfType<_GameSaveLoad>() ;
		//CreateSlots ();
		gameLoad.GetData() ;
		
		// TEST Adding items into inventroy
		
//		AddItem(0) ;
//		AddItem(100) ;
//		AddItem(10) ;
//		AddItem(110) ;
//		AddItem(120) ;
//		AddItem(130) ;
//		AddItem(140) ;
//		AddItem(150) ;
		
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

	public void CreateSlots ()
	{
		// create dummy empty objects in each visual slot and in each inventrory slot
		for (int i = 0; i < (slotsX * slotsY); i++) {
			slots.Add (new Item ());
			inventory.Add (new Item ());
		}
	}
	
	void OnGUI ()
	{
		tooltip ="" ;
		GUI.skin = skin ;
		
		if (showInventory)
		{
			DrawSlots() ;
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
	
	void DrawSlots()
	{
		
		for (int y = 0; y < slotsY; y++)
		{
			for (int x = 0; x < slotsX; x++)
			{
				
				Rect slotRect = new Rect(x*32,150+y*32,32,32); 
				GUI.Box(slotRect,"",skin.GetStyle("Slot"));
			}
		}		
	
	}
	
	void DrawInventory()
	{
		Event e = Event.current ;
		int i = 0;
		for (int y = 0; y < slotsY; y++)
		{
			for (int x = 0; x < slotsX; x++)
			{
			
				Rect slotRect = new Rect(x*32,150+y*32,32,32); 
				GUI.Box(slotRect,"",skin.GetStyle("Slot"));
				slots[i] = inventory[i] ;
				Item item = slots[i] ; 
				// check to see if the slot has an item in it
				// we do this with itemname as all slots have an instance of item, just not any item information
				if (item.itemName != null)
				{
				// if there is an item, lets draw the items icon within that slot
					GUI.DrawTexture(slotRect,item.itemIcon);      // show tooltip if mouse hovers over box
				// Now lets check to see if the mouses position is within the items slot
					if (slotRect.Contains(e.mousePosition))
					
					{	// show tooltip for item we are hovering over
						if (!draggingItem)
						{	
							tooltip = CreateTooltip(item);
							showToolTip = true ;
						}
					
						
								// right click to do something TODO
						if (e.isMouse && e.type == EventType.mouseDown && e.button == 1)
						{
							if (item.itemType == Item.ItemType.Consumable)
							{
								UseConsumable(item,i,true) ;
							}
							
						}
						
								
						// check to see if the left mouse button was clicked on an ityem and then dragged
						// also check that we are not already dragging an item
														
						if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
						{  	// if we start dragging, set dragging to true, set the dragged item to the item in that slot
							// empty the slot we dragged from (making it an empty slot) and make sure we keep a record
							// of the slot we dragged that item from (so we can swap an item into it if we drop the item onto another)
							
							draggingItem = true ;				
							prevIndex = i;
							draggedItem = item ;
							inventory[i] = new Item() ;
						}	
						
						
						
						// check to see if we released said mouse button while dragging an item
						if (e.type == EventType.mouseUp && draggingItem && inventory[i].itemName != null)   
						{	
						// if so we'll make that slots item equal to the item we were draging
						// also need to set the slot we dragged from to have the item in the slot we dropped the item on
						// (if the slot we dropped on was empty, thats fine) The set that were not dragging an item
						// and set the dragged item to be empty.
							inventory[prevIndex] = item ;  
							inventory[i] = draggedItem ;
							draggingItem = false ;
							draggedItem = null;
						
						}														
					}
					
					
					
				}
				// if itemname does not have naything move item to a empty slot
				
				if (draggingItem && inventory[i].itemName == null && e.type == EventType.mouseUp)
				 {
					if (slotRect.Contains(e.mousePosition))
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
	public void RemoveItem (int id)
		
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
	//use when wanting to add an item to first empty slot
	public void AddItem (int id)
	
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
	// use when wanting to add an item to a specfic slot
	public void AddItem (int id,int slot)
		
	{
		for (int j = 0;j< database.items.Count;j++)
			{
				if (database.items[j].itemID == id)
				{
						inventory[slot] = database.items[j] ;	
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
	
	private void UseConsumable(Item item, int slot, bool deleteItem) 
	{
		switch(item.itemID)
		{
		case 100:
			print ("Use consumable ") ;
			break;
		case 3:
			print ("increased stats ") ;
			break;		
		default:
			break ;
		}	
		if (deleteItem)
		{
			//inventory[slot] = new Item[] ;
		}
	} 
	void SaveInventory()
	
	{
		for (int i = 0; i < inventory.Count;i++)
		{
			PlayerPrefs.SetInt("Inventory " + i, inventory [i].itemID) ;
		}
	}
	void LoadInventory()
	{
		for (int i = 0; i < inventory.Count;i++)
		{
			inventory[i] = PlayerPrefs.GetInt("Inventory " + i, -1) >=0 ? database.items[PlayerPrefs.GetInt ("Inventory "+ i)] : new Item() ;  ;
		}	
	}
		
	
	
}
	
	

