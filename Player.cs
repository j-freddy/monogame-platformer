using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player {
    Texture2D texture;
    Vector2 position;
    float width = 36f;
    float xVel = 0f;
    float yVel = 0f;
    float xAcc = 95f;
    float gravity = 60f;
    float friction = 0.8f;
    float airResistance = 0.95f;
    float jumpPower = 1500f;

    public void Initialize() {
        position = new Vector2(300f, 300f);
    }

    private float GetScaleFactor() {
        return width / Math.Max(texture.Width, texture.Height);
    }

    public void LoadContent(ContentManager Content) {
        texture = Content.Load<Texture2D>("player");
    }

    public void Update(KeyboardState kstate, float deltaTime) {
        // Update X physics

        if (kstate.IsKeyDown(Keys.Left)) {
            xVel -= xAcc;
        }

        if(kstate.IsKeyDown(Keys.Right)) {
            xVel += xAcc;
        }

        xVel *= friction;
        position.X += xVel * deltaTime;

        // Update Y physics

        if(kstate.IsKeyDown(Keys.Up) && position.Y == 400) {
            yVel = -jumpPower;
        }

        yVel += gravity;
        yVel *= airResistance;

        if (position.Y > 400) {
            yVel = 0;
            position.Y = 400;
        }

        position.Y += yVel * deltaTime;

        Debug.WriteLine(position.Y);
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
