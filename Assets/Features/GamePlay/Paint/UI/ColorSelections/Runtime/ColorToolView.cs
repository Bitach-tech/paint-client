using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Paint.UI.ColorSelections.Runtime
{
    [DisallowMultipleComponent]
    public class ColorToolView : MonoBehaviour
    {
        [SerializeField] private Image _colored;

        public void Construct(Color color)
        {
            _colored.color = color;
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}