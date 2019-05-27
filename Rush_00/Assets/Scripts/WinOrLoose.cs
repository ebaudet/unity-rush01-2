using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLoose : MonoBehaviour {
	public GameObject WinTxt1;
	public GameObject WinTxt2;
	public GameObject WinBtn1;
	public GameObject LooseTxt1;
	public GameObject LooseTxt2;
	public GameObject LooseBtn1;
	public GameObject Panel;
	public GameObject Hero;
	public AudioSource audi;
	private int stocked;
	private int neverCall = 1;
	private int neverCall1 = 1;

	public void Start()
	{
		stocked = Gamemanager.gm.nbr_ennemy;
	}

	public void Update()
	{
		if(!Hero && neverCall == 1)
		{
			LoosePannel();
			neverCall = 0;
		}
		if(Gamemanager.gm.nbr_ennemy == 0 && neverCall1 == 1)
		{
			WinPannel();
			neverCall1 = 0;
		}
		if(Gamemanager.gm.nbr_ennemy != stocked)
		{
			audi.Play();
			stocked = Gamemanager.gm.nbr_ennemy;
		}

	}


	public void WinPannel()
	{
		Time.timeScale = 0;
		Panel.SetActive(true);
		WinTxt1.SetActive(true);
		WinTxt2.SetActive(true);
		WinBtn1.SetActive(true);
	}
	public void CloseWinPannel()
	{
		WinTxt1.SetActive(false);
		WinTxt2.SetActive(false);
		WinBtn1.SetActive(false);
	}
	public void LoosePannel()
	{
		Time.timeScale = 0;
		Panel.SetActive(true);
		LooseTxt1.SetActive(true);
		LooseTxt2.SetActive(true);
		LooseBtn1.SetActive(true);
	}
	public void CloseLoosePannel()
	{
		LooseTxt1.SetActive(false);
		LooseTxt2.SetActive(false);
		LooseBtn1.SetActive(false);
	}
}
