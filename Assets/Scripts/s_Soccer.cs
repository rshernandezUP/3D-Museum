using System.Collections;
using UnityEngine;

public class s_Soccer : MonoBehaviour
{
    public float pushForce = 10f;
    public float torqueForce = 10f;
    public AudioSource audioS;

    private Rigidbody rb;
    private bool moving = false;
    private bool isPaused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Empuje inicial con tecla 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            moving = true;
            rb.AddForce(Vector3.right * pushForce, ForceMode.Impulse);
            audioS.Play();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false)
            {
                Time.timeScale = 0f;
                isPaused = true;
                audioS.Pause();
            }
            else if(isPaused == true)
            {
                Time.timeScale = 1f;
                isPaused = false;
                audioS.UnPause();
            }
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            StartCoroutine(TorqueRoutine());
        }
    }

    IEnumerator TorqueRoutine()
    {
        float timer = 0f;

        // aplicar torque durante 5 segundos
        while (timer < 2f)
        {
            rb.AddTorque(Vector3.forward * torqueForce);
            timer += Time.deltaTime;
            yield return null;
        }

        // pausa 5 segundos
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        yield return new WaitForSeconds(10f);

        // continuar movimiento normal
        timer = 0f;
        while (timer < 10f)
        {
            rb.AddTorque(Vector3.forward * torqueForce);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}