using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGames.Entities;

public class Player
{
    private GraphicsDeviceManager _graphics;

    private Texture2D _texture;
    private Vector2 _position;
    private Vector2 _direction = new Vector2(1f, 1f);
    private Random _random = new Random();
    private float _speed = 600f;
    private readonly Point _size = new Point(25, 150);


    public Player(GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics, Vector2 position, Color color)
    {
        _texture = new Texture2D(graphicsDevice, 1, 1);
        _graphics = graphics;
        _texture.SetData(new[] { color });
        _position = position;
    }

    public void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        KeyboardState keyboard = Keyboard.GetState();


        if (keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.W))
            _position.Y -= _speed * deltaTime;

        if (keyboard.IsKeyDown(Keys.Down) || keyboard.IsKeyDown(Keys.S))
            _position.Y += _speed * deltaTime;

        _position.Y = MathHelper.Clamp(_position.Y, 0, _graphics.PreferredBackBufferHeight - _size.Y);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            _texture,
            new Rectangle(
                (int)_position.X,
                (int)_position.Y,
                _size.X,
                _size.Y
            ),
            Color.Red
        );
    }

}
