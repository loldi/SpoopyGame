using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;



public class superNewSpawn : MonoBehaviour {
	int totalRooms;
	int nextSmallest;
	int nextLargest;


	//ROOM CLASS

	public class Room : IComparable<Room>
	{
		public int x1;
		public int y1;
		public int x2;
		public int y2;
		public int a;
		public string type;

		
		public Room(int tx1, int ty1, int tx2, int ty2, string tt)
		{
			x1 = tx1;
			y1 = ty1;
			x2 = tx2;
			y2 = ty2;
			a = (x2-x1)*(y2-y1);
			type = tt;
		}
		
		public int CompareTo(Room other)
		{
			if(other == null)
			{
				return 1;
			}
			
			//RETURN DIFFERENCE IN AREA
			return a - other.a;
		}
		
	}

	
	public int COLS = 15;
	public int ROWS = 15;
	float cellSize;
	string[,] map;

	public GameObject hallway;
	public GameObject kitchenTile;
	public GameObject bathroomTile;
	public GameObject diningTile;
	public GameObject ballroomTile;
	public GameObject parlorTile;
	public GameObject studyTile;
	public GameObject stairsTile;
	public GameObject entranceTile;
	public GameObject libraryTile;
	public GameObject everythingelse;
	public List<Room> blueprint = new List<Room>();


	void Start(){
		
		map = new string[COLS,ROWS];
		cellSize = Screen.width/(COLS+6);
		generateMap();
		drawField();
	}
	
	
	
	void generateMap (){
		
		//CLEAR OBJECT ARRAY
		
		blueprint.Clear();

		//CLEAR TILE ARRAY
		
		for (int i = 0; i < COLS; i++) {
			for (int j = 0; j < ROWS; j++) {
				map[i,j] = "empty";
			}
		} 

		//DO THE THING
		hallCut(2, ROWS-2, 0, COLS, "h");

		//COUNT NUMBER OF ROOMS
		totalRooms = blueprint.Count;

		//SORT BY AREA
		blueprint.Sort();

		//INITIALIZE SMALLEST/LARGEST
		nextSmallest = 0;
		nextLargest = totalRooms-1;
		findSmallest(nextSmallest);
		findLargest(nextLargest);
		entryFinder();
		blueprint[nextSmallest].type = "stairs";
		findSmallest(nextSmallest);
		blueprint[nextSmallest].type = "bathroom";

		//SET THE ROOMS
		foreach(Room r in blueprint){
			if (r.type == "empty"){
				if (r.a <= 3){
					//SMALL ROOMS
					pickSmallRoom();
				} else {
					pickLargeRoom();
				}
				r.type=qRoom;
			}
		}
		pushToArray();

		
	}
	

	//THE THING
	void hallCut (int min, int max, int start, int end, String dir){
		if (dir == "h"){
			int hallHPos =  Mathf.FloorToInt(UnityEngine.Random.Range(min, max)); 
			blueprint.Add(new Room(start,hallHPos,end,hallHPos+1, "hallway"));
			hallCut(start+2, end-2, min-2, hallHPos, "v");
			hallCut(start+2, end-2, hallHPos+1, max+2, "v");
		}
		if (dir == "v"){
			int hallVPos =  Mathf.FloorToInt(UnityEngine.Random.Range(min, max)); 
			blueprint.Add(new Room(hallVPos,start, hallVPos+1,end, "hallway"));
			roomCut(0,start, hallVPos, end, "c");
			roomCut(hallVPos+1,start, COLS, end, "c");
		}
	}

	//ANOTHER PART OF THE THING
	void roomCut (int x1, int y1, int x2, int y2, String dir){
		int w = x2-x1;
		int h = y2-y1;
		if (dir == "c"){
			if (w>h){
				dir = "v";
			} else {
				dir = "h";
			}
			if (dir == "v"){
				if (w>=3){
					int r1 = x1+ Mathf.FloorToInt(UnityEngine.Random.Range(1,w-1));
					
					if( ((r1-x1)*(y2-y1)) <= 6){
						blueprint.Add(new Room(x1,y1,r1,y2, "empty"));
					} else {
						roomCut(x1,y1,r1,y2, "c");
					}
					if( ((x2-r1)*(y2-y1)) <= 6){ 
						blueprint.Add(new Room(r1,y1,x2,y2, "empty"));
					} else {
						roomCut(r1,y1,x2,y2, "c");
					}
				} 
			} else if (dir == "h"){
				if (h>=3){
					int r1 = y1 + Mathf.FloorToInt(UnityEngine.Random.Range(1,h-1));
					
					if( ((x2-x1)*(r1-y1)) <= 6){
						blueprint.Add(new Room(x1,y1,x2,r1, "empty"));
					} else {
						roomCut(x1,y1,x2,r1, "c");
					}
					
					if( ((x2-x1)*(y2-r1)) <= 6){
						blueprint.Add(new Room(x1,r1,x2,y2, "empty"));
					} else {
						roomCut(x1,r1,x2,y2, "c");
					}
					
				}
			}
		}
	}

	//MAKE ARRAY OF TILES MATCH LIST OF ROOM "OBJECTS"
	void pushToArray(){
		foreach(Room r in blueprint)
		{
			for (int i=r.x1; i<r.x2; i++){
				for (int j=r.y1; j<r.y2; j++){
					map[i,j] = r.type;
				}
			}
		}
	}


	//PUT THE TILES INTO GAME WORLD
	void drawField(){
		for (int i = 0; i < COLS; i++) {
			for (int j = 0; j < ROWS; j++) {
				if (map[i,j] == "bathroom"){
					
					Instantiate (bathroomTile, new Vector2 (i*15, j*15), Quaternion.identity);
					
				}else if(map[i,j] == "kitchen"){
					
					Instantiate (kitchenTile, new Vector2 (i*15, j*15), Quaternion.identity);
					
				}else if(map[i,j] == "dining"){
					
						Instantiate (diningTile, new Vector2 (i*15, j*15), Quaternion.identity);
					
				}else if(map[i,j] == "parlor"){
					
					Instantiate (parlorTile, new Vector2 (i*15, j*15), Quaternion.identity);
					
				}else if(map[i,j] == "stairs"){
					
					Instantiate (stairsTile, new Vector2 (i*15, j*15), Quaternion.identity);
					
				}else if(map[i,j] == "entrance"){
					
					Instantiate (entranceTile, new Vector2 (i*15, j*15), Quaternion.identity);
					
				}else if(map[i,j] == "study"){
					
					Instantiate (studyTile, new Vector2 (i*15, j*15), Quaternion.identity);
					
				}else if(map[i,j] == "library"){
					
					Instantiate (libraryTile, new Vector2 (i*15, j*15), Quaternion.identity);
					
				}else if(map[i,j] == "ballroom"){
					
					Instantiate (ballroomTile, new Vector2 (i*15, j*15), Quaternion.identity);
					
				}else if(map[i,j] == "hallway"){
					
					Instantiate (hallway, new Vector2 (i*15, j*15), Quaternion.identity);
					
				}else{
					Instantiate (everythingelse, new Vector2 (i*15, j*15), Quaternion.identity);
				}
			}
		}
	}

	//FIND SMALLEST POSSIBLE EMPTY ROOM
	void findSmallest(int comp){
		if (blueprint[comp].type == "empty"){
			nextSmallest = comp;
		} else {
			findSmallest(comp+1);
		}
	}

	//FIND LARGEST POSSIBLE EMPTY ROOM
	void findLargest(int comp){
		if (blueprint[comp].type == "empty"){
			nextLargest = comp;
		} else {
			findLargest(comp-1);
		}
	}

	//SMALL ROOM PICKER
	string qRoom;
	void pickSmallRoom(){
		int gen = Mathf.FloorToInt(UnityEngine.Random.Range(1, 11));
		if (gen == 1){
			qRoom = "bathroom";
		} else if (gen <= 6){;
			qRoom = "study";
		} else if (gen <= 11){
			qRoom = "parlor";
		}
	}

	//LARGE ROOM PICKER
	void pickLargeRoom(){
		int gen = Mathf.FloorToInt(UnityEngine.Random.Range(1, 11));
		if (gen <= 3){
			qRoom = "kitchen";
		} else if (gen <= 5){
			qRoom = "dining";
		} else if (gen <= 7){
			qRoom = "ballroom";
		} else if (gen <= 11){
			qRoom = "library";
		} 
	}

	void entryFinder(){
		int target = 0;
		for(int i = 0; i < totalRooms; i++){
			if (blueprint[i].type == "empty"){
				if (blueprint[i].y2 <= blueprint[target].y2){
					if (blueprint[i].y1 <= blueprint[target].y1){
						target = i;
					}
				}
			}
		}
		blueprint[target].type = "entrance";
	}



}