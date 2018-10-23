using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMenu : MonoBehaviour {

	public Text hp;
	public Text sta;
	public Text def;
	public Text gold;

	public static Player player = new Player();

	void Start () {

		player.Init();

		hp.text = player.hp.ToString();
		sta.text = player.sta.ToString();
		def.text = player.def.ToString();
		gold.text = player.gold.ToString();
		

	}

	public void Refresh(){
		
		hp.text = player.hp.ToString();
		sta.text = player.sta.ToString();
		def.text = player.def.ToString();
		gold.text = player.gold.ToString();
	}

	public void OnClick_Deal(){
		var dealer = GameObject.FindObjectOfType<PokerDealer>();
		dealer.DealPoker();
	}


}
