using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player : Tile {
    float xVel = 0f;
    float yVel = 0f;
    float xAcc = 95f;
    float gravity = 60f;
    float friction = 0.8f;
    float airResistance = 0.95f;
    float jumpPower = 1500f;

    public Player() : base(Vector2.Zero, 36f)
    {

    }

    public void Initialize() {
        position = new Vector2(300f, 300f);
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
}
