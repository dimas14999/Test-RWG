using UnityEngine.UI;
using UnityEngine;

namespace UI.HealthUI
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private Text _health;

        public void DisplayHealth(float health)
        {
            _health.text = health.ToString();
        }
    }
}
