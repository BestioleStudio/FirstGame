using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour {

    [SerializeField]
    private RectTransform healthBarRect;

    private void Start()
    {
        if(healthBarRect == null)
        {
            Debug.Log("STATUS INDICATOR: No health bar displayed");
        }
    }

    public void setHealth(int _currentHealth, int _maxHealth)
    {
        float _value = (float)_currentHealth / _maxHealth;
        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.y);
    }

}
