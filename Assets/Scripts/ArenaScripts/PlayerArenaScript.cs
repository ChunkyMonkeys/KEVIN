using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerArenaScript : MonoBehaviour {

    private float health = 100;
    private float energy = 100;

	private bool playerTurn;
	private bool idle;

	public Slider currentHealthBar;
	public Text healthText;
    public Slider currentEnergyBar;
	public Text energyText;

	public Animator animation;

	public enum TurnState
	{
		IDLE,
		ATTACKING,
		HIT,
		DEAD	
	}

	public TurnState currentState;

	void Start()
	{
		playerTurn = true;
		idle = true;
		animation = GetComponent<Animator> ();
		Update ();
	}

	private void HealthUpdate()
	{

       //health -= 5.0f * Time.deltaTime;
        currentHealthBar.value = health;
        if (health > 100)
        {
            health = 100;
        }
        if (health < 0)
        {
			health = 0;
		}
		healthText.text = (currentHealthBar.value).ToString ("0") + '%';
    }

    private void EnergyUpdate()
	{
		//energy -= 5.0f * Time.deltaTime;
		currentEnergyBar.value = energy;
		if (energy > 100) {
			energy = 100;
		}
		if (energy < 0) {
			energy = 0;
		}
		energyText.text = (currentEnergyBar.value).ToString ("0") + '%';
	}

    void Update()
	{
		switch (currentState) 
		{
		case(TurnState.IDLE):
			if (playerTurn == true) 
			{
				if (idle == true) 
				{
					animation.Play ("PlayerAnimation");
				}
				if (Input.GetKeyDown("p"))
					{
						currentState = TurnState.ATTACKING;
					}
			}
			if (playerTurn == false) 
			{

			}
			break;
		case(TurnState.ATTACKING):
			//Attack ();
			break;
		case(TurnState.HIT):
			break;
		case(TurnState.DEAD):
			break;
		}
		HealthUpdate ();
		EnergyUpdate();
	}
	/*
	private void Attack()
	{
		animation.Play("PlayerAttackAnimation");
		yield return new WaitForSeconds (animation ["PlayerAttackAnimation"].length);
		yield return null;
	}*/




}
