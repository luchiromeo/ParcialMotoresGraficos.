using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    private Rigidbody rb;
    public int rapidez;
    public LayerMask capaPiso;
    public float magnitudSalto;
    public SphereCollider col;
    public int maxSaltos = 2;
    public int saltoActual = 0;
    private bool estaEnElPiso = true;
    public bool tienePowerUp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();

    }

    private void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        Vector3 vectorMovimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);
        rb.AddForce(vectorMovimiento * rapidez);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (estaEnElPiso || maxSaltos > saltoActual))
        {
            rb.AddForce(Vector3.up * magnitudSalto, ForceMode.Impulse);
            estaEnElPiso = false;
            saltoActual++;
        }


        if (EstaEnPiso())
        {
            estaEnElPiso = true;
            saltoActual = 0;
        }


    }

    private void OnColissionEnter(Collision col)
    {
        Debug.Log("en el piso");
    }

    private bool EstaEnPiso()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, capaPiso);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp") == true)
        {
            tienePowerUp = true;
            other.gameObject.SetActive(false);
            transform.localScale *= 2;
            rapidez += 1;
        }
        if (other.gameObject.CompareTag("Coleccionable") == true)
        {
            other.gameObject.SetActive(false);

        }

    }
    private void reiniciar()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

        }
    }
    
}  
