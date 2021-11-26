using UnityEngine.UI;
using UnityEngine;

namespace UI.EnergyUI
{
    public class Energy : MonoBehaviour
    {
        [SerializeField] private Text _energy;

        //Добавление скорострельности в Text
        public void OutputEnergy(float energy)
        {
            _energy.text = energy.ToString();
        }
    }
}