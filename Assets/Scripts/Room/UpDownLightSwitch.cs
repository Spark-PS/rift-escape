//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34209
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;


namespace AssemblyCSharp
{
	public class UpDownLightSwitch : MonoBehaviour
	{
		public Light lamp;
		public GameObject bulb;
		public float intensitySet = 1.0f;
		public GameObject ButtonToMove;
		private float nextFire = 0.0f;
		public AudioSource source;
		public AudioClip activateSound;

		void OnTriggerEnter(Collider other)
		{
			//if (Time.time < nextFire)
			//	return;
			
			//nextFire = Time.time + 1.0f;

			if (lamp.intensity != intensitySet) {
				if (source != null && activateSound != null)
					source.PlayOneShot(activateSound);
				lamp.intensity = intensitySet;
				if (intensitySet == 0)
				{
					Material newMat = Resources.Load("Lamp/LampWhite", typeof(Material)) as Material;
					bulb.GetComponent<Renderer>().material = newMat;
				}
				else
				{
					Material newMat = Resources.Load("Lamp/LightWhite", typeof(Material)) as Material;
					bulb.GetComponent<Renderer>().material = newMat;
				}
				// Making the button move
				ButtonToMove.transform.Rotate(0, 180f, 0f);
				// rotating everything else so just the object is rotated bot nothing else
				foreach (Transform obj in ButtonToMove.transform)
				{
					obj.transform.Rotate(0, 180f, 0f);
				}
			}
		}
	}
}

