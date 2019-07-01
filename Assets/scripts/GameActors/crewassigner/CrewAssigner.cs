using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Model;
using UnityEngine;
using UnityEngine.Events;

public class CrewAssigner : MonoBehaviour
{
	
	private static Color choosedCrewCounter=new Color32(220,20,60,255);
	
	public static CrewAssigner instance;
	
	public OneCardManager Target;

	public CrewItem[] CrewItems;

	public static UnityEvent crewDeployed=new UnityEvent();


	private void Awake()
	{
	
	}


	// Use this for initialization
	void Start () {
		if (instance == null) { 
			instance = this;  
		} else if(instance == this){ 
			Destroy(gameObject); 
		}
		DontDestroyOnLoad(gameObject);
		instance.gameObject.SetActive(false);
	}
	
	
	
	void Update () {
		
	}

	public void Show(OneCardManager t)
	{
		
		Target = t;
		UpdateCrewDeployed();

		
		HoverPreview preview = Target.gameObject.GetComponent<HoverPreview>();
		preview.ThisPreviewEnabled = false;
		preview.ManualStopPreview = true;
		preview.PreviewThisObject();
		Target.PreviewManager.Highlighted=true;
		
		
			
		
		this.UpdateCrewItems();
		this.transform.position = t.gameObject.transform.position;
		this.transform.DOLocalMoveY(-300, 0);
		this.transform.DOScale(.5f, 0);
		this.gameObject.SetActive(true);
		this.transform.DOScale(1f, .5f);
	}

	private void UpdateCrewDeployed()
	{
		crewDeployed.RemoveAllListeners();
		crewDeployed.AddListener(Target.ReadCardFromAsset);
		crewDeployed.AddListener(GameLogicEvents.DeployCrew);
		crewDeployed.AddListener(CrewAssigner.instance.UpdateCrewItems);
	}

	private void UpdateCrewItems()
	{

		int availableCrewNumber = Game.instance.CrewNumber - Game.instance.DeployedCrew + Target.cardAsset.crewNumber+1;
		
		for (int i = 0; i < this.CrewItems.Length; i++)
		{
			CrewItem item = this.CrewItems[i];
			if (i >= availableCrewNumber)
			{
				item.gameObject.SetActive(false);
			}
			else
			{
				item.gameObject.SetActive(true);
			}

			if (i != 0)
			{
				if (i <= Target.cardAsset.crewNumber)
				{
					item.SetImageColor(choosedCrewCounter);
				}
				else
				{
					item.SetImageColor(Color.green);
				}
			}




		}
	}

	public void Hide()
	{
		HoverPreview.StopAllPreviews();
		this.gameObject.SetActive(false);
	}
}
