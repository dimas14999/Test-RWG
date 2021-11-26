using UnityEngine.UI;
using UnityEngine;

namespace UI.HealthUI
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private Text _health;

        //Добавление очков в Text
        public void OutputHealth(int health)
        {
            _health.text = health.ToString();
        }
    }
}
