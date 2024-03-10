using UnityEngine;

public class AudioHandler : MonoBehaviour {
   [SerializeField] private AudioSource audioSource;

   private void OnCollisionEnter(Collision collision) {
      audioSource.Play();
   }
}
