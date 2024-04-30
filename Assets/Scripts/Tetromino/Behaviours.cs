using Tetromino.State;
using UnityEngine;

namespace Tetromino {
    public static class Behaviours {
        private static readonly Vector3 FlipRotation = Vector3.forward * 90;

        public enum Direction {
            Left,
            Right
        }

        public static void EnableRagdoll<T>(this T instance, bool value) where T : ITetromino {
            if (instance is not Block component) return;

            component.Rigidbody.isKinematic = !value;
            component.Rigidbody.detectCollisions = value;
        }

        public static void Move<T>(this T instance, Direction direction) where T : ITetromino {
            if (instance is not Block component) return;

            component.transform.position += direction == Direction.Left ? Vector3.left : Vector3.right;
        }

        public static void Flip<T>(this T instance) where T : ITetromino {
            if (instance is not Block component) return;

            component.transform.Rotate(FlipRotation);
        }
    }
}