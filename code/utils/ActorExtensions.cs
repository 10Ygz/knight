using UnityEngine;

namespace VideoCopilot.code.utils;

public static class ActorExtensions
{
    private const string knight_key = "wushu.knightNum";

    public static float GetKnight(this Actor actor)
    {
        actor.data.get(knight_key, out float val, 0);

        return val;
    }

    public static void SetKnight(this Actor actor, float val)
    {
        actor.data.set(knight_key, val);
    }

    public static void ChangeKnight(this Actor actor, float delta)
    {
        actor.data.get(knight_key, out float val, 0);
        val += delta;
        actor.data.set(knight_key, Mathf.Max(0, val));
    }
}