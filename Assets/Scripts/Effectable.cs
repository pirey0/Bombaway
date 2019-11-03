using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffectable
{
    void Explode(Bomb source);

}

public interface IPickupable
{
    void PickUp();
    void Release();
}
