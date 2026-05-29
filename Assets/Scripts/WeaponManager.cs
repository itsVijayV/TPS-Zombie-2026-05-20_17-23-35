using System.Collections;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public enum weaponSelect
    {
        knife,
        cleaver,
        bat,
        axe,
        pistol,
        shortgun,
        sparyCan,
        bottle
    };

    public weaponSelect chosenWeapon;
    public GameObject[] weapons;
    private int weaponId = 0;
    private Animator anim;
    private AudioSource audioPlayer;
    public AudioClip[] weaponSounds; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weaponId = (int) chosenWeapon;
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();

        ChangeWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(weaponId < weapons.Length - 1)
            {
                weaponId++;
                ChangeWeapons();
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (weaponId > 0)
            {
                weaponId--;
                ChangeWeapons();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(SaveScript.inventoryOpen == false)
            {
                anim.SetTrigger("Attack");
                audioPlayer.clip = weaponSounds[weaponId];
                audioPlayer.Play();
            }
        }
    }

    private void ChangeWeapons()
    {
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[weaponId].SetActive(true);
        chosenWeapon = (weaponSelect) weaponId;
        anim.SetInteger("WeaponID",weaponId);
        anim.SetBool("WeaponChanged", true);
        Move();
        StartCoroutine(WeaponReset());
    }

    private void Move()
    {
        switch (chosenWeapon)
        {
            case weaponSelect.knife:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.cleaver:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.bat:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.axe:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.pistol:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.shortgun:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.46f);
                break;
            case weaponSelect.sparyCan:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.bottle:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
        }
    }

    private IEnumerator WeaponReset()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("WeaponChanged", false);
    }
}
