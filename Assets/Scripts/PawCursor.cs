using UnityEngine;

public class PawCursor : MonoBehaviour {

    public Texture2D pawTexture;

    bool pawEnabled = false;
    int ignoreLayers;

    void Start() {
       ignoreLayers = LayerMask.GetMask("Interactable");
    }

    void Update() {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ignoreLayers)) {
                this.PawEnable();
            }
            else {
                this.PawDisable();
            }
    }

    void PawEnable() {
        Cursor.SetCursor(this.pawTexture, Vector2.zero, CursorMode.Auto);
        this.pawEnabled = true;
    }

    void PawDisable() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        this.pawEnabled = false;
    }

}