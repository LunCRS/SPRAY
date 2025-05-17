using UnityEngine;
using System.Collections.Generic;

public class ResetColorBlocks : MonoBehaviour
{
    public List<GameObject> blocksToManage = new List<GameObject>();

    private Dictionary<GameObject, BlockInitialState> blockInitialStates = new Dictionary<GameObject, BlockInitialState>();

    private struct BlockInitialState
    {
        public Color color;
        public bool isActive;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 velocity;
    }

    void Start()
    {
        foreach (var block in blocksToManage)
        {
            if (block != null)
            {
                Renderer blockRenderer = block.GetComponent<Renderer>();
                Rigidbody blockRigidbody = block.GetComponent<Rigidbody>();
                ColorBlock colorblock = block.GetComponent<ColorBlock>();

                Color initialColor = colorblock.originColor;
                bool initialActiveState = block.activeSelf;
                Vector3 initialPosition = block.transform.position;
                Vector3 initialRotation = block.transform.rotation.eulerAngles;
                Vector3 initialVelocity = blockRigidbody != null ? blockRigidbody.velocity : Vector3.zero;

                blockInitialStates[block] = new BlockInitialState
                {
                    color = initialColor,
                    isActive = initialActiveState,
                    position = initialPosition,
                    rotation = initialRotation,
                    velocity = initialVelocity
                };
            }
        }
    }

    public void ResetAllBlocks()
    {
        // Debug.Log("1");
        foreach (var pair in blockInitialStates)
        {
            // Debug.Log("Resetting block: " + pair.Key.name);
            GameObject block = pair.Key;
            BlockInitialState state = pair.Value;

            if (block != null)
            {
                Renderer blockRenderer = block.GetComponent<Renderer>();
                Rigidbody blockRigidbody = block.GetComponent<Rigidbody>();
                ColorBlock colorblock = block.GetComponent<ColorBlock>();


                Debug.Log("2");
                colorblock.rend.material.color = state.color;

                block.SetActive(state.isActive);
                block.transform.position = state.position;
                block.transform.rotation = Quaternion.Euler(state.rotation);

                if (blockRigidbody != null)
                {
                    blockRigidbody.velocity = Vector3.zero;
                }
            }
        }
    }
}