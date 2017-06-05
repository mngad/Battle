using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Soldier{
	public enum soldierType { Alive, Dead };

	public enum moved { True, False };

	moved move = moved.False;

	Action<Soldier> cbSoldierMoved;

	public moved Move {
		get {
			return move;
		}
		set {
			move = value;
			if (cbSoldierMoved != null) {
				if(value == moved.True)
					cbSoldierMoved (this);
			}
		}
	}

	soldierType type = soldierType.Dead;

	public soldierType Type {
		get {
			return type;
		}
		set {
			type = value;

		}
	}

	float xpos;

	public float Xpos {
		get {
			return xpos;
		}
		set {
			xpos = value;
		}
	}

	float ypos;

	public float Ypos {
		get {
			return ypos;
		}
		set {
			ypos = value;
		}
	}



	public Soldier(float x, float y){
		this.xpos = x;
		this.ypos = y;

	}

	public void RegisterSoldierMoveCallback(Action<Soldier> callback){
		cbSoldierMoved += callback;
	}
	public void UnRegisterSoldierMoveCallback(Action<Soldier> callback){
		cbSoldierMoved -= callback;
	}





		

}
