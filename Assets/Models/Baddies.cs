using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Baddies{

	Soldier[] badSoldier;
	int num;

	public int Num {
		get {
			return num;
		}
		set {
			num = value;
		}
	}

	int startX;

	public int StartX {
		get {
			return startX;
		}
		set {
			startX = value;
		}
	}

	int startY;

	public int StartY {
		get {
			return startY;
		}
		set {
			startY = value;
		}
	}

	int rowWidth;

	public int RowWidth {
		get {
			return rowWidth;
		}
	}

	public Baddies(int num = 25, int rowWidth = 12, int startX = 0, int startY = 20){
		this.num = num;
		this.startX = startX;
		this.startY = startY;
		this.rowWidth = rowWidth;
		badSoldier = new Soldier[num];
		double part = Math.Ceiling((double)num/(double)rowWidth);

		int soldCount = 0;
		for (int n = 0; n < part; n++) {

			for (int i = (startX); i < rowWidth; i++) {
				if (soldCount == num) {
					break;
				}
				//Debug.Log ("x = " + i + ", y = " + StartY + n);
				badSoldier [soldCount] = new Soldier (i, (startY + n));
				badSoldier [soldCount].Type = Soldier.soldierType.Alive;

				soldCount++;
			}
		}


	}

	public Soldier GetSolder(int num){
		return badSoldier [num];
	}

	public bool isSoldierHere(float x, float y){
		int xint = (int)Math.Ceiling (x);
		int yint = (int)Math.Ceiling (y);

		bool soldierPres = false;
		for (int i = 0; i < num; i++) {

			int xsold = (int) Math.Ceiling(badSoldier [i].Xpos);
			int ysold = (int) Math.Ceiling(badSoldier [i].Ypos);

			if (xsold == xint && ysold == yint) {
				soldierPres = true;

			} else {
				soldierPres = false;
			}

		}
		return soldierPres;


	}

	public void MoveSoldierRand(int num){
		float moveAmount = 0.01f;
		int newMove = UnityEngine.Random.Range (0, 4);

		if (newMove == 0 && badSoldier[num].Ypos + moveAmount < 10 
			&& isSoldierHere(badSoldier[num].Xpos,badSoldier[num].Ypos + moveAmount) == false) {
			badSoldier [num].Ypos += moveAmount;
			badSoldier [num].Move = Soldier.moved.True;
		}
		if (newMove == 1 && badSoldier[num].Ypos - moveAmount > 0
			&& isSoldierHere(badSoldier[num].Xpos,badSoldier[num].Ypos - moveAmount) == false) {
			badSoldier [num].Ypos -= moveAmount;
			badSoldier [num].Move = Soldier.moved.True;
		}
		if (newMove == 2 && badSoldier[num].Xpos + moveAmount < 25
			&& isSoldierHere(badSoldier[num].Xpos + moveAmount,badSoldier[num].Ypos) == false) {
			badSoldier [num].Xpos += moveAmount;
			badSoldier [num].Move = Soldier.moved.True;
		}
		if (newMove == 3 && badSoldier[num].Xpos - moveAmount > 0
			&& isSoldierHere(badSoldier[num].Xpos - moveAmount,badSoldier[num].Ypos) == false) {
			badSoldier [num].Xpos -= moveAmount;
			badSoldier [num].Move = Soldier.moved.True;
		}
	}


}
