using UnityEngine;

public class MonsterActivator : MonoBehaviour
{
    public GameObject monster; // GameObject скримера
    private bool _monsterActivated = false; // Флаг, показывающий, был ли скример активирован

    void Start()
    {
        if (monster != null)
        {
            monster.SetActive(false); // Скрываем скример в начале
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
                monster.SetActive(true); // Показываем скример
                _monsterActivated = true; // Устанавливаем флаг, что скример активирован
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
                monster.SetActive(false); // Скрываем скример
                _monsterActivated = false; // **Сбрасываем флаг активации**
                 Destroy(monster);
            }
            else
            {
                Debug.LogError("Monster not assigned in Inspector!");
            }
        }
    }
}