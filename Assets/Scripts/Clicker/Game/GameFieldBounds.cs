using UnityEngine;

namespace Clicker.Game
{
    public class GameFieldBounds
    {
        public Vector2 Size => _bounds.size;
        
        private Rect _bounds;
        
        public GameFieldBounds(Camera camera, float nonGameFramePercent)
        {
            var boundsSize = GetScreenWorldSize(camera) * (1 - nonGameFramePercent);
            var position = boundsSize / -2f;
            
            _bounds = new Rect(position, boundsSize);
        }

        public Vector2 GetRandomPositionForSquare(Vector2 squareSize)
        {
            var squareHalfWidth = squareSize.x / 2f;
            var squareHalfHeight = squareSize.y / 2f;

            var randomX = Random.Range(_bounds.xMin + squareHalfWidth, _bounds.xMax - squareHalfWidth);
            var randomY = Random.Range(_bounds.yMin + squareHalfHeight, _bounds.yMax - squareHalfHeight);

            return new Vector2(randomX, randomY);
        }

        private Vector2 GetScreenWorldSize(Camera camera)
        {
            Vector2 areaSize;
            var screenRatio = (float)Screen.width / (float)Screen.height;

            areaSize.y = camera.orthographicSize * 2;
            areaSize.x = areaSize.y * screenRatio;

            return areaSize;
        }
    }
}
