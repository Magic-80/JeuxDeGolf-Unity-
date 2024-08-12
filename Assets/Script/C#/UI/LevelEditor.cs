using UnityEngine;

namespace Script.C_.UI
{
    public class LevelEditor : MonoBehaviour
    {
        public GameObject[] objectPrefabs;
        public GameObject playerPrefab;
        public GameObject ballPrefab;
        public float gridSize = 1f;
        public LayerMask panelLayerMask; 

        private GameObject _selectedObjectPrefab;
        private bool _deleteMode;
        private Vector3 _playerPosition;
        private Vector3 _ballPosition;
        private bool _placingPlayer;
        private bool _placingBall;

        private void Update()
        {
            if (!IsMouseOverPanel()) 
            {
                if (Input.GetMouseButtonDown(0) && !_deleteMode && _selectedObjectPrefab)
                {
                    Vector3 mousePosition = GetSnappedMousePosition();
                    Instantiate(_selectedObjectPrefab, mousePosition, Quaternion.identity);
                }

                if (Input.GetMouseButtonDown(1) && _deleteMode)
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }

            if (_placingPlayer || _placingBall)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mousePosition = GetSnappedMousePosition();
                    if (_placingPlayer)
                    {
                        _playerPosition = mousePosition;
                        Instantiate(playerPrefab, _playerPosition, Quaternion.identity);
                        _placingPlayer = false;
                    }
                    else if (_placingBall)
                    {
                        _ballPosition = mousePosition;
                        Instantiate(ballPrefab, _ballPosition, Quaternion.identity);
                        _placingBall = false;
                    }
                }
            }
        }

        private bool IsMouseOverPanel()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, panelLayerMask);
            return hit.collider != null;
        }

        private Vector3 GetSnappedMousePosition()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.x = Mathf.Round(mousePosition.x / gridSize) * gridSize;
            mousePosition.y = Mathf.Round(mousePosition.y / gridSize) * gridSize;
            mousePosition.z = 0f;
            return mousePosition;
        }

        public void SelectObject(int index)
        {
            if (index >= 0 && index < objectPrefabs.Length)
            {
                _selectedObjectPrefab = objectPrefabs[index];
                _deleteMode = false;
                _placingPlayer = false;
                _placingBall = false;
            }
        }

        public void ToggleDeleteMode()
        {
            _deleteMode = !_deleteMode;
            _placingPlayer = false;
            _placingBall = false;
        }

        public void PlacePlayer()
        {
            _placingPlayer = true;
            _placingBall = false;
            _deleteMode = false;
        }

        public void PlaceBall()
        {
            _placingPlayer = false;
            _placingBall = true;
            _deleteMode = false;
        }
    }
}
