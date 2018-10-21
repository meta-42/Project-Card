using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player  {

	public int gold;
	public int def;
	public int sta;
	public int hp;
	public int exp;
	public int lv;


	public void Init () {
		gold = 10;
		def = 10;
		sta = 10;
		hp = 20;
		exp = 0;
		lv = 1;
	}

	public bool CheckIsLive(){
		if(hp > 0){
			return true;
		}else{
			Debug.Log("#################you die");
			return false;
		}
	}
	
	public bool CheckHaveGold(int needGold){
		if(gold >= needGold){
			return true;
		}else{
			Debug.Log("你没钱了");
			return false;
		}
	}

}
