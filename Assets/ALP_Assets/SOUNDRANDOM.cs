using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioClip soundClip;    // �������� ����, ������� ����� ���������
    private AudioSource _audioSource; // ��������� Audio Source
    private bool _soundPlayed = false;  // ����, ������������, ��� �� ���� ��������

    void Start()
    {
        // �������� ��������� AudioSource ��� ��������� ���, ���� ��� ���
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        // ��������� ��������������� ��� ������ (���� ����� ��� ���� �������� � ���������)
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
                _soundPlayed = true; // ������������� ����, ����� ���� �� ������������ �����
                Debug.Log("Sound played");
            }
            else
            {
                Debug.LogError("No audio clip assigned in Inspector!");
            }
        }
    }

    // �����������: ���� �� ������, ����� ���� ����� ���� ����������� ����� ����� ������, ���������������� ���� ���
    /*void OnTriggerExit(Collider other)
    {
          if (other.CompareTag("Player"))
        {
            _soundPlayed = false;
             Debug.Log("Reset sound flag");
          }
    }*/
}