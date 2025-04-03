using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public GameObject levelHint;
    public int retriesBeforeHint = 3;
    private bool hintsShown = false;
    public float hintOpacity = 0.5f;
    public float hintDisplayDuration = 1.7f;
    public float fadeOutDuration = 0.5f;
    public float initialDelay = 0.7f;

    void Start()
    {
        if (levelHint != null)
        {
            SetHintsOpacity(0f);
            SetHintsActive(false);
        }
    }

    void Update()
    {
        if (!hintsShown && PauseMenu.restartCounter > retriesBeforeHint)
        {
            StartCoroutine(DelayedShowHints());
            hintsShown = true;
        }
    }
    private IEnumerator DelayedShowHints()
    {
        yield return new WaitForSeconds(initialDelay);
        
        ShowHints();
    }

    private void ShowHints()
    {
        if (levelHint != null)
        {
            SetHintsActive(true);
            SetHintsOpacity(hintOpacity);
            
            // Then start fading them in
            StartCoroutine(HintSequence());
            hintsShown = true;
            Debug.Log("Hints shown after " + PauseMenu.restartCounter + " retries");
        }
        else
        {
            Debug.LogWarning("Level hint parent object not assigned!");
        }
    }

    private IEnumerator HintSequence()
    {
        yield return new WaitForSeconds(hintDisplayDuration);
        
        // Fade out
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            float currentOpacity = Mathf.Lerp(hintOpacity, 0f, elapsedTime / fadeOutDuration);
            SetHintsOpacity(currentOpacity);
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        // Ensure we end completely transparent and inactive
        SetHintsOpacity(0f);
        SetHintsActive(false);
    }

    private void SetHintsActive(bool active)
    {
        // Activate/deactivate all children under the "level hint" parent
        foreach (Transform child in levelHint.transform)
        {
            child.gameObject.SetActive(active);
        }
    }

    private void SetHintsOpacity(float opacity)
    {
        // Set opacity for all children under the "level hint" parent
        foreach (Transform child in levelHint.transform)
        {
            // Get all renderers (SpriteRenderer, MeshRenderer, etc.)
            Renderer[] renderers = child.GetComponentsInChildren<Renderer>(true);
            foreach (Renderer renderer in renderers)
            {
                // Set material color alpha
                Color color = renderer.material.color;
                color.a = opacity;
                renderer.material.color = color;
            }
            
            // Handle UI elements if present
            UnityEngine.UI.Graphic[] graphics = child.GetComponentsInChildren<UnityEngine.UI.Graphic>(true);
            foreach (UnityEngine.UI.Graphic graphic in graphics)
            {
                Color color = graphic.color;
                color.a = opacity;
                graphic.color = color;
            }
        }
    }

    public void ResetHints()
    {
        hintsShown = false;
        StopAllCoroutines();
        SetHintsOpacity(0f);
        SetHintsActive(false);
    }
}
