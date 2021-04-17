using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExplodingElement 
{
    void Explode(Bomb source);
}

public interface IAffectable
{
    void OnActivate(GameObject source);
}

public interface IPickupable
{
    void PickUp();
    void Release();
    Rigidbody2D GetRigidbody();
    Transform GetTransform();
}

public interface IClickable
{
    void Click();
}
