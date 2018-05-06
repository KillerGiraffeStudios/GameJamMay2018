using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Abilities : MonoBehaviour {
	private int maxEnergy = 1000;
	private int curEnergy = 1000;
	private Rigidbody2D r_body;
	private BarScript energyBar;
	public AudioClip jets;
	public AudioSource jetSource;
	// Use this for initialization
	void Start () {
		r_body = GetComponent<Rigidbody2D>();
		energyBar = GameObject.Find("Energy"+(int)GetComponent<Movement>().Player).GetComponent<BarScript>();
		jetSource.clip = jets;
	}
	
	int brakeCost = 10;
	public bool brake(GamePad.Index player, Rigidbody2D r_body){
		if(curEnergy >= brakeCost){
			if(GamePad.GetButton(GamePad.Button.B, player) && !locked){
				r_body.AddForce(r_body.velocity * -8);
				curEnergy -= brakeCost;
				return true;
			}
		}else{
			lockEnergy();
		}
		return false;
	}

	int boostCost = 20;
	public bool boost(GamePad.Index player){
		if(curEnergy >= boostCost){
			if(!locked){
				if(GamePad.GetButtonDown(GamePad.Button.X, player)){
					jetSource.Play();
				}
				if(GamePad.GetButtonUp(GamePad.Button.X, player)){
					jetSource.Stop();
				}
				if(GamePad.GetButton(GamePad.Button.X, player)){
					curEnergy -= boostCost;
					return true;
				}
			}
		}else{
			jetSource.Stop();
			lockEnergy();
		}
		return false;
	}

	void lockEnergy(){
		locked = true;
		energyBar.lockBar();
	}
	public void unlockEnergy(){
		if(locked && getPercent()>0.33f){
			locked = false;
			energyBar.unlockBar();
		}
	}
	bool locked = false;

	public void addEnergy(){
		if(curEnergy < maxEnergy)
			curEnergy+=2;
		unlockEnergy();
	}

	public float getPercent(){
		return curEnergy*1f/maxEnergy;
	}

	public void updateUI(){
		energyBar.setBar(getPercent());
	}
}
