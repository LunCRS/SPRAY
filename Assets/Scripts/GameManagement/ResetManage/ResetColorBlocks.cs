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

                blockInitialStates[block] = new BlockInitialState
                {
                    color = colorblock.originColor,
                    isActive = block.activeSelf,
                    position = block.transform.position,
                    velocity = blockRigidbody != null ? blockRigidbody.velocity : Vector3.zero
                };
            }
        }
    }

    public void ResetAllBlocks()
    {
        foreach (var pair in blockInitialStates)
        {
            GameObject block = pair.Key;
            BlockInitialState state = pair.Value;

            if (block != null)
            {
                Rigidbody blockRigidbody = block.GetComponent<Rigidbody>();
                ColorBlock colorblock = block.GetComponent<ColorBlock>();

                colorblock.ChangeColor(state.color);

                block.SetActive(state.isActive);
                block.transform.position = state.position;

                if (blockRigidbody != null)
                {
                    blockRigidbody.velocity = Vector3.zero;
                }
            }
        }
    }
}