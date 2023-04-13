using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Tile
{
    protected Texture2D texture;
    protected Vector2 position;
    protected float width;

    public Tile(Vector2 position, float width)
    {
        this.position = position;
        this.width = width;
    }

    private float GetScaleFactor()
    {
        return width / Math.Max(texture.Width, texture.Height);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            texture,
            position,
            null,
            Color.White,
            0f,
            Vector2.Zero,
            Vector2.One * GetScaleFactor(),
            SpriteEffects.None,
            0f
        );
    }
}