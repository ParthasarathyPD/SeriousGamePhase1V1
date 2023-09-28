using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{

	public Image actorImage;
	public TextMeshProUGUI actorName;
	public TextMeshProUGUI messageText;
	public RectTransform backgroundBox;

	Message[] currentMessages;
	Actor[] currentActors;
	int activeMessage = 0;

	public static bool isActive = false;


	public void OpenDialogue(Message[] messages, Actor[] actors)
	{
		currentMessages = messages;
		currentActors = actors;
		activeMessage = 0;
		isActive = true;

		Debug.Log("Started conversation! Loaded messages: " + messages.Length);
		DisplayMessage();
		backgroundBox.LeanScale(Vector3.one, 0.2f).setEaseInOutExpo();
	}

	void AnimateTextColor()
	{
		LeanTween.textAlpha(messageText.rectTransform, 0, 0);
		LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
	}

	void DisplayMessage()
	{
		Message messageToDisplay = currentMessages[activeMessage];
		messageText.text = messageToDisplay.message;

		Actor actorToDisplay = currentActors[messageToDisplay.actorId];
		actorName.text = actorToDisplay.name;
		actorImage.sprite = actorToDisplay.sprite;
		AnimateTextColor(); //NOT WORKING CHECK
	}

	public void NextMessage()
	{
		activeMessage++;
		if (activeMessage >= currentMessages.Length)
		{
			Debug.Log("Ended conversation!");
			backgroundBox.LeanScale(Vector3.zero, 0.2f).setEaseInOutExpo();
			isActive = false;
		}
		else
		{
			DisplayMessage();
		}
	}

	void Start()
	{
		backgroundBox.transform.localScale = Vector3.zero;
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isActive)
			NextMessage();
	}
}