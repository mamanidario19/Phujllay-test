/* Esta es la Superclase que va a instanciar a todas las Subclases que la hereden */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterInput characterInput;
    public CharacterMovement characterMovement;
}
