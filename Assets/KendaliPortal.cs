using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KendaliPortal : MonoBehaviour {

    public GameObject Pemain;

    void Start() {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D Kena) {
        if (Kena.gameObject.name == Pemain.name) {
            //Pemain.GetComponent<KendaliPemain>().UpdatePosisi(this.transform.position);
            //Destroy(this.gameObject, 0.2f);
            SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
            Debug.Log("Masuk Portal");
        }
    }
}
