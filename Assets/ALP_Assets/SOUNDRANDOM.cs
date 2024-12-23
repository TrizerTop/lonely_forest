using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioClip soundClip;    // Звуковой клип, который нужно проиграть
    private AudioSource _audioSource; // Компонент Audio Source
    private bool _soundPlayed = false;  // Флаг, показывающий, был ли звук проигран

    void Start()
    {
        // Получаем компонент AudioSource или добавляем его, если его нет
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Отключаем воспроизведение при старте (если вдруг оно было включено в редакторе)
        _audioSource.playOnAwake = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_soundPlayed)
        {
            if (soundClip != null)
            {
                _audioSource.clip = soundClip;
                _audioSource.Play();
                _soundPlayed = true; // Устанавливаем флаг, чтобы звук не проигрывался снова
                Debug.Log("Sound played");
            }
            else
            {
                Debug.LogError("No audio clip assigned in Inspector!");
            }
        }
    }

    // Опционально: Если вы хотите, чтобы звук можно было проигрывать снова после выхода, раскомментируйте этот код
    /*void OnTriggerExit(Collider other)
    {
          if (other.CompareTag("Player"))
        {
            _soundPlayed = false;
             Debug.Log("Reset sound flag");
          }
    }*/
}