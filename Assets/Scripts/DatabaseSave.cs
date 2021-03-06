﻿using UnityEngine; 
using System.Collections; 
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text; 
using System.Collections.Generic;

public class DatabaseSave: MonoBehaviour { 
	
//	// An example where the encoding can be found is at 
//	// http://www.eggheadcafe.com/articles/system.xml.xmlserialization.asp 
//	// We will just use the KISS method and cheat a little and use 
//	// the examples from the web page since they are fully described 
//	
//	// This is our local private members 
//	Rect _Save, _Load, _SaveMSG, _LoadMSG; 
//	bool _ShouldSave, _ShouldLoad,_SwitchSave,_SwitchLoad; 
//	string _FileLocation,_FileName; 
//	private GameObject _Player; 
//	DatabaseData myData; 
//	string _PlayerName; 
//	string _data; 
//	
//	Vector3 VPosition; 
//	private Inventory _Inventory ; 
//	private ItemDatabase database ;
//	private Sprite[] sprites ;
//	
//	// When the EGO is instansiated the Start will trigger 
//	// so we setup our initial values for our local members 
//	void Start () { 
//		// We setup our rectangles for our messages 
//		_Save=new Rect(10,80,100,20); 
//		_Load=new Rect(10,100,100,20); 
//		_SaveMSG=new Rect(10,120,400,40); 
//		_LoadMSG=new Rect(10,140,400,40); 
//		
//		// Where we want to save and load to and from 
//		_FileLocation=Application.dataPath; 
//		_FileName="SaveDataBase.xml"; 
//		
//		// for now, lets just set the name to Joe Schmoe 
//		_PlayerName = "Joe Schmoe"; 
//		//_Inventory = GetComponent<Inventory>() ;
//		_Inventory = GameObject.FindObjectOfType<Inventory>() ;
//		
//		// we need soemthing to store the information into 
//		myData=new DatabaseData(); 
//		database = GameObject.FindObjectOfType<ItemDatabase>() ;
//		sprites = Resources.LoadAll<Sprite> ("Tilesets/Items/34x34icons180709");
//	} 
//	
//	void Update () {} 
//	
//	public void GetData ()
//	{
//		_FileLocation=Application.dataPath; 
//		_FileName="SaveDataBase.xml"; 
//		// we need soemthing to store the information into 
//		myData=new DatabaseData(); 
//		database = GameObject.FindObjectOfType<ItemDatabase>() ;
//		sprites = Resources.LoadAll<Sprite> ("Tilesets/Items/34x34icons180709");
//		LoadXML(); 
//		if (_data.ToString () != "") {
//			// notice how I use a reference to type (UserData) here, you need this 
//			// so that the returned object is converted into the correct type 
//			myData = (DatabaseData)DeserializeObject (_data);
//			// set the players position to the data we loaded 
//			//VPosition = new Vector3 (myData._iUser.x, myData._iUser.y, myData._iUser.z);
//			//_Player.transform.position = VPosition;
//			//myData._iUser.inventory = new List<Item>() ;
//			//_Inventory.showInventory = false;
//			database.items = new List<Item> ();
//			//_Inventory.CreateSlots ();
//			
//			//for (int i = 0; i < 437; i++) {
//			//	database.items.Add (new Item ());
//			//}
//			for (int i = 0; i < myData._iUser.items.Count; i++) {
//				print (myData._iUser.items[i].itemName) ;
//				//database.items [i] = new Item ();
//				
//					database.items.Add(new Item (myData._iUser.items[i].itemName,
//				                             	myData._iUser.items[i].itemID,
//				                             myData._iUser.items[i].itemDesc,
//				                             myData._iUser.items[i].itemPower,
//				                             myData._iUser.items[i].itemSpeed,
//				                             myData._iUser.items[i].itemType));
//				                             
//				                  
//					
//				
//				//	_Inventory.inventory.Add(new Item(	myData._iUser.inventory[i].itemName,
//				//										myData._iUser.inventory[i].itemID,
//				//										myData._iUser.inventory[i].itemDesc,
//				//										myData._iUser.inventory[i].itemPower,
//				//										myData._iUser.inventory[i].itemSpeed,
//				//										myData._iUser.inventory[i].itemType)) ;
//				//					_Inventory.inventory.Add(new Item()) ;
//				//					_Inventory.inventory[i].itemName = myData._iUser.inventory[i].itemName;
//				//					_Inventory.inventory[i].itemID = myData._iUser.inventory[i].itemID ;
//				//					_Inventory.inventory[i].itemDesc = myData._iUser.inventory[i].itemDesc;
//				//					//_Inventory.inventory[i].itemIcon = myData._iUser.inventory[i].itemIcon; 
//				//					_Inventory.inventory[i].itemPower = myData._iUser.inventory[i].itemPower; 
//				//					_Inventory.inventory[i].itemSpeed = myData._iUser.inventory[i].itemSpeed;
//				//					
//				//					_Inventory.inventory[i].itemType = myData._iUser.inventory[i].itemType ;
//				//	_Inventory.inventory[i].itemIcon = sprites[myData._iUser.inventory[i].itemID].texture ;
//				//					
//			}
//			// just a way to show that we loaded in ok 
//			Debug.Log (myData._iUser.name);
//		}
//		
//	}
//	
//	void OnGUI() 
//	{    
//		
//		//*************************************************** 
//		// Loading The Player... 
//		// **************************************************       
//		if (GUI.Button(_Load,"Load")) { 
//			
//			GUI.Label(_LoadMSG,"Loading from: "+_FileLocation); 
//			// Load our UserData into myData 
//			
//			
//			GetData (); 
//			
//		} 
//		
//		//*************************************************** 
//		// Saving The Player... 
//		// **************************************************    
//		if (GUI.Button(_Save,"Save")) { 
//			
//			GUI.Label(_SaveMSG,"Saving to: "+_FileLocation); 
//			//myData._iUser.x=_Player.transform.position.x; 
//			//myData._iUser.y=_Player.transform.position.y; 
//			//myData._iUser.z=_Player.transform.position.z; 
//			//myData._iUser.name=_PlayerName;
//			print ("Count is " +database.items.Count) ; 
//			myData._iUser.items = new List<Item>() ;
//			
//			for (int i = 0; i < database.items.Count;i++)
//			{
//				print ("id is " +database.items[i].itemName) ; 
//				myData._iUser.items.Add(new Item()) ;
//				myData._iUser.items[i].itemName = database.items[i].itemName ; 
//				myData._iUser.items[i].itemID =database.items[i].itemID ; 
//				myData._iUser.items[i].itemDesc =database.items[i].itemDesc ; 
//				//myData._iUser.inventory[i].itemIcon =_Inventory.inventory[i].itemIcon; 
//				myData._iUser.items[i].itemPower =database.items[i].itemPower ; 
//				myData._iUser.items[i].itemSpeed =database.items[i].itemSpeed ; 
//				myData._iUser.items[i].itemType =database.items[i].itemType ;  
//			}
//			
//			
//			
//			// Time to creat our XML! 
//			_data = SerializeObject(myData); 
//			// This is the final resulting XML from the serialization process 
//			CreateXML(); 
//			Debug.Log(_data); 
//		} 
//		
//		
//	} 
//	
//	/* The following metods came from the referenced URL */ 
//	string UTF8ByteArrayToString(byte[] characters) 
//	{      
//		UTF8Encoding encoding = new UTF8Encoding(); 
//		string constructedString = encoding.GetString(characters); 
//		return (constructedString); 
//	} 
//	
//	byte[] StringToUTF8ByteArray(string pXmlString) 
//	{ 
//		UTF8Encoding encoding = new UTF8Encoding(); 
//		byte[] byteArray = encoding.GetBytes(pXmlString); 
//		return byteArray; 
//	} 
//	
//	// Here we serialize our UserData object of myData 
//	string SerializeObject(object pObject) 
//	{ 
//		string XmlizedString = null; 
//		MemoryStream memoryStream = new MemoryStream(); 
//		XmlSerializer xs = new XmlSerializer(typeof(DatabaseData)); 
//		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8); 
//		xs.Serialize(xmlTextWriter, pObject); 
//		memoryStream = (MemoryStream)xmlTextWriter.BaseStream; 
//		XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray()); 
//		return XmlizedString; 
//	} 
//	
//	// Here we deserialize it back into its original form 
//	object DeserializeObject(string pXmlizedString) 
//	{ 
//		XmlSerializer xs = new XmlSerializer(typeof(DatabaseData)); 
//		MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString)); 
//		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8); 
//		return xs.Deserialize(memoryStream); 
//	} 
//	
//	// Finally our save and load methods for the file itself 
//	void CreateXML() 
//	{ 
//		StreamWriter writer; 
//		FileInfo t = new FileInfo(_FileLocation+"\\"+ _FileName); 
//		if(!t.Exists) 
//		{ 
//			writer = t.CreateText(); 
//		} 
//		else 
//		{ 
//			t.Delete(); 
//			writer = t.CreateText(); 
//		} 
//		writer.Write(_data); 
//		writer.Close(); 
//		Debug.Log("File written."); 
//	} 
//	
//	void LoadXML() 
//	{ 
//		StreamReader r = File.OpenText(_FileLocation+"\\"+ _FileName); 
//		string _info = r.ReadToEnd(); 
//		r.Close(); 
//		_data=_info; 
//		Debug.Log("File Read"); 
//	} 
//} 
//
//// UserData is our custom class that holds our defined objects we want to store in XML format 
//public class DatabaseData 
//{ 
//	// We have to define a default instance of the structure 
//	public DemoData _iUser; 
//	//_iUser.inventory = new List<Item> ;
//	
//	// Default constructor doesn't really do anything at the moment 
//	public DatabaseData() { } 
//	
//	// Anything we want to store in the XML file, we define it here 
//	public struct DemoData 
//	{ 
//		public float x; 
//		public float y; 
//		public float z; 
//		public string name; 
//		public List<Item> items ;
//		
//		
//		
//	} 
}
