using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell
{
    
    string SpellCasterTag { get; set; }
    string TargetTag { get; set; }
    float Damage { get; set; }

}
