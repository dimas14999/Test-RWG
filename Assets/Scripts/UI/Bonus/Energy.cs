using UnityEngine.UI;
using UnityEngine;

namespace UI.EnergyUI
{
    
    public class Energy : MonoBehaviour
    {
        [SerializeField] private Text _energy;

        public void DisplayEnergy(float energy)
        {
            _energy.text = energy.ToString();
        }
    }
}