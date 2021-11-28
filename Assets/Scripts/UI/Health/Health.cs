using UnityEngine.UI;
using UnityEngine;

namespace UI.HealthUI
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private Text _health;

        //Adding Lives to Text
        public void OutputHealth(float health)
        {
            _health.text = health.ToString();
        }
    }
}
