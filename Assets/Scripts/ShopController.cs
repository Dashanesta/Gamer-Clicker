using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public static ShopController instance;
    private void Awake() => instance = this;

    [SerializeField] private TMP_Text gamersText;

   //public static void ShopInit()
   //{
   //    
   //}
   //
   //public void LoadGamers()
   //{
   //    
   //}
}
