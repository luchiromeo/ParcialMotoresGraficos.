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
    public TMPro.TMP_Text textoRecolectados;
    private int cont;
    public TMPro.TMP_Text textoGanaste;
    public Transform posicionJugador;
    Vector3 worldPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        textoGanaste.text = "";
        cont = 0;
        setearTextos();
      
    }

    private void setearTextos()
    { 
        textoRecolectados.text = "Cantidad recolectados: " + cont.ToString();
        if (cont >= 3) 
        {
            textoGanaste.text = "Ganaste!";
        } 
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            worldPosition = hit.point;
        }

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        Vector3 vectorMovimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);
        rb.AddForce(vectorMovimiento * rapidez);
        transform.LookAt(new Vector3(worldPosition.x, 1f, worldPosition.z));
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
            GameObject pro = Instantiate(Balas, transform.position + transform.forward * 3f, Quaternion.identity);
            pro.GetComponent<Rigidbody>().AddForce(transform.forward * 15, ForceMode.Impulse);
            Destroy(pro, 5f);
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
            cont = cont + 1;
            setearTextos();
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
