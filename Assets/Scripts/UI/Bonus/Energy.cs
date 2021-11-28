using UnityEngine.UI;
using UnityEngine;

namespace UI.EnergyUI
{
    
    public class Energy : MonoBehaviour
    {
        [SerializeField] private Text _energy;

        //Adding rate of fire to Text
        public void OutputEnergy(float energy)
        {
            _energy.text = energy.ToString();
        }
    }
}