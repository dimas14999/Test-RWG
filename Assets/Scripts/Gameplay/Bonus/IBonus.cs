using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBonus 
{
  ItemBonus Bonus { get; }
    
}

public enum ItemBonus
{
    None,
    Health,
    Energy
}
