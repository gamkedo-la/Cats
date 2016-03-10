using UnityEngine;

public class PawCursor : MonoBehaviour {

    public Texture2D pawTexture;

    bool pawEnabled = false;
    int ignoreLayers;
	Vector2 centerSpot;

    void Start() {
		centerSpot = new Vector2(this.pawTexture.width / 2, this.pawTexture.height / 2);
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
		Cursor.SetCursor(this.pawTexture, centerSpot, CursorMode.Auto);
        this.pawEnabled = true;
    }

    void PawDisable() {
		Cursor.SetCursor(null, centerSpot, CursorMode.Auto);
        this.pawEnabled = false;
    }

}