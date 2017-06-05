using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoodiesController : MonoBehaviour {

	public Sprite soldier_sprite;

	Goodies goodies;
	// Use this for initialization
	void Start () {
		goodies = new Goodies ();

		for (int i = 0; i < goodies.Num; i++) {
			Soldier soldier_data = goodies.GetSolder (i);
			GameObject soldier_go = new GameObject ();
			soldier_go.name = "Solder_" + i;
			soldier_go.transform.position = new Vector3 (soldier_data.Xpos, soldier_data.Ypos, 0);
			Debug.Log ("Xpos, Ypos = " + soldier_data.Xpos + "," + soldier_data.Ypos);
			soldier_go.transform.SetParent (this.transform, true);
			SpriteRenderer soldier_sp =  soldier_go.AddComponent<SpriteRenderer> ();


			if (soldier_data.Type == Soldier.soldierType.Alive) {
				soldier_sp.sprite = soldier_sprite;
			}

			soldier_data.RegisterSoldierMoveCallback ( (soldier) => {OnSoldierMove(soldier, soldier_go);} );
		}
	}

	float Timer = 1f;


	// Update is called once per frame
	void Update () {

		Timer -= Time.deltaTime;

		if (Timer<0) {
			for (int i = 0; i < goodies.Num; i++) {
				goodies.MoveSoldierRand (i);
			}
				
			Timer = 0.01f;
		}
		
	}
	void OnSoldierMove(Soldier soldier_data, GameObject soldier_go){
		soldier_go.transform.position = new Vector3 (soldier_data.Xpos, soldier_data.Ypos, 0);
		soldier_data.Move = Soldier.moved.False;
	}


}
