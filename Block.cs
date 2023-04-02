using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class Block {
    Texture2D texture;
    Vector2 position;
    float width;

    public Block(Vector2 position, float width) {
        this.position = position;
        this.width = width;
    }

    private float GetScaleFactor() {
        return width / Math.Max(texture.Width, texture.Height);
    }

    public void LoadContent(ContentManager Content) {
        texture = Content.Load<Texture2D>("ground");
    }

    public void Draw(SpriteBatch spriteBatch) {
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
