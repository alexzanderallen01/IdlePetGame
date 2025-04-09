using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    //Class var
    public static PlayerHealthSystem Instance;
    //Images var for bars

	public Image currentHealthBar;
    public Image currentManaBar;
    //HP definning vars
    public Text healthText;
	public float hitPoint = 100f;
	public float maxHitPoint = 100f;
    //Mana definning vars
    public Text manaText;
	public float manaPoint = 100f;
	public float maxManaPoint = 100f;
    //Regen HP vars
    public bool Regenerate = true;
	public float regenHP = 1f;
    public float regenMP = 0.1f;
	private float timeleft = 0.0f;	// Left time for current interval
	public float regenUpdateInterval = 1f;
    //var to stop damage for testing
	public bool GodMode;
    //hurt sound vars
    public AudioSource _hurtAudioSource;
    public AudioClip _hurtAudioClip;
    //Load all vars before game starts
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateGraphics();
        timeleft = regenUpdateInterval; 
    }
    void Update()
    {
        //keep track of time until next regen
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0){
        //Heal to max if in debug mode, else check if can Regenerate
            if (GodMode){
                HealDamage(maxHitPoint);
                RestoreMana(maxManaPoint);
            }
            else if (Regenerate){
                HealDamage(regenHP);
		        RestoreMana(regenMP);
            }
            else {
                RestoreMana(regenMP);
            }
            UpdateGraphics();
			timeleft = regenUpdateInterval;
        }
    }
    //find % of current HP, change HP Bar, & update HP text
    private void UpdateHealthBar()
	{
		float ratio = hitPoint / maxHitPoint;
		currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * ratio - currentHealthBar.rectTransform.rect.width, 0, 0);
		healthText.text = hitPoint.ToString ("0") + "/" + maxHitPoint.ToString ("0");
	}
    //find % of current MP, change MP Bar, & update MP text
    private void UpdateManaBar()
	{
		float ratio = manaPoint / maxManaPoint;
		currentManaBar.rectTransform.localPosition = new Vector3(currentManaBar.rectTransform.rect.width * ratio - currentManaBar.rectTransform.rect.width, 0, 0);
		manaText.text = manaPoint.ToString ("0") + "/" + maxManaPoint.ToString ("0");
	}
    //HP functions:
    //reduce HP depending on damage and prevent HP from going past 0
    public void TakeDamage(float Damage)
	{
		hitPoint -= Damage;
		if (hitPoint < 1)
			hitPoint = 0;
		UpdateGraphics();
		StartCoroutine(PlayerHurts());
	}
    //Heal HP and prevent HP from going past max
    public void HealDamage(float Heal)
	{
		hitPoint += Heal;
		if (hitPoint > maxHitPoint) 
			hitPoint = maxHitPoint;
		UpdateGraphics();
	}
    //Change max HP based off of new max modifier
    public void SetMaxHealth(float max)
	{
		maxHitPoint += (int)(maxHitPoint * max / 100);
		UpdateGraphics();
	}
    //MP functions:
    //reduce MP depending on usege and prevent MP from going past 0
    public void UseMana(float Mana)
	{
		manaPoint -= Mana;
		if (manaPoint < 1)
			manaPoint = 0;
		UpdateGraphics();
	}
    //Restores MP and prevent MP from going past max
	public void RestoreMana(float Mana)
	{
		manaPoint += Mana;
		if (manaPoint > maxManaPoint) 
			manaPoint = maxManaPoint;
		UpdateGraphics();
	}
    //Change max MP based off of new max modifier
	public void SetMaxMana(float max)
	{
		maxManaPoint += (int)(maxManaPoint * max / 100);
		UpdateGraphics();
	}
    //Update gui with new HP & MP
    void UpdateGraphics(){
        UpdateHealthBar();
        UpdateManaBar();
    }
    //hurt Sound & dead handler
    IEnumerator PlayerHurts()
	{
		if (hitPoint < 1) 
		{
			yield return StartCoroutine(PlayerDied());
		}
		else{
            PopupText.Instance.Popup("Ouch!", 1f, 1f);
            _hurtAudioSource.clip = _hurtAudioClip;
            _hurtAudioSource.Play();
            _hurtAudioSource.volume = 0.15f;
            yield return null;
        }	
    IEnumerator PlayerDied()
	{
		//Player dead. Death animation & sound go here. Also add death screen
		PopupText.Instance.Popup("You have died!", 1f, 1f);
		yield return null;
	}
	}
}
