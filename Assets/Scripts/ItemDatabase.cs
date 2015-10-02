using System.Linq ;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item> ();
	private ItemDatabase database ;
	public Texture2D txt;
	private string[] names ;
	private Sprite[] sprites ;
	private DatabaseSave databaseSave ;
	
	
	//Database must be available before inventory thus on Awake
	void Awake() 
	{	
		databaseSave = FindObjectOfType<DatabaseSave>() ;
		LoadData ();
		
	
//		int i = 0;
//		sprites = Resources.LoadAll<Sprite>("Tilesets/Items/34x34icons180709");
//		foreach (Item item in items)
//		{ 
//			
//			print (item.itemName) ;
//			print (sprites[i].name) ;
//			item.itemName = sprites[i].name ;
//			item.itemIcon =  textureFromSprite(sprites[i]) ;
//			i++ ;	
//		}	
		
		
		// names = Resources.LoadAll<string>("Tilesets/Items/names.txt");
		 
		// print ("Sprites " + names.Count()) ;
		 //print (names[0]) ;
		// Print the path of the created asset
		//Debug.Log(AssetDatabase.GetAssetPath(material));
		
	 
		//items.Add(new Item("Grapes",0,"Throw the grapes",2,0,Item.ItemType.Weapon)) ;
		//items.Add(new Item("Cherry",1,"Not the same as a McCherry",3,1,Item.ItemType.Consumable)) ;		
		
    }

	public void LoadData ()
	{
		sprites = Resources.LoadAll<Sprite> ("Tilesets/Items/34x34icons180709");
		for (int j = 0; j < 437; j++) {
		
			items.Add (new Item ("", j, "", 0, 0, Item.ItemType.Consumable));
			//databaseSave.GetData() ;
			items [j].itemName = sprites [j].name;
			items [j].itemIcon = textureFromSprite (sprites [j]);
		}
	}    
	
	
	public static Texture2D textureFromSprite(Sprite sprite)
	{
		if(sprite.rect.width != sprite.texture.width){
			Texture2D newText = new Texture2D((int)sprite.rect.width,(int)sprite.rect.height);
			Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x, 
			                                             (int)sprite.textureRect.y, 
			                                             (int)sprite.textureRect.width, 
			                                             (int)sprite.textureRect.height );
			newText.SetPixels(newColors);
			newText.Apply();
			return newText;
		} else
			return sprite.texture;
	}
	                                    	                                    
}



