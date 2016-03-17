using UnityEngine;
using System.Collections;

//public class Stuff
//{
//	public int roomX;
//	public int roomY;
//	public int roomW;
//	public int roomH;
//	public int roomA;
//	public int roomType;
//	
//	public Stuff(int x, int y, int w, int h, int t)
//	{
//		roomX = x;
//		roomY = y;
//	    roomW = w;
//		roomH = h;
//		roomA = w*h;
//		roomType = t;
//	}
//}


public class newSpawn : MonoBehaviour {

	int COLS = 25;
	int ROWS = 25;
	float cellSize;
	string[,] map;
	int hallPos;
	int vPos;

	public GameObject hallway;
	public GameObject kitchenTile;
	public GameObject bathroomTile;
	public GameObject everythingelse;

	void Start(){

		map = new string[COLS,ROWS];

		cellSize = Screen.width/(COLS+6);
		generateMap();

		hallPos = Mathf.FloorToInt(Random.Range(0, ROWS)); 
		addRoom(0,hallPos,COLS,hallPos+1, "hallway");
		vPos = Mathf.FloorToInt(Random.Range(0, COLS)); 
		addRoom(vPos,0,vPos+1,hallPos+1, "hallway");
		vPos = Mathf.FloorToInt(Random.Range(0, COLS)); 
		addRoom(vPos,hallPos,vPos+1,ROWS, "hallway");

		drawField();
	}



	void generateMap (){

		//initialize array to empty
		for (int i = 0; i < COLS; i++) {
			for (int j = 0; j < ROWS; j++) {
				map[i,j] = "empty";
			}
		} 

	}


	void drawField(){
		for (int i = 0; i < COLS; i++) {
			for (int j = 0; j < ROWS; j++) {
				if (map[i,j] == "bathroom"){

					Instantiate (bathroomTile, new Vector2 (i*15, j*15), Quaternion.identity);

				}else if(map[i,j] == "kitchen"){

					Instantiate (kitchenTile, new Vector2 (i*15, j*15), Quaternion.identity);

				}else if(map[i,j] == "hallway"){

					Instantiate (hallway, new Vector2 (i*15, j*15), Quaternion.identity);
					
				}else{
					Instantiate (everythingelse, new Vector2 (i*15, j*15), Quaternion.identity);
				}
			}
		}
	}

	void addRoom(int x1, int y1, int x2, int y2, string roomType){
		for (int i=x1; i<x2; i++){
			for (int j=y1; j<y2; j++){
				map[i,j] = roomType;
			}
		}
	}
}
