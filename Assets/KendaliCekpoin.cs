using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KendaliCekpoin : MonoBehaviour {

    public GameObject Pemain;

    private void OnTriggerEnter2D(Collider2D Kena) {
        if (Kena.gameObject.name == Pemain.name) {
            Pemain.GetComponent<KendaliPemain>().UpdatePosisi(this.transform.position);
            Destroy(this.gameObject, 0.2f);
        }
    }
}
