using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Abilities : MonoBehaviour {
	private int maxEnergy = 1000;
	private int curEnergy = 1000;
	private Rigidbody2D r_body;
	private BarScript energyBar;
	// Use this for initialization
	void Start () {
		r_body = GetComponent<Rigidbody2D>();
		energyBar = GameObject.Find("Energy"+(int)GetComponent<Movement>().Player).GetComponent<BarScript>();
	}

	int brakeCost = 10;
	public bool brake(GamePad.Index player, Rigidbody2D r_body){
		if(GamePad.GetButton(GamePad.Button.B, player) && curEnergy >= brakeCost){
			r_body.AddForce(r_body.velocity * -4);
			curEnergy -= brakeCost;
			return true;
		}
		return false;
	}

	int boostCost = 20;
	public bool boost(GamePad.Index player){
		if(GamePad.GetButton(GamePad.Button.X, player) && curEnergy >= boostCost){
			curEnergy -= boostCost;
			return true;
		}
		return false;
	}

	public void addEnergy(){
		if(curEnergy < maxEnergy)
			curEnergy++;
	}

	public void updateUI(){
		energyBar.setBar(curEnergy*100f/maxEnergy);
	}
}
