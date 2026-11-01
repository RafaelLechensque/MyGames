using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGames;

public class Sprite
{

    public Texture2D Texture { get; private set; }
    public Vector2 Position { get; set; }
    public Color Color { get; set; } = Color.White;
    public float Rotation { get; set; } = 0f;
    public float Scale { get; set; } = 1f;
    public Rectangle SourceRectangle;


    public Sprite(Texture2D texture, Vector2 position)
    {
        Texture = texture;
        Position = position;
    }

    public Sprite(Texture2D texture, Vector2 position, Rectangle sourceRectangle)
    {
        Texture = texture;
        Position = position;
        SourceRectangle = sourceRectangle;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
        Texture,
        Position,
        SourceRectangle,
        Color,
        Rotation,
        Vector2.Zero,
        Scale,
        SpriteEffects.None,
        0f
        );
    }
}