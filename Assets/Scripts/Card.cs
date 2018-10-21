using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour {

	public int type;
	public string name;
	public int atk;
	public int def;
	public int gold;
	public int hp;
	public int sta;
	public int exp;
	public int id;

	[SerializeField] Text nameText;
	[SerializeField] Text atkText;
	[SerializeField] Text defText;
	[SerializeField] Text staText;
	[SerializeField] Text goldText;
	[SerializeField] Text hpText;
	public void Init (int rId) {
		var data = DataTable.Get<CardData>(rId);
		type = data.type;
		name = data.name;
		atk = data.atk;
		def = data.def;
		gold = data.gold;
		hp = data.hp;
		sta = data.sta;
		exp = data.exp;
		id = data.id;


		nameText.text = name;
		atkText.text = atk.ToString();
		defText.text = def.ToString();
		staText.text = sta.ToString();
		goldText.text = gold.ToString();
		hpText.text = hp.ToString();

		nameText.gameObject.SetActive(true);
		if(type == 1){//怪物卡
			atkText.gameObject.SetActive(true);
			defText.gameObject.SetActive(false);
			staText.gameObject.SetActive(false);
			goldText.gameObject.SetActive(false);
			hpText.gameObject.SetActive(false);
		}
		if(type == 2){//装备卡
			atkText.gameObject.SetActive(false);
			defText.gameObject.SetActive(true);
			staText.gameObject.SetActive(false);
			goldText.gameObject.SetActive(true);
			hpText.gameObject.SetActive(false);
		}
		if(type == 3){//药品卡
			atkText.gameObject.SetActive(false);
			defText.gameObject.SetActive(false);
			staText.gameObject.SetActive(false);
			goldText.gameObject.SetActive(true);
			hpText.gameObject.SetActive(true);
		}
		if(type == 4){//食物卡
			atkText.gameObject.SetActive(false);
			defText.gameObject.SetActive(false);
			staText.gameObject.SetActive(true);
			goldText.gameObject.SetActive(true);
			hpText.gameObject.SetActive(false);
		}
		if(type == 5){//陷进卡
			atkText.gameObject.SetActive(false);
			defText.gameObject.SetActive(true);
			staText.gameObject.SetActive(false);
			goldText.gameObject.SetActive(true);
			hpText.gameObject.SetActive(true);
		}

	}

	public void OnClick_Use() {
		nameText.gameObject.SetActive(false);
		atkText.gameObject.SetActive(false);
		defText.gameObject.SetActive(false);
		staText.gameObject.SetActive(false);
		goldText.gameObject.SetActive(false);
		hpText.gameObject.SetActive(false);

		var player = UIMenu.player;
		var uimenu = GameObject.FindObjectOfType<UIMenu>();
		var checkGold = Mathf.Abs(gold);
		if(type == 1){//怪物卡
			var delta = player.def - atk;
			player.def = Mathf.Max(0, delta);
			if(delta < 0){//护甲消耗完,扣生命
				player.hp += delta;
			}
			player.gold += gold;
		}
		if(type == 2){//装备卡
			if(player.CheckHaveGold(checkGold)){
				player.def += def;
				player.gold += gold;
			}
		}
		if(type == 3){//药品卡
			if(player.CheckHaveGold(checkGold)){
				player.hp += hp;
				player.gold += gold;				
			}

		}
		if(type == 4){//食物卡
			if(player.CheckHaveGold(checkGold)){
				player.sta += sta;
				player.gold += gold;
			}
		}
		if(type == 5){//陷进卡
			player.def += def;
			player.gold += gold;
			player.hp += hp;

		}
		uimenu.Refresh();
		player.CheckIsLive();
	}

}
