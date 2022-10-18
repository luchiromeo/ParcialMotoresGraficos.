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
    public Camera camaraTerceraPersona;
    public GameObject Balas;

    public Transform posicionJugador;


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

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("El rayo tocó al objeto: ");

            RaycastHit hit;
            if (Physics.Raycast(posicionJugador.transform.position, posicionJugador.TransformDirection(Vector3.forward), out hit, 5f))
            {
                Debug.Log("El rayo tocó al objeto: " + hit.collider.name);
            }


            /*Ray ray = camaraTerceraPersona.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if ((Physics.Raycast(ray, out hit) == true) && hit.distance < 5) 
            { 
                
            }*/
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camaraTerceraPersona.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if ((Physics.Raycast(ray, out hit) == true) && hit.distance < 5)
            {
                Debug.Log("El rayo tocó al objeto: " + hit.collider.name);
                if (hit.collider.name.Substring(0, 3) == "EnemigoUno")
                {
                    GameObject objetoTocado = GameObject.Find(hit.transform.name);
                    ControlEnemigo scriptObjetoTocado = (ControlEnemigo)objetoTocado.GetComponent(typeof(ControlEnemigo));
                    if (scriptObjetoTocado != null)
                    {
                        scriptObjetoTocado.recibirDaño();
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = camaraTerceraPersona.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            GameObject pro; 
            pro = Instantiate(Balas, ray.origin, transform.rotation);
            Rigidbody rb = pro.GetComponent<Rigidbody>();
            rb.AddForce(camaraTerceraPersona.transform.forward * 15, ForceMode.Impulse);
            Destroy(pro, 5); 
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
