using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private float health = 100;
    private float hunger = 100;
    private float sobriety = 100;

	public Slider currentHealthBar;
	public Text healthText;
	public Slider currentHungerBar;
	public Text hungerText;
    public Slider currentSobrietyBar;
	public Text sobrietyText;

	void Start(){
		Update ();
	}

	private void HealthUpdate(){
		//If Kevin goes hunrgy, his health will suffer as a consequence
		if (hunger == 0){
           health -= 1.0f * Time.deltaTime;
            currentHealthBar.value = health;
        }
        if (health > 100){
            health = 100;
        }
        if (health < 0){
			health = 0;
		}
		healthText.text = (currentHealthBar.value).ToString ("0") + '%';
    }

	private void HungerUpdate(){
		if ((hunger > 0) && (hunger <=100)){
            hunger -= 15.0f * Time.deltaTime;
            currentHungerBar.value = hunger;
        }
        if (hunger > 100){
            hunger = 100;
        }
        if (hunger < 0){
			hunger = 0;
		}
		hungerText.text = (currentHungerBar.value).ToString ("0") + '%';
    }

    private void SobrietyUpdate(){
        if ((sobriety > 0) && (sobriety <= 100)){
            //sobriety -= 5.0f * Time.deltaTime;
            currentSobrietyBar.value = sobriety;
        }
        if (sobriety > 100){
            sobriety = 100;
        }
        if (sobriety < 0){
            sobriety = 0;
        }
		sobrietyText.text = (currentSobrietyBar.value).ToString ("0") + '%';
    }

	public void FeedPet(){
		hunger += 25f;
	}

    void Update(){
		HealthUpdate ();
		HungerUpdate ();
        SobrietyUpdate();
	}
}