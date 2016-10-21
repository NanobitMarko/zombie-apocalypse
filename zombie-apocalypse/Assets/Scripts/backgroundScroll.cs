using UnityEngine;
using System.Collections;

public class backgroundScroll : MonoBehaviour {

	public float speed = 0.5f;
	public Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (Time.time * speed, 0);
		rend.material.SetTextureOffset("_MainTex", offset);	
	}
}
