using UnityEngine;

public class MonsterActivator : MonoBehaviour
{
    public GameObject monster; // GameObject ��������
    private bool _monsterActivated = false; // ����, ������������, ��� �� ������� �����������

    void Start()
    {
        if (monster != null)
        {
            monster.SetActive(false); // �������� ������� � ������
        }
        else
        {
            Debug.LogError("Monster not assigned in Inspector!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_monsterActivated)
        {
            if (monster != null)
            {
                monster.SetActive(true); // ���������� �������
                _monsterActivated = true; // ������������� ����, ��� ������� �����������
            }
            else
            {
                Debug.LogError("Monster not assigned in Inspector!");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _monsterActivated)
        {
            if (monster != null)
            {
                monster.SetActive(false); // �������� �������
                _monsterActivated = false; // **���������� ���� ���������**
                 Destroy(monster);
            }
            else
            {
                Debug.LogError("Monster not assigned in Inspector!");
            }
        }
    }
}