using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SameDistanceChildren : MonoBehaviour
{

	public int CurrentEncounterLength = 2000;
	private int currentEncounterSize = 3;
	public int  MaxSpace = 30;
	public int  Space=30;
	private int glowBorder = 25;
	
	
	
	public GameObject[] slots;

	public int CurrentEncounterSize
	{
		get { return currentEncounterSize; }
		set
		{
			currentEncounterSize = value;
			SetSlotPositions();
		}
	}

	private void Awake()
	{
		SetSlotPositions();
	}

	public void SetSlotPositions()
	{
		
		
		
		Space = (int)(CurrentEncounterLength - currentEncounterSize*OneCardManager.CardWidthWithoutGlow)/(currentEncounterSize-2);
		Space = Math.Min(MaxSpace, Space);
		
		for (int i = 1; i < currentEncounterSize; i++)
		{
			GameObject slot = slots[i];
			int SlotPositionX = (int)(i * (Space + OneCardManager.CardWidthWithoutGlow));
			slot.transform.DOLocalMoveX(SlotPositionX, 0, false);
		}
	}
	
	
	
	
}
