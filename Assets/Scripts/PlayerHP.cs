﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

	private int Health = 20;
	public float timebetweenDamage = 0.5f;
	public int damageAmount = 2;
	public Slider HealthSlider;
	public Image DamageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color (1f, 0f, 0f, 0.1f);



	public int currentHealth;
	bool damage;
	float timer;


	// Use this for initialization
	void Start () {
		currentHealth = Health;
	}
	
	// Update is called once per frame
	void Update (){
		timer += Time.deltaTime;
		if (damage) {
			DamageImage.color = flashColour;
		} else {
			DamageImage.color = Color.Lerp (DamageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damage = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Enemy")) {
			if (timer >= timebetweenDamage) {
				damage = true;
				currentHealth -= damageAmount;
				HealthSlider.value = currentHealth;
				timer = 0f;
			}
		}
	}




}
