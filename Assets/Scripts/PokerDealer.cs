using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerDealer : MonoBehaviour {


	public Card[] cards;
	int[] deck = { 1, 2, 3, 4, 5,
				   6, 7, 8, 9, 10,
				   11, 12, 13, 14, 15,
				   16, 17, 18, 19, 20,
				   21, 22, 23, 24, 25,
				   26, 27, 28, 29, 30};


	List<int> deckCurrent = new List<int>();


	void Start () {
		deckCurrent.AddRange(deck); 

		DealPoker();

	}

	public void DealPoker(){
		
		
		foreach(var card in cards){


        	System.Random rnd = new System.Random(System.DateTime.Now.Millisecond);

        	int index = rnd.Next(deckCurrent.Count);
			var id = deckCurrent[index];

			deckCurrent.RemoveAt(index);

			card.Init(id);

		}

	}
	
}
