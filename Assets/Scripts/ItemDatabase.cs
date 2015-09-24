using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item> ();
	private ItemDatabase database ;
	
	private Sprite[] Sprites ;
	
	
	//Database must be available before inventory thus on Awake
	void Awake() 
	{
		
		// Sprites = Resources.LoadAll<Sprite>("Tilesets/Items/34x34icons180809");
	 	
	 
		items.Add(new Item("Grapes",0,"Throw the grapes",2,0,Item.ItemType.Weapon)) ;
		items.Add(new Item("Cherry",1,"Not the same as a McCherry",3,1,Item.ItemType.Consumable)) ;		
		
    }
    
	private void MakeSpriteName(string name) 
	{
		for (int i = 0;i < 2; i++)
		{
			Sprites[i].name =  name ;        //TODO
				
		}	
		
		
	}
	                                    	                                    
}



