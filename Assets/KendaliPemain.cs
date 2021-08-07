using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KendaliPemain : MonoBehaviour {

    Rigidbody2D Bodi;
    Animator anim;

    public Collider2D Sensor;
    public Collider2D Lantai;

    public float Kecepatan;
    public float TinggiLompatan;

    public GameObject Portal;
    public int TotalCuciTgn;

    bool HadapKanan = true;
    bool Mendarat = true;
    int JumlahCuciTgn = 0;

    Vector3 posisiAwal;

    public void TambahCuciTgn() {
        JumlahCuciTgn += 1;
        Debug.Log(JumlahCuciTgn);
    }

    public void UpdatePosisi(Vector3 Posisi) {
        posisiAwal = Posisi;
    }
    
    void Start() {
        Bodi = GetComponent<Rigidbody2D>();
        posisiAwal = transform.position;
        anim = GetComponent<Animator>();
    }

    void Update() {
        Mendarat = Physics2D.IsTouching(Sensor, Lantai);

        if (Input.GetKeyDown(KeyCode.Space) && Mendarat == true) {
            //Bodi.velocity = new Vector2(0f, TinggiLompatan);
            Bodi.velocity = Vector2.up * TinggiLompatan;
            //Mendarat = false;
        }

        if (JumlahCuciTgn == TotalCuciTgn) {
            Portal.SetActive(true);
        }
    }

    void FixedUpdate() {
        float Akselerasi = Input.GetAxis("Horizontal");
        Bodi.velocity = new Vector2(Akselerasi * Kecepatan, Bodi.velocity.y);
        AnimationState();
        if(Akselerasi > 0 && HadapKanan == false) {
            Berpaling();
        } else if(Akselerasi < 0 && HadapKanan == true) {
            Berpaling();
        }
    }

    void Berpaling() {
        HadapKanan = !HadapKanan;

        Vector3 Skala = transform.localScale;
        Skala.x *= -1;
        transform.localScale = Skala;
    }

    void AnimationState() {
        if (Kecepatan == 0) {
            anim.SetBool("isWalking", false);
        } 
        if (Kecepatan > 0)
            anim.SetBool("isWalking", true);
        if (Kecepatan < 0)
            anim.SetBool("isWalking", true);
    }

    public void PemainMati() {
        transform.position = posisiAwal;
        Bodi.velocity = new Vector2(0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D Kena) {
        if (Kena.gameObject.name == "Sensor Lubang") {
            PemainMati();
        }
    }
}
