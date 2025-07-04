
using System.Collections.Generic;

public class GenerateHoleConsoleCmd : ConsoleCmdAbstract
{
    public override string[] getCommands()
    {
        return new string[] { "generateHole", "gh" };
    }

    public override string getDescription()
    {
        return "generateHole gh <radius> => generates a big hole in terrain with the desired radius";
    }

    public override void Execute(List<string> _params, CommandSenderInfo _senderInfo)
    {
        var radius = 10;
        var world = GameManager.Instance.World;
        var playerPos = new Vector3i(world.GetPrimaryPlayer().position);
        var blockChangeInfos = new List<BlockChangeInfo>();
        var blockPos = Vector3i.zero;

        Log.Out($"playerPos={playerPos}, terrainHeight={world.GetHeight(playerPos.x, playerPos.z)}");

        if (_params.Count > 0 && !int.TryParse(_params[0], out radius))
        {
            Log.Error($"Invalid radius: '{_params[0]}'");
        }

        var sqrRadius = radius * radius;

        for (int x = -radius; x <= radius; x++)
        {
            blockPos.x = playerPos.x + x;

            for (int z = -radius; z <= radius; z++)
            {
                blockPos.z = playerPos.z + z;

                var dx = x * x;
                var dz = z * z;

                if ((dx + dz) > sqrRadius)
                    continue;

                for (int y = 0; y <= world.GetHeight(blockPos.x, blockPos.z); y++)
                {
                    blockPos.y = y;

                    blockChangeInfos.Add(new BlockChangeInfo(blockPos, BlockValue.Air, MarchingCubes.DensityAir));
                }
            }
        }

        Log.Out($"[GenerateHoleConsoleCmd] digging {blockChangeInfos.Count:N0} blocks");

        world.SetBlocksRPC(blockChangeInfos);
    }
}
